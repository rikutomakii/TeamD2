using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void OnClickStartButton()
    {
        FadeScript.instance.FadeOutToIn(SceneToSelect);
    }
    void SceneToSelect()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
