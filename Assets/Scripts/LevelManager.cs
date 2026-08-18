//レベル上げ

using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // シングルトンインスタンス

    public TextMeshProUGUI levelText; // レベル表示用のTextMeshProUGUI

    public UpgradeManager upgradeManager; // アップグレードマネージャーの参照

    public GameObject levelUpPanel; // レベルアップパネル

    public int maxLevel = 3; //最大レベル

    public PowerUpDisplay powerUpDisplay; //強化表示

    private int level = 1; // 初期レベル

    private int exp = 0; // 経験値（スコア）

    private int requiredExp = 5; // レベルアップに必要な経験値

    // シングルトンパターンの実装
    private void Awake()
    {
        Instance = this; 
    }

    // 現在のレベルを取得するメソッド
    public int GetLevel()
    {
        return level; 
    }

    // 現在の経験値を取得するメソッド
    public int GetExp() 
    { 
        return exp; 
    }

    //  レベルアップに必要な経験値を取得するメソッド
    public int GetRequiredExp()
    {
        return requiredExp;
    }

    // 初期化処理
    void Start()
    {
        UpdateUI(); 
    }

    // UIを更新するメソッド
    void UpdateUI()
    {
        levelText.text = "Level: " + level; 
    }

    // 経験値を加算するメソッド
    public void AddExp(int amount)
    {
        //最大レベルなら経験値を増やさない
        if (level >= maxLevel)
        {
            return;
        }

        exp += amount;

        Debug.Log("EXP: " + exp + "/" + requiredExp); // デバッグ用に経験値とレベルを表示

        // レベルアップ可能かどうかを判定し、可能であればレベルアップ処理を行う
        if (CanLevelUp())
        {
            LevelUp();
        }
    }

    // レベルアップ可能かどうかを判定するメソッド
    public bool CanLevelUp()
    {
        return exp >= requiredExp; 
    }

    // レベルアップ処理を行うメソッド
    public void LevelUp()
    {
        if (!CanLevelUp())
        {
            return; // レベルアップできない場合は処理を中断
        }
            exp -= requiredExp; // 経験値を減らす

            level++; // レベルを1上げる

            requiredExp += 10
            ; // 次のレベルアップに必要な経験値を増やす

            UpdateUI(); // UIを更新

            Debug.Log("Level Up! New Level: " + level); // デバッグ用にレベルアップを表示

            powerUpDisplay.ShowPowerUp("LEVEL UP!!"); //強化表示

            upgradeManager.ShowUpgradePanel(); // アップグレードパネルを表示
    }
}
