//スコア

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 

    public TextMeshProUGUI scoreText;

    public int score = 0;
    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points; // スコアを加算

        scoreText.text = "Score: " + score; // スコア表示を更新

        LevelManager.Instance.CheckLevel(score); // レベルをチェック
    }
}
