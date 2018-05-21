using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public bool isActive = true;                //オート目パチ有効
    public SkinnedMeshRenderer EYE;             //EL_DEFへの参照
    public float ratio_Close = 85.0f;           //閉じ目ブレンドシェイプ比率
    public float ratio_HalfClose = 20.0f;       //半閉じ目ブレンドシェイプ比率
    [HideInInspector]
    public float
        ratio_Open = 0.0f;
    private bool timerStarted = false;          //タイマースタート管理用
    private bool isBlink = false;               //目パチ管理用

    public float timeBlink = 0.4f;              //目パチの時間
    private float timeRemining = 0.0f;          //タイマー残り時間

    public float threshold = 0.3f;              // ランダム判定の閾値
    public float interval = 3.0f;               // ランダム判定のインターバル
    public int Index;


    enum Status
    {
        Close,
        HalfClose,
        Open    //目パチの状態
    }


    private Status eyeStatus;   //現在の目パチステータス

    void Awake()
    {
        //ref_SMR_EYE_DEF = GameObject.Find("EYE_DEF").GetComponent<SkinnedMeshRenderer>();
        //ref_SMR_EL_DEF = GameObject.Find("EL_DEF").GetComponent<SkinnedMeshRenderer>();
    }



    // Use this for initialization
    void Start()
    {
        ResetTimer();
        // ランダム判定用関数をスタートする
        StartCoroutine("RandomChange");
    }

    //タイマーリセット
    void ResetTimer()
    {
        timeRemining = timeBlink;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStarted)
        {
            eyeStatus = Status.Close;
            timerStarted = true;
        }
        if (timerStarted)
        {
            timeRemining -= Time.deltaTime;
            if (timeRemining <= 0.0f)
            {
                eyeStatus = Status.Open;
                ResetTimer();
            }
            else if (timeRemining <= timeBlink * 0.3f)
            {
                eyeStatus = Status.HalfClose;
            }
        }
    }

    void LateUpdate()
    {
        if (isActive)
        {
            if (isBlink)
            {
                switch (eyeStatus)
                {
                    case Status.Close:
                        SetCloseEyes();
                        break;
                    case Status.HalfClose:
                        SetHalfCloseEyes();
                        break;
                    case Status.Open:
                        SetOpenEyes();
                        isBlink = false;
                        break;
                }
                //Debug.Log(eyeStatus);
            }
        }
    }

    void SetCloseEyes()
    {
        EYE.SetBlendShapeWeight(Index, ratio_Close);
    }

    void SetHalfCloseEyes()
    {
        EYE.SetBlendShapeWeight(Index, ratio_HalfClose);
    }

    void SetOpenEyes()
    {
        EYE.SetBlendShapeWeight(Index, ratio_Open);
    }

    // ランダム判定用関数
    IEnumerator RandomChange()
    {
        // 無限ループ開始
        while (true)
        {
            //ランダム判定用シード発生
            float _seed = Random.Range(0.0f, 1.0f);
            if (!isBlink)
            {
                if (_seed > threshold)
                {
                    isBlink = true;
                }
            }
            // 次の判定までインターバルを置く
            yield return new WaitForSeconds(interval);
        }
    }
}
