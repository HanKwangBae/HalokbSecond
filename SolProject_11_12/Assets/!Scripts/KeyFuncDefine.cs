using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyFuncNormal
{
    public List<KeyCode> _listKeyCode;
    public List<string> _listSkelAnimName;
}

[Serializable]
public class KeyFuncMulti
{
    public KeyCode _keyCodeSub;
    public List<KeyCode> _listKeyCodeMain;
    public List<string> _listSkelAnimName;
}

[Serializable]
public class MicFunc
{
    public double _fVolume;
    public string _strMicAnimationName;
}
