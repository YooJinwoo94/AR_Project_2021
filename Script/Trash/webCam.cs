using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class webCam : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject objScene;

    WebCamTexture webCamTex = null;
    ScreenOrientation screenOrigentation = ScreenOrientation.Portrait;
    CameraClearFlags camClearFlags;

    private void Start()
    {

        foreach (Camera c in Camera.allCameras)
        {
            if (c != cam)
            {
                c.cullingMask = -(1 << objScene.layer);
            }
        }


        cam.farClipPlane = cam.nearClipPlane + 1f;
        objScene.transform.localPosition = new Vector3(0f, 0f, cam.farClipPlane * .5f);
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length > 0)
        {
            webCamTex = new WebCamTexture(Screen.width, Screen.height);
            objScene.GetComponent<Renderer>().material.mainTexture = webCamTex;
        }

        screenOrigentation = Screen.orientation;
        setOrientation(screenOrigentation);
        StartCoroutine("coroutineOrientation");
        show(true);
    }

    void setOrientation(ScreenOrientation sc)
    {
        float h = Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * .5f) * objScene.transform.localPosition.z * 2f;

        if (cam.orthographic)
        {
            h = Screen.height / cam.pixelHeight;
            if (ScreenOrientation.Landscape == sc)
            {
                objScene.transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
                objScene.transform.localScale = new Vector3(cam.aspect * h, 1f, 0f);
            }
            else if (ScreenOrientation.LandscapeLeft == sc)
            {
                objScene.transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
                objScene.transform.localScale = new Vector3(cam.aspect * h, 1f, 0f);
            }
            else if (ScreenOrientation.LandscapeRight == sc)
            {
                objScene.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
                objScene.transform.localScale = new Vector3(cam.aspect * h, 1f, 0f);
            }
            else if (ScreenOrientation.Portrait == sc)
            {
                objScene.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
                objScene.transform.localScale = new Vector3(h, 1f, cam.aspect * h);
            }
            else if (ScreenOrientation.PortraitUpsideDown == sc)
            {
                objScene.transform.localRotation = Quaternion.Euler(0f, 90f, -90f);
                objScene.transform.localScale = new Vector3(h, 1f, cam.aspect * h);
            }
        }    
    }

    IEnumerator coroutineOrientation()
    {
        while (true)
        {
            if (screenOrigentation != Screen.orientation)
            {
                screenOrigentation = Screen.orientation;
                setOrientation(screenOrigentation);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void show (bool flag)
    {
        if (null == webCamTex) return;

        if (flag)
        {
            if (Camera.main != cam)
            {
                camClearFlags = Camera.main.clearFlags;
                Camera.main.clearFlags = CameraClearFlags.Depth;
            }
            cam.gameObject.SetActive(true);
            objScene.SetActive(true);
            webCamTex.Play();                                                                    
        }
        else
        {
            if(Camera.main != cam)
            {
                Camera.main.clearFlags = camClearFlags;
            }
            webCamTex.Pause();
            objScene.SetActive(false);
            cam.gameObject.SetActive(false);
        }
    }
}
