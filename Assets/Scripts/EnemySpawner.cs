//敵出現 いつどこに敵を出すか

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyGreen; 
    public GameObject enemyBlue;
    public GameObject enemyRed;

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
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得

        float interval = 5.0f - (level - 1) * 2.5f; // レベルが上がるごとに生成間隔を短くする（最小1秒）

        return Mathf.Clamp(interval, 1f, 3f); // 生成間隔を1秒から3秒の範囲に制限
    }
    // レベルに応じて生成する敵の種類を決定するメソッド
    GameObject GetEnemyPrefab()
    {
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得
        if (level < 2)
        {
            return enemyGreen; // レベル1では緑の敵
        }
        else if (level < 3)
        {
            return Random.value < 0.5f ? enemyGreen : enemyBlue; // レベル2では緑と青の敵を50%ずつ
        }
        else
        {
            float rand = Random.value;
            if (rand < 0.4f)
            {
                return enemyGreen; // 40%の確率で緑の敵
            }
            else if (rand < 0.8f)
            {
                return enemyBlue; // 40%の確率で青の敵
            }
            else
            {
                return enemyRed; // 20%の確率で赤の敵
            }
        }
    }
}
