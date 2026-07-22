using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ

    public float interval = 2f; // 敵を生成する間隔

    private float timer; // タイマー

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // タイマーを更新

        if (timer > interval)
        {
            timer = 0f;

            Vector3 pos  = new Vector3(Random.Range(-5f, 5f), 7f, 0f); // 生成位置をランダムに決定

            Instantiate(enemyPrefab, pos, Quaternion.identity); // 敵を生成
        }
    }
}
