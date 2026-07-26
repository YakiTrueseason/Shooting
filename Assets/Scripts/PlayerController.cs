using System;
using UnityEngine;
using UnityEngine.InputSystem;

    //変数
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

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
        inputActions.Enable();

        inputActions.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };
        inputActions.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };  
    }

    private void OnDisable()
    {
        inputActions.Disable(); // 入力を無効化
    }

    //敵と衝突した時の処理
    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerManager.Instance.Damage(); //プレイヤーのライフを減らす

            Destroy(other.gameObject); //敵を破壊
        }
    }
    //現在入力されている方向
    void Update()
    {

        transform.Translate(moveInput.x  * speed * Time.deltaTime, 0, 0);
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.3f + halfWidth, 4.3f - halfWidth);
        transform.position = pos;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //新しいオブジェクトを作る
            Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
             );
        }
    }
}
