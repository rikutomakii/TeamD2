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
        //fade
        FadeScript.instance.FadeOutToIn(SceneToSelect);
        //クリック音
        audioSource.PlayOneShot(ClickSE);
    }
    void SceneToSelect()
    {
        //メインシーン移動
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
