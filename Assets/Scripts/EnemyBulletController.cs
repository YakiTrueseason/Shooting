//敵の弾の挙動を制御

using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 5f; //弾の速度

    private Vector3 direction; //弾の移動方向

    public void SetDirection(Vector3 targetDirection)
    {
        direction = targetDirection.normalized; //弾の移動方向を設定
    }
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World); //弾を指定方向に移動させる

        //画面外に出たら弾を破壊する
        if (transform.position.y < -7f ||
            transform.position.x < -10f ||
            transform.position.x > 10f) 
        {
            Destroy(gameObject); 
        }
    }

    //プレイヤーと衝突した時の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerManager.Instance.Damage(); //プレイヤーのライフを減らす

            Destroy(gameObject); //弾を破壊する
        }
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //プレイヤーの弾を破壊する

            ScoreManager.Instance.AddScore(10); //スコアを加算する

            Destroy(gameObject); //敵の弾を破壊する
        }
    }
}
