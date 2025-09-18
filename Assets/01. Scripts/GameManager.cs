using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

    private int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 메니저가 존재합니다");
            Destroy(gameObject);
        }

    }
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead() {
        isGameover = true;
        gameoverUI.SetActive(true);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame

}
