//プレイヤーのコントローラー

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //プレイヤーの移動速度

    public GameObject bulletPrefab; //弾のプレハブ

    public Transform firePoint; //弾を発射する位置

    private PlayerInputActions inputActions; //入力アクションのインスタンス
    private Vector2 moveInput; //移動入力の値

    //ゲーム開始時に一度だけ実行
    private void Awake()
    {
        inputActions = new PlayerInputActions(); // 入力アクションのインスタンスを作成
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

        transform.Translate(moveInput.x  * speed * Time.deltaTime, 0, 0); // 入力に応じてプレイヤーを移動させる
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // プレイヤーの半分の幅を取得

        Vector3 pos = transform.position; // 現在の位置を取得
        pos.x = Mathf.Clamp(pos.x, -4.3f + halfWidth, 4.3f - halfWidth); // 画面の端に到達したら移動を制限する
        transform.position = pos;

        //スペースキーが押されたら弾を発射する
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //新しいオブジェクトを作る
            Instantiate(
                bulletPrefab, //弾のプレハブ
                firePoint.position,//弾を発射する位置
                Quaternion.identity//弾の回転を指定
             );
        }
    }
}
