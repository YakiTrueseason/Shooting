using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradePanel; // アップグレードパネルの参照

    public PlayerController player; // プレイヤーの参照

    // アップグレードパネルを表示するメソッド
    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true); 

        Time.timeScale = 0f; // ゲームを一時停止
    }

    public void UpgradeFireRate()
    {
        player.UpgradeFireRate(); // プレイヤーの弾の発射間隔を上げる

        ClosePanel(); 
    }

    public void UpgradeBulletPower()
    {
        player.UpgradeBulletPower(); // プレイヤーの弾の威力を上げる

        ClosePanel();
    }

    public void UpgradeBulletCount()
    {
        player.UpgradeBulletCount(); // プレイヤーの弾の数を増やす
        ClosePanel(); // アップグレードパネルを非表示にする
    }

    // アップグレードパネルを閉じるメソッド
    void ClosePanel()
    {
        upgradePanel.SetActive(false);

        Time.timeScale = 1f; // ゲームを再開
    }
}
