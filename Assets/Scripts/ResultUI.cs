//結果画面

using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public GameObject resultPanel;

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI levelText; 
    public TextMeshProUGUI defeatedText; 

    public void ShowResult()
    {
        Time.timeScale = 0f;

        resultPanel.SetActive(true);

        //最終スコア
        int score = ScoreManager.Instance.GetScore();
        //到達レベル
        int level = LevelManager.Instance.GetLevel();
        //突破数
        int defeated = ScoreManager.Instance.GetDefeatedCount();

        scoreText.text =  "SCORE: " + score;
        levelText.text = "LEVEL: " + level;
        defeatedText.text = "DEFEATED " + defeated;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;

        ScoreManager.Instance.ResetScore();

        SceneManager.LoadScene("Stage1");
    }
}
