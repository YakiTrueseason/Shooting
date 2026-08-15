//プレイヤー　敵に当てる弾 実際に飛んでいく１発の弾

using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f; // 弾の速度

    public int bulletPower = 1; // 弾の威力

    private Vector3 direction = Vector3.up; // 弾の移動方向

    // 弾の移動方向を設定するメソッド
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized; 
    }


    void Update()
    {
        // 弾を移動させる
        transform.position += direction * speed * Time.deltaTime;

        // 弾が画面外に出たら削除する
        if (
            transform.position.y > 6f ||
            transform.position.x < -7f ||
            transform.position.x > 7f
            )
        {
            Destroy(gameObject);　//弾を削除
        }
    }
}
