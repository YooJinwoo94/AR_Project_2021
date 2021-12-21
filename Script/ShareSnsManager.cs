using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareSnsManager : MonoBehaviour
{

    public void shareToSns(string name)
    {
        switch (name)
        {
            case "FaceBookShare":
                Application.OpenURL("https://ko-kr.facebook.com/messenger/");
                break;

            case "InstargramShare":
                Application.OpenURL("https://www.instagram.com/");
                break;
        }
    }
}
