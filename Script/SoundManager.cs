using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField]
    ARManager _arManagerScript;
    [SerializeField]
    Text[] _timeText;
    [SerializeField]
    Slider _slider;

    [SerializeField]
    GameObject _uiObj;

    [SerializeField]
    AudioClip[] _audioClip;
    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    GameObject[] _playPauseUI;



    private void Start()
    {
        if (_uiObj.activeInHierarchy != true) return;

         _uiObj.SetActive(false);
                 
        _playPauseUI[0].SetActive(true);
        _playPauseUI[1].SetActive(false);

        _audioSource.time = 0;
    }



    private void Update()
    {
        if (_audioSource.isPlaying != true) return;

        _timeText[0].text = ((int)_audioSource.time).ToString() + " 초";
        _timeText[1].text = ((int)_audioSource.clip.length).ToString() + " 초";

        _slider.value = _audioSource.time / _audioSource.clip.length;
    }


    public void turnOnOffUI(string name,string photoZone = "")
    {
        switch (name)
        {
            case "Start":
                _audioSource.time = 0;
                // 용담꽃 설명
                if (photoZone == "GuideZone01")
                {
                    _audioSource.clip = _audioClip[0];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // 대나무
                if (photoZone == "GuideZone02")
                {
                    _audioSource.clip = _audioClip[5];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                //바람의 정원 
                if (photoZone == "GuideZone03")
                {
                    _audioSource.clip = _audioClip[6];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // 명상
                if (photoZone == "GuideZone04")
                {
                    _audioSource.clip = _audioClip[4];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // 점 아트 설명 
                if (photoZone == "GuideZone05")
                {
                    _audioSource.clip = _audioClip[2];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // 메르드거제 설명 
                if (photoZone == "GuideZone07")
                {
                    _audioSource.clip = _audioClip[1];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // 명상2
                if (photoZone == "GuideZone08")
                {
                    _audioSource.clip = _audioClip[3];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }

                break;

            case "End":
                _audioSource.Stop();
                _uiObj.SetActive(false);

                break;
        }
    }





    public void pressPlayOrPause(string name)
    {
        switch(name)
        {
            case "Play":
                _playPauseUI[0].SetActive(false);
                _playPauseUI[1].SetActive(true);

                _audioSource.Pause();
                break;

            case "Pause":
                _playPauseUI[0].SetActive(true);
                _playPauseUI[1].SetActive(false);

                _audioSource.Play();
                break;
        }
    }

    public void pressExitBtn()
    {
        _arManagerScript.turnOffAR();

        _uiObj.SetActive(false);
        _playPauseUI[0].SetActive(true);
        _playPauseUI[1].SetActive(false);
    }

    // 사운드 슬라이드 터치시 발동
    public void valueChange()
    {
        _audioSource.time = _slider.value * _audioSource.clip.length;
        _timeText[0].text = ((int)_audioSource.time).ToString() + " 초";
    }
}
