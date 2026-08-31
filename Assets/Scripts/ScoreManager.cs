//スコア

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    private int defeatedCount = 0; //突破数

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points; // スコアを加算

        defeatedCount++;
    }

    //結果
    public int GetScore()
    {
        return score;
    }

    public int GetDefeatedCount()
    {
        return defeatedCount;
    }

    //リセット
    public void ResetScore()
    {
        score = 0;

        defeatedCount = 0;
    }
}
