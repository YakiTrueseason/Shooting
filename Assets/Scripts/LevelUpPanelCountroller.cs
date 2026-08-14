using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpPanelCountroller : MonoBehaviour
{
    public GameObject levelUpPanel; // レベルアップパネルのGameObject

    // レベルアップパネルを表示するメソッド
    public void CountinueStage()
    {
        levelUpPanel.SetActive(false);

        Time.timeScale = 1f; // ゲームを再開
    }

    // 次のステージに遷移するメソッド
    public void NextStage()
    {
        Time.timeScale = 1f; // ゲームを再開

        string currentSceneName = SceneManager.GetActiveScene().name; // 現在のシーン名を取得

        if(currentSceneName == "Stage1")
        {
            SceneManager.LoadScene("Stage2"); // ステージ1からステージ2に遷移
        }
        else if (currentSceneName == "Stage2")
        {
            SceneManager.LoadScene("Stage3"); // ステージ2からステージ3に遷移
        }   
    }
}
