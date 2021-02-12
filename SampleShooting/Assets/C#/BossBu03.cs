using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBu03 : MonoBehaviour
{
    public GameObject eneShot01;
    int count = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float shotSpeed = 4.0f;
        count++;
        if (count % 6 == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, 3f * count) * vec;
                vec.Normalize();
                vec = Quaternion.Euler(0, 0, (360 / 4) * i) * vec;
                vec *= shotSpeed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(eneShot01, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
    }
}
