using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicFuncSetting : MonoBehaviour {
    public static MicFuncSetting _this;

    public List<MicFunc> _listMicFunc;

    private void Awake()
    {
        _this = this;
    }

    public List<MicFunc> GetMicFunc()
    {
        if (null != _listMicFunc)
            return _listMicFunc;
        return null;
    }
}
