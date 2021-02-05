using System.Collections;
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
    int Loop = 0;
    public GameObject player;
    public GameObject eneShot02;
    int count2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Loop == 0)
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
        if(Loop == 1)
        {
            float shotSpeed2 = 3.0f;
            if (count2 % 30 == 0)
            {
                for (int i = 0; i < 24; i++)
                {
                    Vector2 vec = player.transform.position - transform.position;
                    vec.Normalize();
                    vec = Quaternion.Euler(0, 0, (360 / 24) * i) * vec;
                    vec *= shotSpeed2;
                    // atan2 でベクトル から角度を求める．それをラジアンからディグリーにして，更にクォータニオンにする．
                    var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                    var t = Instantiate(eneShot02, transform.position, q);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
            count2++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            _slider.value = Life;
            if (Life <= 0 && Loop == 0)
            {
                Loop = 1;
                Life = 60;
                // Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
