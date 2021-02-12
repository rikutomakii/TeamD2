﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBu01 : MonoBehaviour
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
            float shotSpeed = 3.0f;
            count++;
            {
                Vector2 vec = new Vector2(0.0f, 1.5f);
                vec = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)) * vec;
                vec *= shotSpeed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(eneShot01, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
    }
}
