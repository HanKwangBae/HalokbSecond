using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataManager : MonoBehaviour {
    public static DataManager _this;

    private void Awake()
    {
        _this = this;
    }

    public KeyFuncNormal GetKeyFuncNormalObject()
    {
        string filePath = string.Format("{0}/{1}", Application.persistentDataPath, "KeyFuncNormal.sav");
        FileStream stream = File.Open(filePath, FileMode.Open);
        StreamReader sr = new StreamReader(stream);
        if (null == sr)
        {
            Debug.Log("KeyFuncNormal is null!");
            return null;
        }

        string strText = sr.ReadToEnd();
        KeyFuncNormal getData = LitJson.JsonMapper.ToObject<KeyFuncNormal>(strText);
        return getData;
    }

    public List<KeyFuncMulti> GetKeyFuncMultiObject()
    {
        string filePath = string.Format("{0}/{1}", Application.persistentDataPath, "KeyFuncMulti.sav");
        FileStream stream = File.Open(filePath, FileMode.Open);
        StreamReader sr = new StreamReader(stream);
        if (null == stream)
        {
            Debug.Log("KeyFuncMulti is null!");
            return null;
        }

        string strText = sr.ReadToEnd();
        List<KeyFuncMulti> getData = LitJson.JsonMapper.ToObject<List<KeyFuncMulti>>(strText);
        return getData;
    }

    public List<MicFunc> GetMicFuncObject()
    {
        string filePath = string.Format("{0}/{1}", Application.persistentDataPath, "MicFunc.sav");
        FileStream stream = File.Open(filePath, FileMode.Open);
        StreamReader sr = new StreamReader(stream);
        if (null == stream)
        {
            Debug.Log("KeyFuncMulti is null!");
            return null;
        }

        string strText = sr.ReadToEnd();
        List<MicFunc> getData = LitJson.JsonMapper.ToObject<List<MicFunc>>(strText);
        return getData;
    }
}
