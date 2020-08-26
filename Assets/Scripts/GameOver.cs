using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Game()
    {
        SceneManager.LoadScene(1);
    }

}
