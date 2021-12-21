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
    const float _timer = 5;





    private void Start()
    {
        isSetPosAndRotation = false;
        objName = null;

        // dic �� �̸��� �־��ش�.
        foreach (GameObject obj in objList)
        {
            string tName = obj.name;
            preFabDic.Add(tName, obj);
        }
        // Ȥ�� �𸣴� �ʱ�ȭ�� ���ݴϴ�.
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
            // ī�޶� �Ⱥ��̴� �ð��� ������� �������
            for (int i = 0; i<_trackedImg.Count; i++)
            {
                switch(_trackedImg[i].trackingState)
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

            //�ߺ� ���� ����!
            switch (_trackedImg.Count)
               {
                case 0:
                    break;

                case 1:
                    break;

                  default :
                    turnOffAR();
                     break;
               }
               
            //������ ������!
            if (tNumList.Count>0)
             {
                 for (int i = 0; i < tNumList.Count; i++)
                    {
                       int num = _trackedImg.IndexOf(tNumList[i]);

                        tNumList.Remove(_trackedImg[num]);

                        _trackedImg.Remove(_trackedImg[num]);
                        _trackedTimer.Remove(_trackedTimer[num]);
                    }
             }
        }
    }



    //AR foundation�� ����Դϴ�.
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
        isSetPosAndRotation = false;

        string name = _trackedImg[0].referenceImage.name;
        GameObject tObj = preFabDic[name];
        tObj.SetActive(false);

        isSetPosAndRotation = false;
        turnOnOffNotice("turnOnNotice00");
        tNumList.Add(_trackedImg[0]);

        _soundManagerScript.turnOnOffUI("End");
    }





    //AR foundation�� ����Դϴ�.
    void imageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // �̹����� �߰����� ���
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (!_trackedImg.Contains(trackedImage))
            {
                _trackedImg.Add(trackedImage);
                _trackedTimer.Add(0);
            }
        }

        // �̹����� ��ȭ���� ���
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







    //����� ���ְų� ���ִ� �Լ��Դϴ�.
    void updateImage(ARTrackedImage trackedImage)
    {
        objName = trackedImage.referenceImage.name;
        GameObject tobj = preFabDic[objName];
      //  tobj.transform.position = trackedImage.transform.position;
      //  tobj.transform.rotation = trackedImage.transform.rotation;

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
                      tobj.transform.position = trackedImage.transform.position;
                      tobj.transform.rotation = trackedImage.transform.rotation;
                }
                    break;   
        }
    }


    //�˶�â ��Ʈ�ѷ�!
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



    // ������ ������ �簢 �ڽ� �̹����� 5������ ���̴� ������ ����ϴ�.
    // �ش� ������ �����ֱ� ���� �̹����� �����ϴ�.
    void blackImageOn()
    {
        blackBG.SetActive(true);
        turnOnOffNotice("turnOnNotice01");

        Invoke("conImage",1f);
    }

    void conImage()
    {
        blackBG.SetActive(false);
        turnOnOffNotice("turnOffNotice00AndNotice01");
    }
}
