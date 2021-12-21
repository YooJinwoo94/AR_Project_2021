using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ARSceneUIManager : MonoBehaviour
{
    [SerializeField]
    ARManager arManagerScript;

    [SerializeField]
    ArTestScreenShotManager arTestScreenShotManagerScript;

    [HideInInspector]
    public bool isButtonClick;

    private void Start()
    {
        isButtonClick = false;
    }






    // 해당 함수는 유니티 ui 버튼으로 인식합니다.
    public void startArButton(bool down)
    {
        arManagerScript.noticeObj[0].SetActive(false);
        arManagerScript.noticeObj[1].SetActive(true);

        isButtonClick = true;
    }


    public void startScreenShot()
    {
        arTestScreenShotManagerScript.ClickScreenShot();
    }

    public void backToUiScene()
    {
        SceneManager.LoadScene("UI_Scene");
    }
}
