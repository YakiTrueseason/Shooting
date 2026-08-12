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
        //Debug.Log("スコア加算: " + points); // デバッグ用に加算するスコアを表示"

        score += points; // スコアを加算

        scoreText.text = "Score: " + score; // スコア表示を更新
    }
}
