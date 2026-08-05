//敵に当てる弾

using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        //毎フレーム、上方向へ移動する
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //画面の上まで行ったら削除
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);　//弾を削除
        }
    }
}
