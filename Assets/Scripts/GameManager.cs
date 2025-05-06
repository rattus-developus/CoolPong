using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_Text score1Text;
    [SerializeField] TMP_Text score2Text;

    [SerializeField] GameObject player1Win;
    [SerializeField] GameObject player2Win;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    [SerializeField] int score1;
    [SerializeField] int score2;

    [SerializeField] bool singleplayer;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Update()
    {
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();

        if(score1 >= 3)
        {
            Time.timeScale = 0f;
            if(singleplayer) winScreen.SetActive(true);
            else player1Win.SetActive(true);
        }
        if(score2 >= 3)
        {
            Time.timeScale = 0f;
            if(singleplayer) loseScreen.SetActive(true);
            else player2Win.SetActive(true);
        }
    }

    public void Score1()
    {
        score1++;
    }

    public void Score2()
    {
        score2++;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        if(singleplayer) SceneManager.LoadScene(2);
        else SceneManager.LoadScene(1);
    }
}
