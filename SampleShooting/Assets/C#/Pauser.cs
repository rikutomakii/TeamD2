using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pauser : MonoBehaviour
{

    static List<Pauser> targets = new List<Pauser>();   // ポーズ対象のスクリプト
    //public bool jikanteisi=false;
    Behaviour[] pauseBehavs = null; // ポーズ対象のコンポーネント

    // 初期化
    void Start()
    {
        // ポーズ対象に追加する
        targets.Add(this);
        //Pauser.Pause();
    }

    // 破棄されるとき
    void OnDestory()
    {
        // ポーズ対象から除外する
        targets.Remove(this);
    }

    // ポーズされたとき
    void OnPause()
    {
        if (pauseBehavs != null)
        {
            return;
        }

        // 有効なBehaviourを取得
        pauseBehavs = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => { return obj.enabled; });

        foreach (var com in pauseBehavs)
        {
            com.enabled = false;
        }
        //jikanteisi = true;
        //Debug.Log("trueになったよ");

    }

    // ポーズ解除されたとき
    void OnResume()
    {
        if (pauseBehavs == null)
        {
            return;
        }

        // ポーズ前の状態にBehaviourの有効状態を復元
        foreach (var com in pauseBehavs)
        {
            com.enabled = true;
        }
        //jikanteisi = false;
        //Debug.Log("解除になったよ");
        pauseBehavs = null;
    }

    // ポーズ
    public static void Pause()
    {
        foreach (var obj in targets)
        {
            obj.OnPause();
        }
    }

    // ポーズ解除
    public static void Resume()
    {
        foreach (var obj in targets)
        {
            obj.OnResume();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pauser.Resume();
            Debug.Log("trueになったよ");
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && jikanteisi == false)
        //{
        //    Pause();
        //}
        //else
        //{
        //    Resume();
        //}
    }
}