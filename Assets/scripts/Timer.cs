using UnityEngine;
using UnityEngine.UI; // Serve per il testo classico di Unity

public class Timer : MonoBehaviour
{
   
    public Text TimerText;       
    public Text GameOverText;    
    public GameObject Player;    

   
    private float timeRemaining = 300f;     private bool isGameOver = false;

    void Start()
    {
      
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Se il gioco non è finito, il tempo scorre
        if (isGameOver == false)
        {
            timeRemaining = timeRemaining - Time.deltaTime;

            // Se il testo esiste, calcoliamo minuti e secondi in modo super facile
            if (TimerText != null)
            {
                // Dividiamo per 60 per trovare i minuti (es. 120 secondi / 60 = 2 minuti)
                int minutes = (int)(timeRemaining / 60);
                
                // Il simbolo % trova i secondi che avanzano dalla divisione
                int seconds = (int)(timeRemaining % 60);

                // Scriviamo sul display nel formato Minuti : Secondi
                TimerText.text =  minutes + ":" + seconds;
            }

            // Se il tempo finisce, attiviamo il Game Over
            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        
        // Spegniamo il timer vecchio
        if (TimerText != null)
        {
            TimerText.gameObject.SetActive(false);
        }

        // Accendiamo la scritta "Hai Perso"
        if (GameOverText != null)
        {
            GameOverText.text = "GAME OVER - HAI PERSO";
            GameOverText.gameObject.SetActive(true);
        }

        // Spegniamo il giocatore per bloccarlo
        if (Player != null)
        {
            Player.SetActive(false);
        }
    }
}