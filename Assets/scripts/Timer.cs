using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // VARIABILI PUBBLICHE (Iniziale Maiuscola)
    public Text TimerText;       
    public Text GameOverText;    
    public GameObject Player;    

    // VARIABILI PRIVATE (Iniziale Minuscola)
    private float timeRemaining = 300f; 
    private bool isGameOver = false;
    
    // MODIFICA: Ora il gioco parte in PAUSA, il timer è fermo all'inizio!
    private bool isPaused = true; 

    void Start()
    {
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
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
                TimerText.text = "Time: " + minutes + ":" + seconds;
            }

            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    // Questa funzione verrà chiamata quando il giocatore esce dalla stanza
    public void StartTimer()
    {
        isPaused = false;
        Debug.Log("Il giocatore è uscito dalla stanza: TIMER PARTITO!");
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        if (TimerText != null) TimerText.gameObject.SetActive(false);

        if (GameOverText != null)
        {
            GameOverText.text = "GAME OVER - HAI PERSO";
            GameOverText.gameObject.SetActive(true);
        }

        if (Player != null) Player.SetActive(false);
    }
}