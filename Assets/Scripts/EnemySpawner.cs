//敵出現 いつどこに敵を出すか

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ

    private float timer = 0f; // タイマー

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // タイマーを更新
        // レベルに応じて生成間隔を調整
        if (timer > GetSpawnInterval())
        {
            timer = 0f; // タイマーをリセット

            Vector3 pos  = new Vector3(Random.Range(-5f, 5f), 7f, 0f); // 生成位置をランダムに決定

            Instantiate(enemyPrefab, pos, Quaternion.identity); // 敵を生成
        }
    }
    // レベルに応じて生成間隔を調整するメソッド
    float GetSpawnInterval()
    {
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得

        float interval = 5.0f - (level - 1) * 0.5f; // レベルに応じて生成間隔を調整（例: レベルが上がるごとに0.2秒短くなる）)

        return Mathf.Clamp(interval, 1f, 5f); // レベルに応じて生成間隔を調整（最小1秒）
    }       
}
