using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicManager : MonoBehaviour {
    public AudioSource _audio;

    float _fVoiceVolume;
    float _fSensitivity = 100f;

    List<MicFunc> _listMicFunc;
    int _iMicFuncCount;

	void Start () {
        _listMicFunc = DataManager._this.GetMicFuncObject();
        _iMicFuncCount = _listMicFunc.Count;

        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        float fTime = 0f;
        while (!(Microphone.GetPosition(null) > 0))
        {
            fTime += Time.deltaTime;
            if (5f <= fTime)
                break;
        }
        _audio.Play();
    }

    // Update is called once per frame
    void Update () {
        if(1 == _iMicFuncCount)
        {
            _fVoiceVolume = GetAveragedVolume() * _fSensitivity;

            if(0 < _fVoiceVolume)
            {
                if (_fVoiceVolume > _listMicFunc[0]._fVolume && Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("volume : " + _fVoiceVolume);
                    SpineAnimationManager._this.SetSkelAnimation(_listMicFunc[0]._strMicAnimationName);
                    Debug.Log("loudness is bigger than 1. SetAnimationName : " + _listMicFunc[0]._strMicAnimationName);
                }
                else
                {
                    //Debug.Log("Ready");
                }
            }
        }
        else if(1 < _iMicFuncCount)
        {
            _fVoiceVolume = GetAveragedVolume() * _fSensitivity;

            if (0 < _fVoiceVolume)
            {
                Debug.Log("volume : " + _fVoiceVolume);
                var data = GetFindVolume(_fVoiceVolume);
                if (_fVoiceVolume > data._fVolume && Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("loudness is bigger than 1");
                    SpineAnimationManager._this.SetSkelAnimation(data._strMicAnimationName);
                    Debug.Log("loudness is bigger than 1. SetAnimationName : " + data._strMicAnimationName);
                }
                else
                {
                    Debug.Log("Ready");
                }
            }
        }
    }

    MicFunc GetFindVolume(float fVolume)
    {
        return _listMicFunc.Find(row => fVolume <= row._fVolume);
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
