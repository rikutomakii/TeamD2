using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemy : MonoBehaviour
{
    int Cnt = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Cnt < 80)
        {
            transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;
        }
        if (Cnt > 80 + 240)
        {
            transform.position += new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime;
        }
        Cnt++;
        if (CUtility.IsOut(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
