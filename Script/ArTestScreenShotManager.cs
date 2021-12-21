using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ArTestScreenShotManager : MonoBehaviour
{
    [SerializeField]
    Animator[] noticeAni;

    [SerializeField]
    Camera cam;


    private int resWidth;
    private int resHeight;
    string url;
    string path;
    // Use this for initialization
    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
    }

    public void ClickScreenShot()
    {

        /*
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                break;

            case RuntimePlatform.Android:
                if (!Directory.Exists(Application.persistentDataPath + "/ScreenShot1/"))
                {
                    Debug.Log("make");
                    Directory.CreateDirectory(Application.persistentDataPath + "/ScreenShot1/");
                }

                path = Application.persistentDataPath + "/ScreenShot1/";
                break;

            case RuntimePlatform.WindowsEditor:
                path = Application.dataPath + "/ScreenShot/";
                break;
        }

        string name;                                                               
        name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        cam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();
                                                                                                  
        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);
        cam.targetTexture = null;
         */

        noticeAni[0].SetTrigger("isPhotoStart");

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        cam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        cam.targetTexture = null;


        NativeGallery.SaveImageToGallery(bytes, "메르드거제", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
    }
}
