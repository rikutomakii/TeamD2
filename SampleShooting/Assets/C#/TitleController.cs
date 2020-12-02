using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void OnClickStartButton()
    {
        FadeScript.instance.FadeOut();
        SceneManager.LoadScene("CharacterSelect");
    }
}
