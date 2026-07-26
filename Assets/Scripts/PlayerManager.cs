using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//ライフ
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // シングルトンインスタンス

    public TextMeshProUGUI lifeText; // ライフ表示用のTextMeshProUGUI

    public GameObject gameOverText ; // ゲームオーバー表示用のGameObject

    public GameObject restartButton; // リスタートボタンのGameObject

    private int life = 3; // 初期ライフ

    private void Awake()
    {
        Instance = this; // シングルトンインスタンスを設定
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            GameOver(); // ライフが0以下になった場合、ゲームオーバー処理を呼び出す
        }
    }
    void UpdateLifeUI()
    {
        lifeText.text = "Life: " + life;　// ライフ表示を更新
    }

    //ゲームオーバー処理
    private void GameOver()
    {
        gameOverText.SetActive(true); // ゲームオーバー表示を有効化
        restartButton.SetActive(true); // リスタートボタンを有効化

        Time.timeScale = 0f; // ゲームを停止

        Debug.Log("Game Over");
    }
    //リスタート処理
    public void RestartGame()
    {
        Time.timeScale = 1f; // ゲームを再開
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 現在のシーンを再読み込み
    }
}
