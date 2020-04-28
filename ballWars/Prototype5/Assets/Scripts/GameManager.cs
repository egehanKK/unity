using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool isGameActive = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;
    private int score;
    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score: " + score;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
}
