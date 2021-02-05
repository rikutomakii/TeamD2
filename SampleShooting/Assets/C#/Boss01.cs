﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Boss01 : MonoBehaviour
{
    public GameObject eneShot01;
    int count = 0;
    Slider _slider;
    int Life = 60;
    // Start is called before the first frame update
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float shotSpeed = 4.0f;
        count++;
        if (count % 4 == 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            _slider.value = Life;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
