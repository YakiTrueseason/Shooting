using System;
using UnityEngine;
using UnityEngine.InputSystem;

    //変数
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private PlayerInputActions inputActions;
    private Vector2 moveInput;

    //ゲーム開始時に一度だけ実行
    private void Awake()
    {
        inputActions = new PlayerInputActions();
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
        inputActions.Disable();
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
