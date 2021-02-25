using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearResultButton : MonoBehaviour
{
    //public Text HighScoreText;
    ////public Text gekiha;

    //int score;

    //void Start()
    //{
    //    score = TargetGene.getscore();
    //    HighScoreText.text = string.Format("Score:{0}",score);
    //}

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
