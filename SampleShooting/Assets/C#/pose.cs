using UnityEngine;
using System.Collections;


public class pose: MonoBehaviour
{

    private bool pauseGame = false;

    void Start()
    {
        OnUnPause();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
            }
            else
            {
                OnUnPause();
            }
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        pauseGame = true;
    }

    public void OnUnPause()
    {
        Time.timeScale = 1;
        pauseGame = false;
    }
}