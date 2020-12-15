using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBu02 : MonoBehaviour
{
    public GameObject EneShot02;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float ShotSpeed = 6.0f;
        int wayNum = 5;
        float angle = 30.0f;
        count++;
        if(count % 60 == 0)
        {
            for(int i = 0; i < wayNum; i++)
            {
                Vector2 vec = pos - transform.position;
                vec.Normalize();
                float anglePerShot = angle / (wayNum - 1);
                vec = Quaternion.Euler(0, 0, anglePerShot * i - angle / 2.0f) * vec;
                vec *= ShotSpeed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(EneShot02, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
    }
}
