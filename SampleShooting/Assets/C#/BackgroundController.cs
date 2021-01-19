using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0, -0.05f, 0);
        if (transform.position.y < -6.2f)
        {
            transform.position = new Vector3(-1.8f, 9.4f, 0);
        }
    }
}
