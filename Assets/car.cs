using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    // 車の現在の速度
    private float currentSpeed = 0f;

    // 車の最大速度
    public float maxSpeed = 10f;
    // 車の最小速度
    public float minSpeed = -20f;

    // 車の加速度
    public float acceleration = 4f;

    // 車の回転速度
    float rotationSpeed = 30f;

    // 車の減速度
    public float deceleration = 20f;

    // Rigidbodyコンポーネント
    private Rigidbody rb;

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 水平方向の入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");

        // 垂直方向の入力を取得
        float verticalInput = Input.GetAxis("Vertical");

        // 現在の速度を最大速度の範囲内に制限する
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);

        // 前進入力がある場合、加速する
        if (verticalInput > 0f && maxSpeed > currentSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        // 後退入力がある場合、減速する
        else if (verticalInput < 0f || Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        // 入力がない場合、減速する
        else
        {

            if (currentSpeed > 0f)
            {
                currentSpeed -= deceleration * Time.deltaTime;
            }
            else if (currentSpeed < 0f)
            {
                currentSpeed += deceleration * Time.deltaTime;
            }
        }

        // 速度が0に近い場合、0にする
        if (Mathf.Abs(currentSpeed) <= 0.1f)
        {
            currentSpeed = 0f;
        }

        // 速度が0でない場合、前進または後退する
        if (currentSpeed != 0)
        {
            float movementInput = currentSpeed;
            if (Input.GetKey(KeyCode.S))
            {
                movementInput = -currentSpeed;
            }
            //speedが100未満の時のみ
            if (Speedometer.instance.GetSpeed() < 100)
            {
                rb.AddForce(transform.forward * movementInput);
            }
        }

        // 水平方向の入力がある場合、回転する
        if (horizontalInput != 0)
        {
            float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }

        // X軸の回転角度が最大角度を超えた場合、角度を制限する
        if (Mathf.Abs(transform.rotation.eulerAngles.x) >= 70 || Mathf.Abs(transform.rotation.eulerAngles.x - 70) < 5)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }

        // Z軸の回転角度が最大角度を超えた場合、角度を制限する
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 85 || Mathf.Abs(transform.rotation.eulerAngles.z + 85) < 5)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
}
