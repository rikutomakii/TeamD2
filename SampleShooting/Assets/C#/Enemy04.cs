using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04 : MonoBehaviour
{
    int Life = 60;

    private float speed;                //オブジェクトのスピード
    private int radius;               //円を描く半径
    private Vector3 defPosition;      //defPositionをVector3で定義する。
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
        radius = 2;

        defPosition = transform.position;    //defPositionを自分のいる位置に設定する。
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);      //X軸の設定
        y = radius * Mathf.Tan(Time.time * speed);      //Y軸の設定

        transform.position = new Vector3(x + defPosition.x, y+defPosition.y);  //自分のいる位置から座標を動かす。

        if (CUtility.IsOut(transform.position))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
