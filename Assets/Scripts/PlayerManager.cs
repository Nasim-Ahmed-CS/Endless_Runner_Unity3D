using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    
    public static bool gameOver;
    public GameObject gameOverPanel;
    public Text energy;
    public Text scorer;
    
    
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        scorer.text = "SCORE: " + Runner._score;
        energy.text = "ENERGY: " + Runner._energy;
    }
}
