//プレイヤー　連射速度　弾数 どんな性能の弾を打つか

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f; //プレイヤーの移動速度

    public GameObject bulletPrefab; //弾のプレハブ

    public Transform firePoint; //弾を発射する位置

    public float fireInterval = 0.5f; //弾の発射間隔

    public int bulletPower = 1; //弾の威力

    public int bulletCount = 1; //弾の数

    private float fireTimer = 0f; //弾の発射タイマー

    private PlayerInputActions inputActions; //入力アクションのインスタンス

    private Vector2 moveInput; //移動入力の値

    //ゲーム開始時に一度だけ実行
    private void Awake()
    {
        inputActions = new PlayerInputActions(); // 入力アクションのインスタンスを作成

        //GameManagerに保存されている強化値を取得
        bulletCount = GameManager.Instance.bulletCount;
        bulletPower = GameManager.Instance.bulletPower;
        fireInterval = GameManager.Instance.fireInterval;
    }

    //入力を受け付ける準備
    private void OnEnable()
    {
        inputActions.Enable();// 入力を有効化

        inputActions.Player.Move.performed += ctx => // 移動入力が行われたときの処理
        {
            moveInput = ctx.ReadValue<Vector2>(); // 入力値を取得
        };
        inputActions.Player.Move.canceled += ctx => // 移動入力がキャンセルされたときの処理
        {
            moveInput = Vector2.zero; // 入力値をリセット
        };  
    }

    private void OnDisable()
    {
        inputActions.Disable(); // 入力を無効化
    }

    //敵と衝突した時の処理
    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Enemy")) //敵と衝突した場合
        {
            PlayerManager.Instance.Damage(); //プレイヤーのライフを減らす

            Destroy(other.gameObject); //敵を破壊
        }
    }
    //現在入力されている方向
    void Update()
    {
        //Debug.Log($"Move Input: {moveInput}"); // デバッグ用に移動入力を表示
        //Debug.Log($"Player Position: {transform.position}"); // デバッグ用にプレイヤーの位置を表示

        // 入力に応じてプレイヤーを移動させる
        transform.Translate(
            moveInput.x  * speed * Time.deltaTime,
            moveInput.y * speed * Time.deltaTime,
            0f
         );

        // プレイヤーのスプライトの幅を取得
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x; 

        Vector3 pos = transform.position; // 現在の位置を取得

        // 画面の左右の端に到達したら移動を制限する
        pos.x = Mathf.Clamp(
            pos.x,
            -5f + transform.localScale.x / 2f,
            5f - transform.localScale.x / 2f
         );

        // 画面の上下の端に到達したら移動を制限する
        pos.y = Mathf.Clamp(
            pos.y,
            -5f + transform.localScale.y / 2f,
            5f - transform.localScale.y / 2f
         );

        transform.position = pos; // 制限後の位置を設定

        fireTimer += Time.deltaTime; //弾の発射タイマーを更新

        //スペースキーが押されたら弾を発射する
        if (Keyboard.current.spaceKey.isPressed)
        {
            if(fireTimer >= fireInterval) //弾の発射間隔をチェック
            {
                Shoot(); //弾を発射する

                fireTimer = 0f; //タイマーをリセット
            }
        }
    }

    //弾を発射するメソッド
    void Shoot()
    {
        //弾の数だけループして弾を生成する
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = 15f; //弾と弾の間隔

            float　startAngle = -(bulletCount - 1) * angle / 2f; //弾全体の中心を０度に
            
            float currAngle = startAngle + i * angle; //今何発目かの角度決め

            //上方向を基準に発射方向計算
            Vector3 direction = Quaternion.Euler(0, 0, currAngle) * Vector3.up; 

            //弾を生成する
            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.Euler(0, 0, currAngle)
            );

            //弾の威力を設定する
            BulletController bulletController = 
                bullet.GetComponent<BulletController>();

            if (bulletController != null)
            { 
                bulletController.bulletPower = bulletPower; //弾の威力を設定

                bulletController.SetDirection(direction); //弾の方向を設定
            }
        }
    }

    //弾の発射間隔を短くするメソッド
    public void UpgradeFireRate()
    {
        GameManager.Instance.UpgradeFireRate();

        fireInterval = GameManager.Instance.fireInterval;
    }

    //弾の威力を上げるメソッド
    public void UpgradeBulletPower()
    {
       GameManager.Instance.UpgradeBulletPower();

        bulletPower = GameManager.Instance.bulletPower;
    }

    //弾の数を増やすメソッド
    public void UpgradeBulletCount()
    {
       GameManager.Instance.UpgradeBulletCount();

        bulletCount = GameManager.Instance.bulletCount;
    }
}
