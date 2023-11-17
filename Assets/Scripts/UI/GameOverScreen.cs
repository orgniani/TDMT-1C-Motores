using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc) --> DONE
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private string firstLevel = "FirstLevel";
    [SerializeField] private string mainMenu = "MainMenu";

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void RestartLevelButton()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void PauseButton()
    {
        pauseScreen.PauseGame();
    }
}
