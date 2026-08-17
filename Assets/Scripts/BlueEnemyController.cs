//敵（青）

using UnityEngine;

public class BlueEnemyController : MonoBehaviour
{
    public float speed = 5f; //敵の移動速度

    public float moveWidth = 3f; //敵の移動幅

    public float movespeed = 2f; //敵の移動速度

    public int hp = 2; //敵の体力

    public int score = 200; //敵を倒したときのスコア

    public int expValue = 2; //経験値付与

    public HPbarController hpBar; //HP表示

    public GameObject enemyBulletPrefab; //敵の弾のプレハブ

    public Transform firePoint; //弾を発射する位置

    public float fireInterval = 0.5f; //弾を発射する間隔

    private bool firstShot = true; //最初の弾を撃つかどうか

    private float fireTimer = 0f; //弾を発射するタイマー

    private float moveTimer = 0f; //敵の移動タイマー

    private Vector3 startPos; //敵の初期位置
    void Start()
    {
        startPos = transform.position; //敵の初期位置を保存

        hpBar.SetMaxHP(hp); //最大HP
    }

    void Update()
    {
        //敵を左右に移動させる
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        //サイン波を使って左右に移動させる
        float x = Mathf.Sin(Time.time * movespeed) * moveWidth;

        if (firstShot)
        {
            Shoot(); //最初の弾を発射

            firstShot = false; //最初の弾を撃ったのでfalseにする

            fireTimer = 0f; //タイマーをリセット
        }

        fireTimer += Time.deltaTime; //タイマーを更新

        if(fireTimer >= fireInterval)
        {
            Shoot(); //弾を発射
            fireTimer = 0f; //タイマーをリセット
        }

        //敵の位置を更新
        transform.position = new Vector3(
            startPos.x + x,
            transform.position.y,
            0);
        if (transform.position.y < -5f)
        {
            Destroy(gameObject); //画面の下まで行ったら削除
        }
    }

    //弾を発射する処理
    void Shoot()
    {
        GameObject bullet = Instantiate(
            enemyBulletPrefab,
            firePoint.position,
            Quaternion.identity 
            );
        //弾の方向を設定
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();

        //弾の方向を下に設定
        if (bulletController != null)
        {
            bulletController.SetDirection(
                new Vector3(0, -1, 0)
                ); 
        }
    }

    //敵がプレイヤーに当たったときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.Damage(); //プレイヤーのライフを減らす

            Destroy(gameObject); //敵を破壊する
        }
        //敵がプレイヤーの弾に当たったときの処理
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //プレイヤーの弾を破壊する
            hp--;
            hpBar.SetHP(hp); //HP表示を減らす
        }
        if (hp <= 0)
        {
            ScoreManager.Instance.AddScore(score); //スコアを加算する

            LevelManager.Instance.AddExp(expValue); //経験値を加算する

            Destroy(gameObject); 
        }
    }
}
