using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXMove : MonoBehaviour
{
    [Range(0, 50)]
    public float moveDistance;
    private Vector3 pos;
    private bool isReturn = false;
    int Life = 10;
    private void Update()
    {
        pos = transform.position;

        if (pos.y > 0 && isReturn == false)
        {
            // Translate(x軸, y軸, z軸)
            // x軸がプラス　→方向のベクトル
            // z軸がマイナス　↓方向のベクトル
            // この２つのベクトルを合成すると「↘️」方向のベクトルになる。（→ ＋ ↓ ＝ ↘️）
            transform.Translate(moveDistance * Time.deltaTime, 0, -moveDistance * Time.deltaTime, Space.World);
        }
        else // pos.zが1以下になった時、進行方向を変化させる。
        {
            isReturn = true;

            // x軸がプラス　→方向のベクトル
            // z軸がマイナス　↑方向のベクトル
            // この２つのベクトルを合成すると「↗️」方向のベクトルになる。（→ ＋ ↑ ＝ ↗️）
            transform.Translate(moveDistance * Time.deltaTime, 0, moveDistance * Time.deltaTime, Space.World);
        }
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

