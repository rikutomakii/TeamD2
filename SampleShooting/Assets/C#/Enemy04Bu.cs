using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy04Bu : MonoBehaviour
{
    //プレイヤーオブジェクト
    public GameObject player;
    //弾のプレハブオブジェクト
    public GameObject tama;

    //1秒ごとに弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                //敵の座標を変数posに保存
                var pos = this.gameObject.transform.position;
                //弾のプレハブを作成
                var t = Instantiate(tama) as GameObject;
                //弾のプレハブの位置を敵の位置にする
                t.transform.position = pos;
                //敵からプレイヤーに向かうベクトルを作る
                //プレイヤーの位置から敵の位置(弾の位置)を引く
                Vector2 vec = player.transform.position - pos;
                //弾のRigidBody2Dコンポーネントのvelocity先ほど求めたベクトルを入れて力を加える
                t.GetComponent<Rigidbody2D>().velocity = vec;

            }

        }
        else
        {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                Debug.Log("Down");
                currentTime = 0;
                //敵の座標を変数posに保存
                var pos = this.gameObject.transform.position;
                //弾のプレハブを作成
                var t = Instantiate(tama) as GameObject;
                
               // t.transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;

                //弾のプレハブの位置を敵の位置にする
                t.transform.position = pos;
                Vector2 vec = t.transform.position;
                //弾のRigidBody2Dコンポーネントのvelocity先ほど求めたベクトルを入れて力を加える
                t.transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;
                // t.GetComponent<Rigidbody2D>().velocity = vec;


            }
        }
    }
}
