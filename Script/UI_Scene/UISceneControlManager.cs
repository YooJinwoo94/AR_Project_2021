using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UISceneControlManager : MonoBehaviour
{
    [SerializeField]
    Image[] contentsDetailImg01;

    [SerializeField]
    Image[] contentsDetailImg03;

    [SerializeField]
    ContentsImageDataBase contentsImageDataBase;

    [SerializeField]
    Scrollbar page06DetailUIScrollBarScript;
    [SerializeField]
    Scrollbar[] page02ScrollBarScript;

    [SerializeField]
    Scrollbar page01ScrollBarScript;
    [SerializeField]
    Scrollbar page05ScrollBarScript;
    [SerializeField]
    ScrollRect page05ScrollRectScript;

    [SerializeField]
    RectTransform mainCamPos;
    [SerializeField]
    RectTransform canvasPageMapCamPos;
    [HideInInspector]
    public int pageNum;


    [SerializeField]
    Animator sliderUIAni;

    [SerializeField]
    GameObject[] uiScenePage02ScrollSet;
    [SerializeField]
    GameObject[] uiScenePage02ToggleSet;


    [SerializeField]
    GameObject[] bottomToggleOnObj;
    [SerializeField]
    GameObject[] bottomToggleOffObj;

    [SerializeField]
    Animator[] uiScenePage01AniSet;

    [SerializeField]
    Animator[] uiScenePage05AniSet;

    [SerializeField]
    Animator[] uiScenePage06AniSet;


    [SerializeField]
    GameObject[] arSceneObj;


    int commendContentsPage;


    private void Start()
    {
        pageNum = 0;

        mainCamPos.localPosition = new Vector3(0, 0, 0);

        for (int i = 0; i<4; i++)
        {
            if (i == 0)
            {
                bottomToggleOnObj[i].SetActive(true);
                bottomToggleOffObj[i].SetActive(false);

                continue;
            }
            else
            {
                bottomToggleOnObj[i].SetActive(false);
                bottomToggleOffObj[i].SetActive(true);

                continue;
            }
        }

        uiScenePage02ToggleSet[0].SetActive(true);
        uiScenePage02ToggleSet[1].SetActive(false);
        uiScenePage02ToggleSet[2].SetActive(false);
        uiScenePage02ToggleSet[3].SetActive(true);

        uiScenePage02ScrollSet[1].SetActive(false);

        arSceneObj[0].SetActive(false);
        arSceneObj[1].SetActive(false);

        page01ScrollBarScript.value = 1;
        page05ScrollBarScript.value = 1;
        page05ScrollRectScript.enabled = false;

        page02ScrollBarScript[0].value = 1;
        page02ScrollBarScript[1].value = 1;

        page06DetailUIScrollBarScript.value = 1;

        commendContentsPage = 0;
    }







    public void toggleButtonClick(int num)
    {
        switch (num)
        {
            case 0:
                mainCamPos.localPosition = new Vector3(0, 0, 0);
                //canvasPageMapCamPos.localPosition = new Vector3(2422, 9, 0);
                break;

            case 1:
                mainCamPos.localPosition = new Vector3(-1127, 0, 0);
               // canvasPageMapCamPos.localPosition = new Vector3(1212, 9, 0);
                break;

            case 2:
                mainCamPos.localPosition = new Vector3(-2280, 0, 0);
                //canvasPageMapCamPos.localPosition = new Vector3(-540, 1200, 0);
                break;

            case 3:
                mainCamPos.localPosition = new Vector3(-3560, 0, 0);
                //canvasPageMapCamPos.localPosition = new Vector3(-1292, 9, 0);
                break;
        }

        pageNum = num;

           for (int i = 0; i < 4; i++)
        {
            if (i == num)
            {
                bottomToggleOnObj[i].SetActive(true);
                bottomToggleOffObj[i].SetActive(false);

                continue;
            }
            else
            {
                bottomToggleOnObj[i].SetActive(false);
                bottomToggleOffObj[i].SetActive(true);
                continue;
            }
        }
    }
    public void moveToARScene()
    {
        arSceneObj[0].SetActive(true);
        arSceneObj[1].SetActive(true);
    }




    //==================================================================================
    public void sliderCon(string name)
    {
       switch (name)
        {
            case "open":
                sliderUIAni.SetBool("isOpen", true);
                break;

            case "close":
                sliderUIAni.SetBool("isOpen", false);
                break;
        }
    }
    public void shareBtn (string name)
    {
        switch(name)
        {
            case "FaceBookShare":
                Application.OpenURL("https://www.facebook.com/sharer/sharer.php?u=");
                break;

            case "InstargramShare":
                Application.OpenURL("https://www.instagram.com/");
                break;
        }
    }


    public void checkCommendContentsAndChangeImage(int contentsNum)
    {
        if (contentsNum == 0) return;

        commendContentsPage = contentsNum;

        uiScenePage01AniSet[0].SetBool("AniOn", true);
        contentsDetailImg01[0].sprite = contentsImageDataBase.contentsImage[contentsNum - 1];
        // contentsDetailImg02[0].sprite = contentsImageDataBase.contentsImage[contentsNum - 1];

        contentsDetailImg03[0].sprite = contentsImageDataBase.contentsDetailImage[(contentsNum * 3) - 3];
        contentsDetailImg03[1].sprite = contentsImageDataBase.contentsDetailImage[(contentsNum * 3) - 2];
        contentsDetailImg03[2].sprite = contentsImageDataBase.contentsDetailImage[(contentsNum * 3) - 1];
    }


    public void commendContentsDetailBtn()
    {
        switch (commendContentsPage)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;

            case 7:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=24");
                break;
            case 8:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=41");
                break;
            case 9:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=20");
                break;
            case 10:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=23");
                break;
            case 11:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=37");
                break;
            case 12:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=39");
                break;
            case 13:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=40");
                break;
            case 14:
                Application.OpenURL("https://geojesitour.com/bbs/board.php?bo_table=06_01&wr_id=45");
                break;
        }
    }



    public void uiScenePage01UICon(string name)
    {
        switch(name)
        {
            case "PressMoveToPage02Btn":
                toggleButtonClick(1);
                break;

            case "PressKakao":
                Application.OpenURL("https://pf.kakao.com/_iLBms");
                break;

            case "PressTodayCommendContents01":
                checkCommendContentsAndChangeImage(1);
                uiScenePage01AniSet[0].SetBool("AniOn",true);
                break;
            case "PressTodayCommendContents02":
                checkCommendContentsAndChangeImage(2);
                uiScenePage01AniSet[0].SetBool("AniOn", true);
                break;
            case "PressTodayCommendContents03":
                checkCommendContentsAndChangeImage(3);
                uiScenePage01AniSet[0].SetBool("AniOn", true);
                break;
            case "PressTodayCommendContents04":
                checkCommendContentsAndChangeImage(4);
                uiScenePage01AniSet[0].SetBool("AniOn", true);
                break;
            case "PressTodayCommendContents05":
                checkCommendContentsAndChangeImage(5);
                uiScenePage01AniSet[0].SetBool("AniOn", true);
                break;

            case "ClosePressTodayCommendContents":
                for (int i = 0; i< 5; i++)
                {
                    if(uiScenePage01AniSet[i].GetBool("AniOn") == true)
                    {
                        uiScenePage01AniSet[i].SetBool("AniOn", false);
                        uiScenePage01AniSet[i].SetBool("Detail_UI_Ani_ON", false);
                        break;
                    }

                }
                break;

            case "PressTodayCommendContents_Detail_UI_OnOff":
                switch (uiScenePage01AniSet[0].GetBool("AniOn"))
                {
                    case true:
                        if (uiScenePage01AniSet[0].GetBool("Detail_UI_Ani_ON") == true)
                        {
                            uiScenePage01AniSet[0].SetBool("Detail_UI_Ani_ON", false);
                            uiScenePage01AniSet[0].SetBool("Detail_UI_Arrow_Ani_On", false);
                        }
                        else
                        {
                            uiScenePage01AniSet[0].SetBool("Detail_UI_Ani_ON", true);
                            uiScenePage01AniSet[0].SetBool("Detail_UI_Arrow_Ani_On", true);
                        }
                        break;
                    case false:
                        break;
                }
                break;
        }
    }
    public void uiScenePage02UICon(string name)
    {
        switch (name)
        {
            case "press_ToggleButton_01":
                uiScenePage02ScrollSet[0].SetActive(true);
                uiScenePage02ScrollSet[1].SetActive(false);

                uiScenePage02ToggleSet[0].SetActive(true);
                uiScenePage02ToggleSet[1].SetActive(false);
                uiScenePage02ToggleSet[2].SetActive(false);
                uiScenePage02ToggleSet[3].SetActive(true);

                page02ScrollBarScript[0].value = 1;
                break;

            case "press_ToggleButton_02":
                uiScenePage02ScrollSet[0].SetActive(false);
                uiScenePage02ScrollSet[1].SetActive(true);

                uiScenePage02ToggleSet[0].SetActive(false);
                uiScenePage02ToggleSet[1].SetActive(true);
                uiScenePage02ToggleSet[2].SetActive(true);
                uiScenePage02ToggleSet[3].SetActive(false);

                page02ScrollBarScript[1].value = 1;
                break;
        }
    }

    public void uiScenePage03UICon(string sizeUpDown)
    {
        switch (sizeUpDown)
        {
            case "sizeUp":

                break;

            case "sizeDown":

                break;
        }
    }

    public void uiScene05UIAniCon(string situation
)
    {
        switch(situation)
        {
            case "OpenUI":
                uiScenePage05AniSet[0].SetBool("isOn", true);
                break;
            case "CloseUI":
                uiScenePage05AniSet[0].SetBool("isOn", false);

                if (uiScenePage05AniSet[1].GetBool("isScollUIOn") == true)
                {
                    uiScenePage05AniSet[1].SetBool("isScollUIOn", false);
                    uiScenePage05AniSet[1].SetBool("isScrollBtnOn", false);

                    page05ScrollRectScript.enabled = false;
                }
                page05ScrollBarScript.value = 1;
                page05ScrollRectScript.enabled = false;
                break;

            case "Scroll":
                if (uiScenePage05AniSet[1].GetBool("isScollUIOn") == true)
                {
                    uiScenePage05AniSet[1].SetBool("isScollUIOn", false);
                    uiScenePage05AniSet[1].SetBool("isScrollBtnOn", false);

                    page05ScrollRectScript.enabled = false;
                }
               else
                {
                    uiScenePage05AniSet[1].SetBool("isScollUIOn", true);
                    uiScenePage05AniSet[1].SetBool("isScrollBtnOn", true);

                    page05ScrollRectScript.enabled = true;

                }
                break;


            case "CheckScrollDownToUp":
                if (page05ScrollBarScript.value >= 1)
                {
                  //  page05ScrollBar_isOnce = true;
                }
                break;
        }

    }
    public void uiScene06AniCon(string situation)
    {
        switch (situation)
        {
            case "page_06_On":
                uiScenePage06AniSet[0].SetBool("isOn", true);
                page06DetailUIScrollBarScript.value = 1;
                break;

            case "page_06_Off":
                if (uiScenePage06AniSet[0].GetBool("isDetailUIOn") == true)
                {
                    uiScenePage06AniSet[0].SetBool("isDetailUIOn", false);
                }
                else
                {
                    uiScenePage06AniSet[0].SetBool("isOn", false);
                }   
                break;

            case "page_06_Detail_01":
                uiScenePage06AniSet[0].SetBool("isDetailUIOn", true);
                break;
        }
    }


    public void uiSceneMenu(string situation)
    {
        sliderCon("close");

        switch (situation)
        {
            case "¾î¹Ù¿ô":
                toggleButtonClick(0);
                break;

            case "ÄÜÅÙÃ÷":
                toggleButtonClick(1);
                break;

            case "Áöµµ":
                toggleButtonClick(2);
                break;

            case "Ä¿¹Â´ÏÆ¼":
                toggleButtonClick(3);
                break;
        }
    }
}
