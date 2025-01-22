using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gasText;

    public GameObject car;
    public GameObject gasItemPrefab;

    public float gas = 100;
    private float gasConsumptionRate = 10f; // Gas per second
    private bool isGameRunning = false;

    void Start()
    {
        Time.timeScale = 0f; // 게임 멈춤
        startPanel.SetActive(true);
        gasText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGameRunning)
        {
            gas -= gasConsumptionRate * Time.deltaTime;
            gasText.text = "Gas: " + Mathf.Max(0, (int)gas);

            if (gas <= 0)
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // 게임 시간 정상
        gas = 100;
        isGameRunning = true;
        gasText.gameObject.SetActive(true);
        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gasText.text = "Gas: " + gas;
        InvokeRepeating("SpawnGasItem", 2.0f, 3.0f); // Spawn gas items every 3 seconds
    }

    public void EndGame()
    {
        Time.timeScale = 0f; // 게임 멈춤
        isGameRunning = false;
        CancelInvoke("SpawnGasItem");
        gasText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        StartGame();
    }

    private void SpawnGasItem()
    {
        if (!isGameRunning) return;

        float[] lanes = { -3f, 0f, 3f }; // Left, Center, Right positions
        float spawnX = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPosition = new Vector3(spawnX, 8f, car.transform.position.z);

        Instantiate(gasItemPrefab, spawnPosition, Quaternion.identity);
    }
}