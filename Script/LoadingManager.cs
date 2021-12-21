using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class LoadingManager : MonoBehaviour
{
    //[SerializeField]
    //Animator bgAlplaColor;


    // Start is called before the first frame update
    void Start()
    {
       // bgAlplaColor.SetTrigger("isAlplaCon");

        Invoke("sceneMoveToUIScene", 1f);
    }


    void sceneMoveToUIScene()
    {
        SceneManager.LoadScene("UI_Scene");
    }
}
