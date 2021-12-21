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

        _timeText[0].text = ((int)_audioSource.time).ToString() + " ��";
        _timeText[1].text = ((int)_audioSource.clip.length).ToString() + " ��";

        _slider.value = _audioSource.time / _audioSource.clip.length;
    }


    public void turnOnOffUI(string name,string photoZone = "")
    {
        switch (name)
        {
            case "Start":
                _audioSource.time = 0;
                // ���� ����
                if (photoZone == "GuideZone01")
                {
                    _audioSource.clip = _audioClip[0];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // �볪��
                if (photoZone == "GuideZone02")
                {
                    _audioSource.clip = _audioClip[5];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                //�ٶ��� ���� 
                if (photoZone == "GuideZone03")
                {
                    _audioSource.clip = _audioClip[6];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // ���
                if (photoZone == "GuideZone04")
                {
                    _audioSource.clip = _audioClip[4];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // �� ��Ʈ ���� 
                if (photoZone == "GuideZone05")
                {
                    _audioSource.clip = _audioClip[2];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // �޸������ ���� 
                if (photoZone == "GuideZone07")
                {
                    _audioSource.clip = _audioClip[1];

                    _uiObj.SetActive(true);
                    _audioSource.Play();
                }
                // ���2
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

    // ���� �����̵� ��ġ�� �ߵ�
    public void valueChange()
    {
        _audioSource.time = _slider.value * _audioSource.clip.length;
        _timeText[0].text = ((int)_audioSource.time).ToString() + " ��";
    }
}
