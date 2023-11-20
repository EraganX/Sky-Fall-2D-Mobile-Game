using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject cloudPrefab,pressToStart;
    public float maxX, spawnRate;
    public Transform spawnPoints;

    public TMP_Text scoreText;

    int score = 0;

    bool _gameStarted = false;
    Vector3 leftmostScreenPoint, rightmostScreenPoint;
    public static Vector3 leftmostWorldPoint, rightmostWorldPoint;

    private void Awake()
    {
        leftmostScreenPoint = new Vector3(0 + 150, spawnPoints.position.y, 0);
        rightmostScreenPoint = new Vector3(Screen.width - 150, spawnPoints.position.y, 0);

        leftmostWorldPoint = Camera.main.ScreenToWorldPoint(leftmostScreenPoint);
        rightmostWorldPoint = Camera.main.ScreenToWorldPoint(rightmostScreenPoint);

        pressToStart.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    private void Start()
    {
         
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_gameStarted)
        {
            StartSpawn();
            _gameStarted = true;
            PlayerController.canMove = true;
            pressToStart.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }
    }

    private void StartSpawn()
    {
        InvokeRepeating("SpawnCloud", 0.5f,spawnRate);
    }

    private void SpawnCloud()
    {
        Vector3 spawnPosition =  spawnPoints.position;
        spawnPosition.x = Random.Range(leftmostWorldPoint.x, rightmostWorldPoint.x);
        Instantiate(cloudPrefab,spawnPosition,Quaternion.identity);
        score++;
        scoreText.text = score.ToString();  

    }
}
