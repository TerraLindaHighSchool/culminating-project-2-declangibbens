using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    public bool isGameActive = true;
    private float xMin = -8.0f;
    private float xMax = 8.5f;
    private float ySpawnPos = 0.0f;
    private float vehiclePos;
    private PlayerController playerControllerScript;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        playerControllerScript = GameObject.Find("Vehicle").GetComponent<PlayerController>();
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        vehiclePos = GameObject.Find("Vehicle").transform.position.z;
        isGameActive = playerControllerScript.isGameActive;
        if (isGameActive == false)
        {
            GameOver();
        }

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], RandomSpawnPos(), transform.rotation);
            spawnRate = spawnRate - 0.01f;
            UpdateScore(1);
        }
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xMin, xMax), ySpawnPos, vehiclePos + 165);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
