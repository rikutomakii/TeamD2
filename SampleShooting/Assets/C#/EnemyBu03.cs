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
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float shotSpeed = 4.0f;
            if (count % 80 == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Vector2 vec = player.transform.position - transform.position;
                    vec.Normalize();
                    // 6分割
                    vec = Quaternion.Euler(0, 0, (360 / 6) * i) * vec;
                    vec *= shotSpeed;
                    var t = Instantiate(EneShot03, transform.position, EneShot03.transform.rotation);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
            count++;
        }
        else
        {
            Debug.Log("Down");
        }
       
    }
}
