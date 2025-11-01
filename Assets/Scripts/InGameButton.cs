using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButton : MonoBehaviour
{
    public void QuitGame() => Application.Quit();

    public void RestartGame(string SceneName) => SceneManager.LoadScene (SceneName);
}
