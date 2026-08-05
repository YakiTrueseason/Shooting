// 敵がどう動くか

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f; // 敵の移動速度

    void Start()
    {
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得
        speed = Mathf.Clamp(3f * (level - 1) * 1.5f, 3f, 15f); // レベルに応じて速度を調整（最小3、最大15）
    }
    // Update is called once per frame
    void Update()
    {
        // 下方向へ移動
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 画面外へ行ったら削除
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 弾と衝突したら削除
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 弾を削除
            ScoreManager.Instance.AddScore(100); // スコアを加算
            Destroy(gameObject); // 敵を削除
        }
    }
}
