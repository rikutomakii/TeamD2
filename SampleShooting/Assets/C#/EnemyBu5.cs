using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBu5 : MonoBehaviour
{
    public GameObject player;
    public GameObject eneShot01;
    int count = 0;
    float result;

    // Use this for initialization
    void Start()
    {
        // とりあえずここで自機のオブジェクトを見つける
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float shotSpeed = 4.0f;
        if (count % 60 == 0)
        {
            Vector2 vec = player.transform.position - transform.position;
            vec.Normalize();
            vec *= shotSpeed;
            var t = Instantiate(eneShot01, transform.position, eneShot01.transform.rotation);
            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
        count++;
       
    }
}
