using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBu02 : MonoBehaviour
{
    public GameObject player;
    public GameObject eneShot02;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float shotSpeed = 3.0f;
        if (count % 30 == 0)
        {
            for (int i = 0; i < 24; i++)
            {
                Vector2 vec = player.transform.position - transform.position;
                vec.Normalize();
                vec = Quaternion.Euler(0, 0, (360 / 24) * i) * vec;
                vec *= shotSpeed;
                // atan2 でベクトル から角度を求める．それをラジアンからディグリーにして，更にクォータニオンにする．
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(eneShot02, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
        count++;
    }
}
