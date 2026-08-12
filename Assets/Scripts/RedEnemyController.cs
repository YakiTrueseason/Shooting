//敵（赤）

using UnityEngine;

public class RedEnemyController : MonoBehaviour
{
    public float speed = 5f; //敵の移動速度

    public GameObject enemyBulletPrefab; //敵の弾のプレハブ

    public Transform firePoint; //弾を発射する位置

    public float fireInterval = 1f; //弾を発射する間隔

    private Transform player; //プレイヤーのTransformを格納する変数

    private float fireTimer = 0f; //弾を発射するタイマー

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); //プレイヤーのオブジェクトを取得

        if(playerObject != null)
        {
            player = playerObject.transform; //プレイヤーのTransformを取得
        }
    }

    void Update()
    {
        if (player == null)
        {
            return; //プレイヤーが存在しない場合は処理を中断
        }
        Vector3 direction = (player.position - transform.position).normalized; //プレイヤーの方向を計算

        direction.z = 0; //Z軸方向の移動を無効化

        direction.Normalize(); //方向ベクトルを正規化

        transform.Translate(direction * speed * Time.deltaTime, Space.World); //プレイヤーの方向に移動

        fireTimer += Time.deltaTime; //タイマーを更新

        if (fireTimer >= fireInterval)
        {
            Shoot(); //弾を発射する

            fireTimer = 0f; //タイマーをリセット
        }

        if (transform.position.y < -5f)
        {
            Destroy(gameObject); //画面の下まで行ったら削除
        }
    }
    // 弾と衝突したときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 弾を削除

            ScoreManager.Instance.AddScore(100); //スコアを加算

            LevelManager.Instance.AddExp(1); // 経験値を加算

            Destroy(gameObject); //敵を削除
        }
    }
    // 弾を発射する処理
    void Shoot()
    {
        // 弾を生成
        GameObject bullet = Instantiate(
            enemyBulletPrefab,
            firePoint.position,
            Quaternion.identity
         );

        // 弾の方向をプレイヤーに向ける
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();

        if (bulletController != null)
        {
            bulletController.SetDirection(player.position);
        }
    }
 }

    