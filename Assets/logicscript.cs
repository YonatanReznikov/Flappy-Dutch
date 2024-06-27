using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicscript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject menu;
    public GameObject Pipespawner;
    private static bool isRestarting = false;
    public static float currentPipeSpeed = 8f;
    public static float currentSpawnRate = 2f;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();

        if (isRestarting)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            gameOverScreen.SetActive(false);
            isRestarting = false;
        }
        else
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            gameOverScreen.SetActive(false);
        }
        Debug.Log("Game started with pipe speed: " + currentPipeSpeed + " and spawn rate: " + currentSpawnRate);
    }

    public void addscore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    public void mainMenu()
    {
        Time.timeScale = 0;
        isRestarting = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        menu.SetActive(true);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void exitgame()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void restartGame()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetEasySpeed()
    {
        SetPipeSpeed(12f, 2f);
        Debug.Log("Difficulty set to Easy");
    }

    public void SetMediumSpeed()
    {
        SetPipeSpeed(24f, 1.5f);
        Debug.Log("Difficulty set to Medium");
    }

    public void SetHardSpeed()
    {
        SetPipeSpeed(36f, 1f);
        Debug.Log("Difficulty set to Hard");
    }

    private void SetPipeSpeed(float speed, float spawnRate)
    {
        currentPipeSpeed = speed;
        currentSpawnRate = spawnRate;
        Debug.Log("Setting all pipes to speed: " + speed + " and spawn rate: " + spawnRate);
        pipeMoveScript[] pipes = FindObjectsOfType<pipeMoveScript>();
        foreach (pipeMoveScript pipe in pipes)
        {
            pipe.moveSpeed = speed;
        }

        if (Pipespawner != null)
        {
            Pipespawner.GetComponent<Pipespawner>().spawnRate = spawnRate;
        }
        else
        {
            Debug.LogError("Pipespawner is not assigned in the Inspector!");
        }
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }

    public void resetscore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScore = 0;
        highScoreText.text = highScore.ToString();
    }
}
