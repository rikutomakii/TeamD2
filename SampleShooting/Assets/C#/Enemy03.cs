using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{
    int Life = 60;
    int Count = 0;
    public float wave = 0.1f;
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
            }
            Destroy(collision.gameObject);
        }
    }
}
