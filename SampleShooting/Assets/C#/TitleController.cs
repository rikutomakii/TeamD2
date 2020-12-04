using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip ClickSE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickStartButton()
    {
        FadeScript.instance.FadeOutToIn(SceneToSelect);
        audioSource.PlayOneShot(ClickSE);
    }
    void SceneToSelect()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
