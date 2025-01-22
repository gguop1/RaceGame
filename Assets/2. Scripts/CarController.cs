using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed = 15f;
    private float laneDistance = 3f; // Distance between lanes
    public GameController gameController;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Input.mousePosition;
            if (touchPosition.x < Screen.width / 2)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else
            {
                targetPosition += Vector3.right * laneDistance;
            }
        }

        targetPosition.x = Mathf.Clamp(targetPosition.x, -Mathf.Abs(laneDistance), Mathf.Abs(laneDistance)); // Keep within lanes
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            gameController.gas += 30f;
            Destroy(other.gameObject);
        }
    }
}
