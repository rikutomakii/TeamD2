using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CEnemy : MonoBehaviour
{
    int Cnt = 0;
    int Life = 60;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    //GameObject newParent = new GameObject();
    // Update is called once per frame
    void Update()
    {
        if (Cnt < 100)
        {
            transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;
        }
        if (Cnt == 300)
        {
            GameObject.Find("GameManager").GetComponent<CGameManager>().BulletFactory[3].CreateBullet(transform.position, 0);
        }
        if (Cnt > 100 + 240)
        {
            transform.position += new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime;
        }
        Cnt++;
        if (CUtility.IsOut(transform.position))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
      
        Destroy(gameObject);
        gameController.AddScore();
        if (collision.gameObject.tag == "Shot")
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
