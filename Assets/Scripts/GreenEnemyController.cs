// 敵がどう動くか (緑)

using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GreenEnemyController : MonoBehaviour
{
    public float speed = 10f; // 敵の移動速度

    public int hp = 1; // 敵の体力

    public int score = 100; // 敵を倒したときのスコア

    public GameObject enemyBulletPrefab; // 敵の弾のプレハブ

    public Transform firePoint; // 弾を発射する位置

    public float fireInterval = 0.1f; // 弾を発射する間隔

    private float fireTimer = 0f; // 弾を発射するタイマー


    void Start()
    {
        int level = LevelManager.Instance.GetLevel(); // 現在のレベルを取得

        speed = Mathf.Clamp(1f * (level - 1) * 1f, 3f, 10f); // レベルに応じて速度を調整（最小3、最大10）
    }
    void Update()
    {
        // 下方向へ移動
        transform.Translate(
            Vector3.down * speed * Time.deltaTime
            );

        fireTimer += Time.deltaTime; // タイマーを更新

        // 弾を発射する処理
        if (fireTimer >= fireInterval)
        {
            Shoot(); 
            fireTimer = 0f; // タイマーをリセット
        }

        // 画面外へ行ったら削除
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    // 弾を発射する処理
    void Shoot()
    {
        CreateBullet(new Vector3(0f, -1f, 0f)); // 下方向に弾を発射
        CreateBullet(new Vector3(-0.5f, -1f, 0f)); // 左下方向に弾を発射
        CreateBullet(new Vector3(0.5f, -1f, 0f)); // 右下方向に弾を発射
    }

    // 弾を生成する処理
    void CreateBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(
            enemyBulletPrefab,
            firePoint.position,
            Quaternion.identity
            );

        // 弾の方向を設定
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();

        // 弾の方向を正規化して設定
        if (bulletController != null)
        {
            bulletController.SetDirection(direction);
        }
    }
    // 弾と衝突したときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 弾と衝突したら削除
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 弾を削除

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
