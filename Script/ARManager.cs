using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;


public class ARManager : MonoBehaviour
{
    [SerializeField]
    GameObject blackBG;
    [SerializeField]
    public GameObject[] noticeObj;

    [SerializeField]
    SoundManager _soundManagerScript;
    [SerializeField]
    VideoManager videoManagerScript;
    [SerializeField]
    ARSceneSceneManager arSceneSceneManagerScript;
    [SerializeField]
    ARSceneUIManager arSceneUIManagerScript;
    [SerializeField]
    ARTrackedImageManager trackedImageManager;
    [SerializeField]
    List<GameObject> objList = new List<GameObject>();
    Dictionary<string, GameObject> preFabDic = new Dictionary<string, GameObject>();

    [HideInInspector]
    public string objName;
    bool isSetPosAndRotation;

    List<ARTrackedImage> tNumList = new List<ARTrackedImage>();
    List<ARTrackedImage> _trackedImg = new List<ARTrackedImage>();
    List<float> _trackedTimer = new List<float>();
    const float _timer = 4;





    private void Start()
    {
        isSetPosAndRotation = false;
        objName = null;

        // dic 에 이름을 넣어준다.
        foreach (GameObject obj in objList)
        {
            string tName = obj.name;
            preFabDic.Add(tName, obj);
        }
        // 혹시 모르니 초기화를 해줍니다.
        for (int i = 0; i < objList.Count; i++)
        {
            objList[i].SetActive(false);
        }

        turnOnOffNotice("turnOnNotice00");
    }



    private void Update()
    {
        if (_trackedImg.Count > 0)
        {
            // 카메라에 안보이는 시간이 어느정도 지난경우
            for (int i = 0; i < _trackedImg.Count; i++)
            {
                switch (_trackedImg[i].trackingState)
                {
                    case UnityEngine.XR.ARSubsystems.TrackingState.Limited:
                        if (_trackedTimer[i] > _timer)
                        {
                            turnOffAR();
                        }
                        else
                        {
                            _trackedTimer[i] += Time.deltaTime;
                        }
                        break;
                }
            }
        } 
    }



    //AR foundation의 기능입니다.
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += imageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= imageChanged;
    }





    public void turnOffAR()
    {
        if (isSetPosAndRotation == false) return;
        isSetPosAndRotation = false;

        turnOnOffNotice("turnOnNotice00");

        tNumList.Add(_trackedImg[0]);

        for (int i = 0; i < tNumList.Count; i++)
        {
            string name = _trackedImg[0].referenceImage.name;
            GameObject tObj = preFabDic[name];
            tObj.SetActive(false);

            int num = _trackedImg.IndexOf(tNumList[i]);
            tNumList.Remove(_trackedImg[num]);
            _trackedImg.Remove(_trackedImg[num]);
            _trackedTimer.Remove(_trackedTimer[num]);
        }

        _soundManagerScript.turnOnOffUI("End");
    }





    //AR foundation의 기능입니다.
    void imageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // 이미지가 추가瑛 경우
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (!_trackedImg.Contains(trackedImage))
            {
                if (_trackedImg.Count == 1) turnOffAR();

                _trackedImg.Add(trackedImage);
                _trackedTimer.Add(0);
            }
        }

        // 이미지가 변화했을 경우
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (!_trackedImg.Contains(trackedImage))
            {
                switch (trackedImage.trackingState)
                {
                    case UnityEngine.XR.ARSubsystems.TrackingState.Tracking:
                        {
                            _trackedImg.Add(trackedImage);
                            _trackedTimer.Add(0);
                            break;
                        }
                }
            }
            else
            {
                switch (trackedImage.trackingState)
                {
                    case UnityEngine.XR.ARSubsystems.TrackingState.Tracking:
                        {
                            int num = _trackedImg.IndexOf(trackedImage);
                            _trackedTimer[num] = 0;
                            break;
                        }
                }
            }

            updateImage(trackedImage);
        }
    }







    //대상을 꺼주거나 켜주는 함수입니다.
    void updateImage(ARTrackedImage trackedImage)
    {
        objName = trackedImage.referenceImage.name;
        GameObject tobj = preFabDic[objName];

        switch (trackedImage.trackingState)
        {
            case UnityEngine.XR.ARSubsystems.TrackingState.Tracking:
                if (isSetPosAndRotation == false)
                {
                    isSetPosAndRotation = true;
                    turnOnOffNotice("turnOffNotice00AndNotice01");
                    blackImageOn();
                    tobj.SetActive(true);
                    videoManagerScript.videoCon(objName);                  
                    _soundManagerScript.turnOnOffUI("Start", objName);
                }
                //tobj.transform.position = trackedImage.transform.position;
                // tobj.transform.rotation = Quaternion.Euler(-90, -45, 0);
                break;
        }

        // 오브젝트가 계속 돌아가는 경향이 있어서 
        // 일정 부분은 돌아가지 않도록 설정
        tobj.transform.position = trackedImage.transform.position;
        if ( (trackedImage.transform.rotation.y < 1 || trackedImage.transform.rotation.y > -1) &&
            (trackedImage.transform.rotation.x < 1 || trackedImage.transform.rotation.x > -1) &&
            (trackedImage.transform.rotation.z < 1 || trackedImage.transform.rotation.z > -1))
        {
            tobj.transform.rotation = trackedImage.transform.rotation;
        }
        
        Debug.Log(tobj.transform.rotation);
    }


    //알람창 컨트롤러!
    void turnOnOffNotice(string name)
    {
        switch (name)
        {
            case "turnOffNotice00AndNotice01":
                noticeObj[0].SetActive(false);
                noticeObj[1].SetActive(false);
                break;

            case "turnOnNotice00":
                noticeObj[0].SetActive(true);
                noticeObj[1].SetActive(false);
                break;

            case "turnOnNotice01":
                noticeObj[0].SetActive(false);
                noticeObj[1].SetActive(true);
                break;
        }
    }



    // 비디오가 켜질 사각 박스 이미지가 5초정도 보이는 현상이 생깁니다.
    // 해당 현상을 가려주기 위해 이미지를 가립니다.
    void blackImageOn()
    {
        blackBG.SetActive(true);
        turnOnOffNotice("turnOnNotice01");

        Invoke("conImage", 1f);
    }

    void conImage()
    {
        blackBG.SetActive(false);
        turnOnOffNotice("turnOffNotice00AndNotice01");
    }
}