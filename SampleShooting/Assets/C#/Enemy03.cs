﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{
    int Life = 5;
    int Count = 0;
    public float wave = 0.1f;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count++;
        if (Count >0)
        {
            transform.position += new Vector3(3.0f, 0.0f, 0.0f) * Time.deltaTime;
        }

        if (CUtility.IsOut(transform.position))
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x
   , 2.5f + Mathf.Sin(Time.frameCount * wave));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            if (Life <= 0)
            {
                Destroy(gameObject);
                // 敵を破壊した瞬間＝敵のHPが0になった瞬間にアイテムプレハブを実体化させる。
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }
    }
}
