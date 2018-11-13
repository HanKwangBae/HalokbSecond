using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationManager : MonoBehaviour {
    public static SpineAnimationManager _this;
    public UILabel _labelDebug;

    public SkeletonAnimation _skelAnim;

    KeyFuncNormal _keyFuncNormal;
    KeyFuncMulti _keyFuncMulti;
    List<KeyFuncMulti> _listKeyFuncMulti;

    private void Awake()
    {
        _this = this;    
    }

    // Use this for initialization
    void Start () {
        //_keyFuncNormal = new KeyFuncNormal();
        //_keyFuncNormal._listKeyCode = new List<KeyCode>();
        //_keyFuncNormal._listSkelAnimName = new List<string>();
        _keyFuncNormal = DataManager._this.GetKeyFuncNormalObject();
        _listKeyFuncMulti = DataManager._this.GetKeyFuncMultiObject();
    }

    KeyCode _keyCodeSub;
    // Update is called once per frame
    void Update () {
        //재클릭 딜레이 0.5초
        if (_bReClick)
            return;

        //서브키입력이 있을때
        if (KeyCode.None != _keyCodeSub)
        {
            if (Input.GetKeyUp(_keyCodeSub))
            {
                _keyCodeSub = KeyCode.None;
                _keyFuncMulti = null;
            }

            if (KeyCode.None != _keyCodeSub)
            {
                for (int i = 0; i < _keyFuncMulti._listKeyCodeMain.Count; i++)
                {
                    //애니메이션키 입력
                    if (Input.GetKeyDown(_keyFuncMulti._listKeyCodeMain[i]))
                    {
                        _labelDebug.text = string.Format("_strSkeletonAnimationNameDouble : {0}", _keyFuncMulti._listSkelAnimName[i]);
                        Debug.Log("_strSkeletonAnimationNameDouble : " + _keyFuncMulti._listSkelAnimName[i]);

                        if (null != _skelAnim)
                            _skelAnim.AnimationName = _keyFuncMulti._listSkelAnimName[i];

                        if (!_bReClick)
                            StartCoroutine(IEDelay());
                        break;
                    }
                }
            }
        }
        else //서브키입력 없을 때 만 적용
        {
            for (int i = 0; i < _listKeyFuncMulti.Count; i++)
            {
                if (Input.GetKeyDown(_listKeyFuncMulti[i]._keyCodeSub))
                {
                    _keyCodeSub = _listKeyFuncMulti[i]._keyCodeSub;
                    _keyFuncMulti = _listKeyFuncMulti[i];
                    break;
                }
            }

            if (KeyCode.None == _keyCodeSub && !_bReClick)
            {
                for (int i = 0; i < _keyFuncNormal._listKeyCode.Count; i++)
                {
                    if (Input.GetKeyUp(_keyFuncNormal._listKeyCode[i]))
                    {
                        _labelDebug.text = string.Format("_strSkeletonAnimationName : {0}", _keyFuncNormal._listSkelAnimName[i]);
                        Debug.Log("_strSkeletonAnimationName : " + _keyFuncNormal._listSkelAnimName[i]);

                        if (null != _skelAnim)
                            _skelAnim.AnimationName = _keyFuncNormal._listSkelAnimName[i];

                        if (!_bReClick)
                            StartCoroutine(IEDelay());
                        break;
                    }
                }
            }
        }
    }

    bool _bReClick;
    IEnumerator IEDelay()
    {
        _bReClick = true;
        yield return new WaitForSeconds(0.5f);
        _keyCodeSub = KeyCode.None;
        _keyFuncMulti = null;
        _bReClick = false;

        yield break;
    }

    public void SetSkelAnimation(string strAnimationName)
    {
        if(null != _skelAnim)
            _skelAnim.AnimationName = strAnimationName;
    }
}
