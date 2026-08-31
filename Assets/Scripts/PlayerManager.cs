//ライフ

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // シングルトンインスタンス

    public TextMeshProUGUI lifeText; // ライフ表示用のTextMeshProUGUI

    public GameObject gameOverText ; // ゲームオーバー表示用のGameObject

    public GameObject restartButton; // リスタートボタンのGameObject

    public ResultUI resultUI; //結果画面

    private int life = 5; // 初期ライフ

    private void Awake()
    {
        Instance = this; // シングルトンインスタンスを設定
    }

    private void Start()
    {
        UpdateLifeUI(); // 初期ライフ表示を更新
    }

    //ダメージ処理
    public void Damage()
    {
        
        life--;　//ライフを1減らす

        UpdateLifeUI();　//UIを更新

        if (life <= 0)
        {
            resultUI.ShowResult(); //結果画面表示
        }
    }
    void UpdateLifeUI()
    {
        lifeText.text = "Life: " + life;　// ライフ表示を更新
    }

    //プレイヤーの状態を初期状態に戻す
    public void ResetPlayer()
    {
        life = 5;

        UpdateLifeUI();

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    //ゲームオーバー処理
    private void GameOver()
    {
        gameOverText.SetActive(true); // ゲームオーバー表示を有効化
        restartButton.SetActive(true); // リスタートボタンを有効化

        Time.timeScale = 0f; // ゲームを停止
    }

    //リスタート処理
    public void RestartGame()
    {
        Time.timeScale = 1f; // ゲームを再開

        GameManager.Instance.ResetGame();

        Debug.Log("リスタート");
        Debug.Log("Stage: " + GameManager.Instance.GetStage());
        Debug.Log("BulletCount: " + GameManager.Instance.bulletCount);
        Debug.Log("BulletPower: " + GameManager.Instance.bulletPower);
        Debug.Log("FireInterval: " + GameManager.Instance.fireInterval);

        SceneManager.LoadScene("Stage1"); // ステージ1を再読み込み
    }
}
