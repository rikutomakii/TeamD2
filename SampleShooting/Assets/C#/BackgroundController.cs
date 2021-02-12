using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.Translate(0, -0.01f, 0);
        if (transform.position.y < -6.2f)
        {
            transform.position = new Vector3(-1.8f, 9.4f, 0);
        }
    }
}
