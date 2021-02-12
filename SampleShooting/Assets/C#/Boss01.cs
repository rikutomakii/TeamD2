using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss01 : MonoBehaviour
{
    public GameObject eneShot01;
    public GameObject eneShot03;
    int count = 0;
    Slider _slider;
    int Life = 60;
    int Loop = 0;
    public GameObject player;
    public GameObject eneShot02;
    private Vector3 targetpos;
    int count2 = 0;
    int count3 = 0;
    float Inter = 0.0f;
    int Muteki = 0;
    // Start is called before the first frame update
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        player = GameObject.Find("Player");
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Loop == 0)
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
        if (Loop == 1)
        {
            Inter++;
            Muteki = 1;
            if (Inter >=80) {
                Muteki = 0;
                float shotSpeed2 = 3.0f;
                if (count2 % 40 == 0)
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
        if(Loop == 2)
        {
            Inter++;
            Muteki = 1;
            if (Inter >= 80)
            {
                Muteki = 0;
                transform.position = new Vector3(Mathf.Sin(Time.time) * 4.0f + targetpos.x, targetpos.y, targetpos.z);
                float shotSpeed3 = 3.0f;
                count3++;
                {
                    Vector2 vec = new Vector2(0.0f, 1.5f);
                    vec = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)) * vec;
                    vec *= shotSpeed3;
                    var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                    var t = Instantiate(eneShot03, transform.position, q);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot"&& Muteki ==0)
        {
            Life -= collision.GetComponent<CShot>().ShotPower;
            _slider.value = Life;
            if (Life <= 0 && Loop == 0)
            {
                Life = 100;
                Loop = 1;
                // Destroy(gameObject);
            }
            if (Life <= 0 && Loop == 1)
            {
                Life = 60;
                Inter = 0;
                Loop = 2;
            }
            if (Life <= 0 && Loop == 2)
            {
                SceneManager.LoadScene("GameClear_Scene");
            }
            Destroy(collision.gameObject);
        }
    }
}
