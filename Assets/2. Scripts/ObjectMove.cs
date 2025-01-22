using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed = 8f; // 이동 속도
    private float upperLimit = 13f; // 위쪽 한계
    private float lowerLimit = -11f; // 아래쪽 한계

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // 오브젝트 이동
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
        
        if (transform.position.y >= upperLimit)
        {
            transform.position = new Vector3(startPosition.x, lowerLimit, startPosition.z);
        }
    }
}
