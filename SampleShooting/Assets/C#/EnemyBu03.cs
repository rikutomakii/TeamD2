using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBu03 : MonoBehaviour
{
    public GameObject player;
    public GameObject EneShot03;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float shotSpeed = 8.0f;
        if(count % 20 == 0)
        {
            for(int i = 0; i <24; i++)
            {
                Vector2 vec = player.transform.position - transform.position;
                vec.Normalize();
                //24分割
                vec = Quaternion.Euler(0, 0, (360 / 24) * i) * vec;
                vec *= shotSpeed;
                var t = Instantiate(EneShot03, transform.position, EneShot03.transform.rotation);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
        count++;
    }
}
