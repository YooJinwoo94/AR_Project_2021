using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ARSceneSceneManager : MonoBehaviour
{
    [SerializeField]
    ARManager arManagerScript;

    [SerializeField]
    ARSceneUIManager arSceneUIManagerScript;

    bool firstStartBlockTheApplicationPause;



    private void Start()
    {
        firstStartBlockTheApplicationPause = false;
    }


    public void resetScene()
    {
        arSceneUIManagerScript.isButtonClick = false;
        arManagerScript.objName = null;
    }

   


    // 핸드폰이 슬립모드로 갈 경우 인식합니다.
    private void OnApplicationPause(bool pause)
    {
        switch (pause)
        {
            case false:

                // OnApplicationPause 가 먼저 호출 되므로 해당 문제를 해결하기 위해 bool값으로 맨 처음 실행되는 것을 막습니다.
                if (firstStartBlockTheApplicationPause == false)
                {
                    firstStartBlockTheApplicationPause = true;
                    return;
                }
                else if (firstStartBlockTheApplicationPause == true)
                {
                    firstStartBlockTheApplicationPause = false;
                    return;
                }

                if (arManagerScript.objName == null) return;

                /*
                if (SceneManager.GetActiveScene().name == "AR_Scene02")
                {
                    SceneManager.LoadScene("AR_Scene01");
                }
                else if (SceneManager.GetActiveScene().name == "AR_Scene01")
                {
                    SceneManager.LoadScene("AR_Scene02");
                }
                */
                break;
        }
    }
}
