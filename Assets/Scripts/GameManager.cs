//ゲーム全体の一括管理　

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    //プレイヤー強化
    public int bulletCount = 1;
    public int bulletPower = 1;
    public float fireInterval = 0.5f;
    //現在のステージ
    public int currentStage = 1;

    private void Awake()
    {
        //GameManagerがすでに存在する場合
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //Sceneを移動してもGameManagerを残す
        DontDestroyOnLoad(gameObject);
    }

    //弾の発射間隔を短くするメソッド
    public void UpgradeFireRate()
    {
        fireInterval -= 0.1f; //弾の発射間隔を短くする

        if (fireInterval < 0.1f) //最小値を設定
        {
            fireInterval = 0.1f;
        }
    }

    //弾の威力を上げるメソッド
    public void UpgradeBulletPower()
    {
        bulletPower++;
    }

    //弾の数を増やすメソッド
    public void UpgradeBulletCount()
    {
        bulletCount++;
    }

    //Stageを取得
    public int GetStage()
    {
        return currentStage;
    }

    //Stageを進める
    public bool NextStage()
    {
       //Stage3が最終ステージ
       if(currentStage >= 3)
        {
            return false;
        }
        currentStage++;

        return true;
    }

    //ゲームをリセット
    public void ResetGame()
    {
        //プレイヤー強化、初期状態に戻す
        bulletCount = 1;
        bulletPower = 1;
        fireInterval = 0.5f;

        //ステージリセット
        currentStage = 1;

        //プレイヤーリセット
        if (PlayerManager.Instance != null)
        {
            PlayerManager.Instance.ResetPlayer();
        }

        //レベル・EXPリセット
        if(LevelManager.Instance != null)
        {
            LevelManager.Instance.ResetLevel();
        }

        //スコアリセット
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }
    }
}
