using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradePanel; // アップグレードパネルの参照

    public GameObject levelUpPanel; // レベルアップパネルの参照

    public PlayerController player; // プレイヤーの参照

    // アップグレードパネルを表示するメソッド
    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true); 
        levelUpPanel.SetActive(false);

        Time.timeScale = 0f; // ゲームを一時停止
    }

    public void UpgradeFireRate()
    {
        player.UpgradeFireRate(); // プレイヤーの弾の発射間隔を上げる

        CloseChoicePanel(); 
    }

    public void UpgradeBulletPower()
    {
        player.UpgradeBulletPower(); // プレイヤーの弾の威力を上げる

        CloseChoicePanel();
    }

    public void UpgradeBulletCount()
    {
        player.UpgradeBulletCount(); // プレイヤーの弾の数を増やす

        CloseChoicePanel(); 
    }

    // アップグレードパネルを閉じるメソッド
    void CloseChoicePanel()
    {
        upgradePanel.SetActive(false);

        levelUpPanel.SetActive(true);
    }
}
