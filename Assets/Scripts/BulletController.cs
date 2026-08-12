//敵に当てる弾

using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;

    public float fireInterval = 0.5f; // 弾の発射間隔

    public int bulletPower = 1; // 弾の威力

    public int bulletCount = 1; // 弾の

    // 弾の発射間隔を上げる
    public void UpgradeFireRate()
    {
        fireInterval -= 0.1f; 

        if(fireInterval < 0.1f) // 最小値を設定
        {
            fireInterval = 0.1f;
        }
    }

    // 弾の威力を上げる
    public void UpgradeBulletPower()
    {
        bulletPower ++; 
    }

    // 弾の数を増やす
    public void UpgradeBulletCount()
    {
        bulletCount++; 
    }

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
