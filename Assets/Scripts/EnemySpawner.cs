//敵出現 いつどこに敵を出すか

using UnityEngine;
using UnityEngine.SceneManagement;

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
        string sceneName = SceneManager.GetActiveScene().name; // 現在のシーン名を取得

        // ステージ1では緑の敵のみを生成
        if (sceneName == "Stage1")
        {
            return enemyGreen; 
        }
        // ステージ2では緑と青の敵をランダムに生成
        else if (sceneName == "Stage2")
        {
            return Random.value < 0.5f
                ? enemyGreen
                : enemyBlue; 
        }
        // ステージ3では緑、青、赤の敵をランダムに生成
        else if (sceneName == "Stage3")
        {
            float rand = Random.value; // 0から1のランダムな値を生成

            if (rand < 0.4f)
            {
                return enemyGreen; // 40%の確率で緑の敵を生成
            }
            else if (rand < 0.7f)
            {
                return enemyBlue; // 30%の確率で青の敵を生成
            }
            else
            {
                return enemyRed; // 30%の確率で赤の敵を生成
            }
        }
            return enemyGreen; // デフォルトは緑の敵を生成
    }
}
