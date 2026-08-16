//敵出現 いつどこに敵を出すか

using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyGreen; 
    public GameObject enemyBlue;
    public GameObject enemyRed;

    public StageEnemySetting[] stageSettings;

    private float timer = 0f; // タイマー

    void Update()
    {
        timer += Time.deltaTime; // タイマーを更新

        // レベルに応じて生成間隔を調整
        if (timer > GetSpawnInterval())
        {
            timer = 0f; // タイマーをリセット

            Vector3 pos  = new Vector3(Random.Range(-5f, 5f), 5f, 0f); // 生成位置をランダムに決定

            Instantiate(GetEnemyPrefab(), pos, Quaternion.identity); // 敵を生成
        }
    }
    // レベルに応じて生成間隔を調整するメソッド
    float GetSpawnInterval()
    {
        int stage = GameManager.Instance.GetStage(); 

        float interval = 5.0f - (stage - 1) * 2.5f; // レベルが上がるごとに生成間隔を短くする（最小1秒）

        return Mathf.Clamp(interval, 1f, 3f); // 生成間隔を1秒から3秒の範囲に制限
    }

    // レベルに応じて生成する敵の種類を決定するメソッド
    GameObject GetEnemyPrefab()
    {
        int stage = GameManager.Instance.GetStage();

        int index = stage - 1;

        if (index < 0 || index >= stageSettings.Length)
        {
            return enemyGreen;
        }

        StageEnemySetting setting = stageSettings[index];

        //出現可能な敵をリスト化
        System.Collections.Generic.List<GameObject> enemies =
            new System.Collections.Generic.List<GameObject>();

        if (setting.green)
        {
            enemies.Add(enemyGreen);
        }
        if (setting.blue)
        {
            enemies.Add(enemyBlue);
        }
        if (setting.red)
        {
            enemies.Add(enemyRed);
        }

        //敵が1種類も設定されていない場合
        if (enemies.Count == 0)
        {
            return enemyGreen;
        }

        //設定された敵からランダムに選ぶ
        return enemies[Random.Range(0, enemies.Count)];
    }
}
