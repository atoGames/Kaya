using UnityEngine;
using UnityEngine.SceneManagement;



public class Game_Manager : MonoBehaviour
{
    public void btnPlay() => SceneManager.LoadScene(1);
    public void btnQuit() => Application.Quit();

}
