using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    public TextMeshProUGUI timeText;
    public GameObject gameOverUI;
    public TextMeshProUGUI recordText;
    //private static float bestScore; //static사용 시 처음 GameMananger가 시작될 때 올라옴, 끝날 때 사라짐. 게임을 껐다가 재시작 시 초기화

    private float surviveTime;

    private void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = $"TIME: {surviveTime:F2}";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > bestScore)
        {
            bestScore = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestScore);
        }
        
        recordText.text = $"Best Record: {bestScore:F1}";
    }
}

