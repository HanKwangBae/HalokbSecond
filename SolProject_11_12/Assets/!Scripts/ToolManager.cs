using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System;
using UnityEngine;
using UnityEditor;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

public class ToolManager : MonoBehaviour
{
    string _strJsonNormal;
    string _strJsonMulti;
    string _strJsonMic;

    private void Start()
    {
        _strJsonNormal = LitJson.JsonMapper.ToJson(KeyFuncSetting._this.GetKeyFuncNormal());
        _strJsonMulti = LitJson.JsonMapper.ToJson(KeyFuncSetting._this.GetKeyFuncMulti());
        _strJsonMic = LitJson.JsonMapper.ToJson(MicFuncSetting._this.GetMicFunc());
    }

    public void MakeJsonFile()
    {
        FileStream keyFuncNormalfile = MakeFile(string.Format("{0}/{1}", Application.persistentDataPath, "KeyFuncNormal.sav"));
        
        byte[] bytes = Encoding.UTF8.GetBytes(_strJsonNormal);
        keyFuncNormalfile.Write(bytes, 0, bytes.Length);
        keyFuncNormalfile.Close();

        FileStream keyFuncMultifile = MakeFile(string.Format("{0}/{1}", Application.persistentDataPath, "KeyFuncMulti.sav"));

        byte[] bytes_1 = Encoding.UTF8.GetBytes(_strJsonMulti);
        keyFuncMultifile.Write(bytes_1, 0, bytes_1.Length);
        keyFuncMultifile.Close();

        FileStream micFuncFile = MakeFile(string.Format("{0}/{1}", Application.persistentDataPath, "MicFunc.sav"));

        byte[] bytes_2 = Encoding.UTF8.GetBytes(_strJsonMic);
        micFuncFile.Write(bytes_2, 0, bytes_2.Length);
        micFuncFile.Close();
    }

    FileStream MakeFile(string strFilename)
    {
        if (File.Exists(strFilename))
            File.Delete(strFilename);

        return File.Open(strFilename, FileMode.OpenOrCreate);
    }
}

