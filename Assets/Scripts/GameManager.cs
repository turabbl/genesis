using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    int currentscore;

    private void Start()
    {
        currentscore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore",0).ToString();
        SetScore();
    }

    private void SetScore()
    {
        currentScoreText.text = currentscore.ToString();
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AddScore()
    {
        currentscore++;
        if (currentscore > PlayerPrefs.GetInt("BestScore",0))
        {
            PlayerPrefs.SetInt("BestScore",currentscore);
            bestScoreText.text = currentscore.ToString();
        }
        SetScore();
    }
}
