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

   


    // �ڵ����� �������� �� ��� �ν��մϴ�.
    private void OnApplicationPause(bool pause)
    {
        switch (pause)
        {
            case false:

                // OnApplicationPause �� ���� ȣ�� �ǹǷ� �ش� ������ �ذ��ϱ� ���� bool������ �� ó�� ����Ǵ� ���� �����ϴ�.
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
