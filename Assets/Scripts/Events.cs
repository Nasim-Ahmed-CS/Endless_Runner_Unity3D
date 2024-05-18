using UnityEngine.SceneManagement;
using UnityEngine;
using Newtonsoft.Json.Bson;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        Runner._score = 0;
        Runner._energy = 10;
        SceneManager.LoadScene("Final_scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
