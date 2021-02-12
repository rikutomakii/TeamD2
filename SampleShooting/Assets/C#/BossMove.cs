using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{
    private Vector3 targetpos;
   
    void Start()
    {
        targetpos = transform.position;
    }

    
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 4.0f + targetpos.x, targetpos.y, targetpos.z);
    }
}

