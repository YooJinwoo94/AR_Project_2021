using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer01;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer02;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer03;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer04;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer05;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer06;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer07;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer08;

    [SerializeField]
    MSKBridgeVideoPlayer[] videoPlayer09;

    [SerializeField]
    MSKBridgeVideoPlayer[] GuideZone05;

    [SerializeField]
    MSKBridgeVideoPlayer[] GuideZone06;

    [SerializeField]
    MSKBridgeVideoPlayer[] GuideZone07;

    [SerializeField]
    MSKBridgeVideoPlayer[] GuideZone09;


    public void videoCon(string name)
    {
        switch (name)
        {
            case "PhotoZone01":
                for(int i = 0; i<videoPlayer01.Length;i++)
                {
                    if (videoPlayer01[i].videoPlayer.isPlaying != true)
                    {
                        videoPlayer01[i].videoPlayer.Play();
                    }
                }
                break;
            case "PhotoZone02":
                for (int i = 0; i < videoPlayer02.Length; i++)
                {
                    videoPlayer02[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone03":
                for (int i = 0; i < videoPlayer03.Length; i++)
                {
                    videoPlayer03[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone04":
                for (int i = 0; i < videoPlayer04.Length; i++)
                {
                    videoPlayer04[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone05":
                for (int i = 0; i < videoPlayer05.Length; i++)
                {
                    videoPlayer05[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone06":
                for (int i = 0; i < videoPlayer06.Length; i++)
                {
                    videoPlayer06[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone07":
                for (int i = 0; i < videoPlayer07.Length; i++)
                {
                    videoPlayer07[i].videoPlayer.Play();
                }
                break;
            case "PhotoZone08":
                for (int i = 0; i < videoPlayer08.Length; i++)
                {
                    videoPlayer08[i].videoPlayer.Play();
                }
                break;

            case "PhotoZone09":
                for (int i = 0; i < videoPlayer09.Length; i++)
                {
                    videoPlayer08[i].videoPlayer.Play();
                }
                break;


            case "GuideZone05":
                for (int i = 0; i < GuideZone05.Length; i++)
                {
                    Debug.Log(i);
                    GuideZone05[i].videoPlayer.Play();
                }
                break;

            case "GuideZone06":
                for (int i = 0; i < GuideZone06.Length; i++)
                {
                    Debug.Log(i);
                    GuideZone06[i].videoPlayer.Play();
                }
                break;

            case "GuideZone07":
                for (int i = 0; i < GuideZone07.Length; i++)
                {
                    Debug.Log(i);
                    GuideZone07[i].videoPlayer.Play();
                }
                break;
        }
    }
}
