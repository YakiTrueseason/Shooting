//ゲーム全体の一括管理　

using UnityEngine;

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
    public void NextStage()
    {
        currentStage++;
    }

    //ゲームをはじめからやり直す
    public void ResetGame()
    {
        bulletCount = 1;
        bulletPower = 1;
        fireInterval = 0.5f;
    }
}
