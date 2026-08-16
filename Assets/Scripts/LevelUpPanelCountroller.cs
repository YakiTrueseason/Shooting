//次のステージへ遷移　レベルアップ　

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
        GameManager.Instance.NextStage(); //次のステージ番号にする

        Time.timeScale = 1f; // ゲームを再開

        //次のステージを読み込む
        SceneManager.LoadScene(
            "Stage" + GameManager.Instance.GetStage()
         );  
    }
}
