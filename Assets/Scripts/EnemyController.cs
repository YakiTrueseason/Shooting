using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
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
            Destroy(gameObject); // 敵を削除
        }
    }
}
