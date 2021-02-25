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

    //
    public bool on_damage = false;       //ダメージフラグ
    public bool isMuteki= false;     //無敵時間 
    private SpriteRenderer renderer;

    private float interval;
    private float time = 0f;
    private int timeCount;
    float LifeCount = 3.0f;
    //AudioSource audioSource;
    //public AudioClip shotSE;

    void Start()
    {
        interval = 0.075f;
        //
        //点滅処理の為に呼び出しておく
        renderer = gameObject.GetComponent<SpriteRenderer>();

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
            Mathf.Clamp(nextPosition.x, -5.77f, 2.27f),
            Mathf.Clamp(nextPosition.y, -2.77f, 4.82f),
            nextPosition.z
            );
        transform.position = nextPosition;

        //弾生成
        time += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if (time > interval)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = nextPosition;
                time = 0f;
            }
        }
        //time += Time.deltaTime;
        //if (time > interval)
        //{
        //    GameObject bullet = Instantiate(bulletPrefab);
        //    bullet.transform.position = nextPosition;
        //    time = 0f;
        //}

        //
        // ダメージフラグがtrueで有れば点滅させる
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
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

    //
    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(2.0f);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        isMuteki = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    //
    void OnDamageEffect()
    {
        // ダメージフラグON
        on_damage = true;
        isMuteki = true;
        // コルーチン開始
        StartCoroutine("WaitForIt");
    }


    //ライフカウントの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet"&& isMuteki == false)
        {
            LifeCount--;
            if(LifeCount==2.0f)
            {
                Destroy(LifePoint3);
                OnDamageEffect();

            }
            else if(LifeCount == 1.0f)
            {
                Destroy(LifePoint2);
                OnDamageEffect();
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
