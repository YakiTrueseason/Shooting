//敵（赤）

using UnityEngine;

public class RedEnemyController : MonoBehaviour
{
    public float speed = 5f; //敵の移動速度

    private Transform player; //プレイヤーのTransformを格納する変数
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

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

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
            Destroy(gameObject); //敵を削除
        }
    }

 }
