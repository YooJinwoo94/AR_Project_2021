using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class LoadAddressable : MonoBehaviour
{
    [Space]
    [Header("다운로드를 원하는 번들 또는 번들들에 포함된 레이블중 아무거나 입력해주세요.")]
    [SerializeField] string LableForBundleDown = string.Empty;

    [SerializeField]
    GameObject[] blackImg;
    [SerializeField]
    GameObject downLoadSizeText;

    [SerializeField]
    GameObject[] downloadScene;

    [SerializeField]
    GameObject[] downLoadSceneObj0102;
    [SerializeField]
    GameObject[] uiScene02Btn;

    [SerializeField]
    Text downLoadSize;
    [SerializeField]
    Slider downLoadSlider;

    bool isDownStart;
    AsyncOperationHandle handle;
    [SerializeField]
    Text leftDownLoadSize;



    private void Start()
    {
        isDownStart = false;
        blackImg[0].SetActive(true);

        downLoadSceneObj0102[0].SetActive(false);
        downLoadSceneObj0102[1].SetActive(false);

        uiScene02Btn[0].SetActive(true);
        uiScene02Btn[1].SetActive(true);
       // uiScene02Btn[2].SetActive(true);

        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
              (AsyncOperationHandle<long> SizeHandle) =>
              {
                  if (Application.internetReachability == NetworkReachability.NotReachable) return;

                  var a = SizeHandle;
                  if (a.Result == 0)
                  { 
                      //메모리 해제.
                      Addressables.Release(SizeHandle);
                      SceneManager.LoadScene("AR_Scene01");
                  }
                  else
                  {
                      downLoadSceneObj0102[0].SetActive(true);
                      downLoadSceneObj0102[1].SetActive(false);

                      var sizeText = string.Concat((SizeHandle.Result/ 1024)/1024, " MB");

                      sizeText = string.Format("{0:F2}", sizeText);
                      downLoadSize.text = sizeText;
                  }

                      //메모리 해제.
                      Addressables.Release(SizeHandle);
              };
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            stopDown();
        }

        if (isDownStart == false) return;


        downLoadText();
    }


    public void downStart()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable) return;

        isDownStart = true;


        downLoadSceneObj0102[0].SetActive(false);
        downLoadSceneObj0102[1].SetActive(true);

        uiScene02Btn[0].SetActive(false);
        uiScene02Btn[1].SetActive(false);
      //  uiScene02Btn[2].SetActive(true);

        handle = Addressables.DownloadDependenciesAsync(LableForBundleDown);
        handle.Completed += (AsyncOperationHandle asyncOperationHandleobj) =>
        {
            switch (handle.Status)
            {
                case AsyncOperationStatus.Succeeded:

                    Addressables.Release(handle);
                    SceneManager.LoadScene("AR_Scene01");
                    break;

                default:
                    break;
            }
        };
    }

    public void stopDown()
    {
        downLoadSceneObj0102[0].SetActive(true);
        downLoadSceneObj0102[1].SetActive(false);

        uiScene02Btn[0].SetActive(true);
        uiScene02Btn[1].SetActive(true);
       // uiScene02Btn[2].SetActive(true);

        downloadScene[0].SetActive(false);
        downloadScene[1].SetActive(false);   
    }

    void downLoadText()
    {
        float progress = handle.PercentComplete;
        downLoadSizeText.GetComponent<Text>().text = ((int)(progress * 100)).ToString() + " %";

        downLoadSlider.value = progress;

        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
             (AsyncOperationHandle<long> SizeHandle) =>
             {
                  float fullSizeFloat = Mathf.Round(((SizeHandle.Result / 1024) / 1024));
                  float nowDownLoadSizeFloat = Mathf.Round ( ((SizeHandle.Result / 1024) / 1024) * handle.PercentComplete );

                 var sizeText = fullSizeFloat + " MB";

                 var nowDownLoadSize = nowDownLoadSizeFloat + " MB";
     

                 leftDownLoadSize.text =  "( " + nowDownLoadSize + " /"+ sizeText + " )";

                 //메모리 해제.
                 Addressables.Release(SizeHandle);
             };
    }
}
