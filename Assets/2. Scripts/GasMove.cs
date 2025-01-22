using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMove : MonoBehaviour
{
    private float speed = 5f; // 이동 속도

    void Update()
    {
        // 아래로 이동
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        // 일정 위치 아래로 떨어지면 제거
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
