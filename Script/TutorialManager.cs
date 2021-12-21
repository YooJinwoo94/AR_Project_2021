using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] uiSet;


    private void Start()
    {
        tutorialCount = 0;
        for (int i = 1; i < 5; i++)
        {
            uiSet[i].SetActive(false);
        }
        uiSet[tutorialCount].SetActive(true);
    }

    int tutorialCount;
    [HideInInspector]
   public Vector3 firstPos;
    [HideInInspector]
    public  Vector3 nowPos;



    private void Update()
    {
        androidUIMove();
    }


   void androidUIMove()
    {
        if (Input.touchCount == 0) return;

        switch (Input.GetTouch(0).phase)
        {
            case TouchPhase.Began:
                firstPos = Input.GetTouch(0).position;
                break;

            case TouchPhase.Ended:
                nowPos = Input.GetTouch(0).position;


                // 왼쪽으로
                if ((nowPos.x - firstPos.x) < - 200)
                {
                    if (tutorialCount == 4)
                    {
                        SceneManager.LoadScene("UI_Loading");
                        return;
                    }
                    tutorialCount++;
                    tutorialStepCon(tutorialCount);
                }
                // 오른쪽
                else if ((nowPos.x - firstPos.x) > 200)
                {
                    if (tutorialCount == 0) return;

                    tutorialCount--;
                    tutorialStepCon(tutorialCount);              
                }
             
                break;
        }
    }



    public void startButton()
    {
        SceneManager.LoadScene("UI_Loading");
    }


    public void tutorialStepCon(int num)
    {
        for (int i = 0; i < 5; i++)
        {
            uiSet[i].SetActive(false);
            if (i == num)
            {
                uiSet[num].SetActive(true);
            }        
        }
    }
}
