using UnityEngine;
using TMPro; // Usiamo TextMeshPro, lo standard moderno di Unity

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI TimerText;       
    public TextMeshProUGUI GameOverText;    
    public GameObject Player;               

    
    private float timeRemaining = 60f; 
    private bool isGameOver = false;

    void Start()
    {
        
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver == false)
        {
            
            timeRemaining = timeRemaining - Time.deltaTime;

            // Mostriamo il tempo sullo schermo
            if (TimerText != null)
            {
                TimerText.text =  Mathf.Round(timeRemaining).ToString();
            }

            // Se il tempo è scaduto...
            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        
        // dissativa testo del timer
        if (TimerText != null)
        {
            TimerText.gameObject.SetActive(false);
        }

        // Mostriamo la scritta "Hai Perso"
        if (GameOverText != null)
        {
            GameOverText.text = "GAME OVER";
            GameOverText.gameObject.SetActive(true);
        }

        // Disattiviamo il giocatore
        if (Player != null)
        {
            Player.SetActive(false);
        }
    }
}