// 敵がどう動くか (緑)

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f; // 敵の移動速度

    public int hp = 1; // 敵の体力

    public int score = 100; // 敵を倒したときのスコア

    void Start()
    {
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得

        speed = Mathf.Clamp(2f * (level - 1) * 1f, 3f, 10f); // レベルに応じて速度を調整（最小3、最大10）
    }
    void Update()
    {
        // 下方向へ移動
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 画面外へ行ったら削除
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
    // 弾と衝突したときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 弾と衝突したら削除
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 弾を削除
            // 敵の体力を減らす
             hp --;
            // 敵の体力が0以下になったらスコアを加算して敵を削除
            if (hp <= 0)
            {
                ScoreManager.Instance.AddScore(score);

                Destroy(gameObject);
            }
        }
    }
}
