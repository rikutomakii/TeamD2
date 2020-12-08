using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float interval;
    private float time = 0f;
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
            Mathf.Clamp(nextPosition.x, -5.0f, 5.0f),
            Mathf.Clamp(nextPosition.y, -4f, 4.0f),
            nextPosition.z
            );
        transform.position = nextPosition;

        time += Time.deltaTime;

        if(time>interval)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = nextPosition;
            time = 0f;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //    //audioSource.PlayOneShot(shotSE);
        //}
    }
}
