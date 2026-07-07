using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    
    public Text TimerText;       
    public Text GameOverText;    
    public GameObject Player;    
    public float timeRemaining = 300f; 
    private bool isGameOver = false; // Riattivata per evitare l'errore nell'Update

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
        // Se il gioco non è finito, il tempo scorre dritto senza pause
        if (isGameOver == false)
        {
            timeRemaining = timeRemaining - Time.deltaTime;

            if (TimerText != null)
            {
                int minutes = (int)(timeRemaining / 60);
                int seconds = (int)(timeRemaining % 60);
                
                // Evita di far vedere numeri negativi se scende sotto lo zero
                if (timeRemaining < 0)
                {
                    minutes = 0;
                    seconds = 0;
                }

                TimerText.text = minutes + ":" + seconds;
            }

            // Se il tempo scade, andiamo in Game Over
            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    // Questa funzione serve e NON va cancellata o commentata, altrimenti l'Update si rompe!
    void TriggerGameOver()
    {
        isGameOver = true;
        
        
        if (TimerText != null) 
        {
            TimerText.gameObject.SetActive(false);
        }

      
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