using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    // Elementi dell'interfaccia e player
    public Text TimerText;
    public Text GameOverText;
    public GameObject Player;

    // Variabili che gestiscono il tempo e lo stato del gioco
    private float timeRemaining = 300f;
    private bool isGameOver = false;
    private bool isPaused = false;

    void Start()
    {
        // Nasconde il testo del Game Over e mostra il tempo iniziale
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
        // Aggiorna il timer finché il gioco non è terminato e il timer non è in pausa
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

            // Quando il tempo finisce viene avviato il Game Over
            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    // Mette in pausa il timer
    public void PauseTimer()
    {
        isPaused = true;
        Debug.Log("Timer FERMATO!");
    }

    // Fa ripartire il timer
    public void ResumeTimer()
    {
        isPaused = false;
        Debug.Log("Timer RIPARTITO!");
    }

    // Gestisce tutto ciò che succede alla fine della partita
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