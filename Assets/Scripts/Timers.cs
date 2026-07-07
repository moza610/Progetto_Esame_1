using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
   
    public Text TimerText;       
    public Text GameOverText;    
    public GameObject Player;    

    private float timeRemaining = 300f; 
    private bool isGameOver = false; 
    private bool isPaused = false; 
    void Start()
    {
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }

        if (TimerText != null)
        {
            int minutes = (int)(timeRemaining / 60);
            int seconds = (int)(timeRemaining % 60);
            TimerText.text = minutes + ":" + seconds;
        }
    }

    void Update()
    {
        if (isGameOver == false && isPaused == false)
        {
            timeRemaining = timeRemaining - Time.deltaTime;

            if (TimerText != null)
            {
                int minutes = (int)(timeRemaining / 60);
                int seconds = (int)(timeRemaining % 60);
                
                if (timeRemaining < 0)
                {
                    minutes = 0;
                    seconds = 0;
                }

                TimerText.text = minutes + ":" + seconds;
            }

            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    // Funzione per la porta
    public void PauseTimer()
    {
        isPaused = true;
        Debug.Log("Timer FERMATO!");
    }

    // Funzione per la porta
    public void ResumeTimer()
    {
        isPaused = false;
        Debug.Log("Timer RIPARTITO!");
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        
        if (TimerText != null) TimerText.gameObject.SetActive(false);

        if (GameOverText != null)
        {
            GameOverText.text = "HAI PERSO";
            GameOverText.gameObject.SetActive(true);
        }

        if (Player != null) 
        {
            Player.SetActive(false);
        }
    }
}