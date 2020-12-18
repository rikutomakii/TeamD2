using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject LifePoint1;
    public GameObject LifePoint2;
    public GameObject LifePoint3;

    private float interval;
    private float time = 0f;
    float LifeCount = 3.0f;
    //AudioSource audioSource;
    //public AudioClip shotSE;

    void Start()
    {
        interval = 0.1f;
    }

    // Update is called once per frame

    //移動処理
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 8f;
        nextPosition = new Vector3(
            //移動範囲
            Mathf.Clamp(nextPosition.x, -5.45f, 1.83f),
            Mathf.Clamp(nextPosition.y, -4f, 3.8f),
            nextPosition.z
            );
        transform.position = nextPosition;

        //弾自動生成
        time += Time.deltaTime;
        if (time > interval)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = nextPosition;
            time = 0f;
        }

        //ライフカウントが減るか仮実装
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    LifeCount--;
        //    if (LifeCount == 2.0f)
        //    {
        //        Destroy(LifePoint3);
        //    }
        //    else if (LifeCount == 1.0f)
        //    {
        //        Destroy(LifePoint2);
        //    }
        //    else if (LifeCount == 0.0f)
        //    {
        //        Destroy(LifePoint1);
        //    }
        //    //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //    //audioSource.PlayOneShot(shotSE)
        //}
    }

    //ライフカウントの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            LifeCount--;
            if(LifeCount==2.0f)
            {
                Destroy(LifePoint3);
            }
            else if(LifeCount == 1.0f)
            {
                Destroy(LifePoint2);
            }
            else if(LifeCount == 0.0f)
            {
                Destroy(LifePoint1);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //fade
                FadeScript.instance.FadeOutToIn(SceneToSelect);
            }
            void SceneToSelect()
            {
                //メインシーン移動
                SceneManager.LoadScene("Result", LoadSceneMode.Single);
            }
        }
    }
}
