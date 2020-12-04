using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0, -0.02f, 0);
        if (transform.position.y < -10.5f)
        {
            transform.position = new Vector3(0, 10.5f, 0);
        }
    }
}
