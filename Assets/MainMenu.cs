using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadScene(2);
    }

    public void MultiPlayer()
    {
        SceneManager.LoadScene(1);
    }
}
