//敵（青）

using UnityEngine;

public class BlueEnemyController : MonoBehaviour
{
    public float speed = 5f; //敵の移動速度

    public float moveWidth = 3f; //敵の移動幅

    public float movespeed = 2f; //敵の移動速度

    private Vector3 startPos; //敵の初期位置
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        //敵を左右に移動させる
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        //サイン波を使って左右に移動させる
        float x = Mathf.Sin(Time.time * movespeed) * moveWidth; 

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
}
