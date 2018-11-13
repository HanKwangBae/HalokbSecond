using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFuncSetting : MonoBehaviour {
    public static KeyFuncSetting _this;

    public KeyFuncNormal _keyFuncNormal;
    public List<KeyFuncMulti> _KeyFuncMulti;

    private void Awake()
    {
        _this = this;
    }

    public KeyFuncNormal GetKeyFuncNormal()
    {
        if(null != _keyFuncNormal)
            return _keyFuncNormal;
        return null;
    }

    public List<KeyFuncMulti> GetKeyFuncMulti()
    {
        if (null != _KeyFuncMulti)
            return _KeyFuncMulti;
        return null;
    }
}
