using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBu01 : MonoBehaviour
{
    public GameObject EneShot01;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float ShotSpeed = 8.0f;
        if(count %6 == 0)
        {
            for(int i = 0; i < 12; i++)
            {
                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, 0.2f * count) * vec;
                vec.Normalize();
                vec = Quaternion.Euler(0, 0, (360 / 12) * i) * vec;
                vec *= ShotSpeed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x,vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(EneShot01, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
        count++;
        if (CUtility.IsOut(transform.position))
        {
            Destroy(EneShot01);
        }
    }
}
