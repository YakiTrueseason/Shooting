//レベル上げ

using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // シングルトンインスタンス

    public TextMeshProUGUI levelText; // レベル表示用のTextMeshProUGUI

    private int level = 1; // 初期レベル

    private void Awake()
    {
        Instance = this; // シングルトンインスタンスを設定
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI(); // 初期レベル表示を更新
    }

    public void CheckLevel(int score)
    {
        int newLevel = score / 500 + 1; // スコアに応じてレベルを計算（例: 500点ごとにレベルアップ）
        if (newLevel != level)
        {
            level = newLevel;
            UpdateUI(); // UIを更新
        }    
    }

    // Update is called once per frame
    void UpdateUI()
    {
        levelText.text = "Level: " + level; // レベル表示を更新
    }
    public int GetLevel()
    {
        return level; // 現在のレベルを返す
    }   
}
