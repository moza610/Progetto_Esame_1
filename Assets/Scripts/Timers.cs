using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timers : MonoBehaviour
{
    // Elementi dell'interfaccia e player
    public Text TimerText;
    public Text GameOverText;
    public Text WinText; // <-- Aggiunto per gestire il testo di vittoria
    public GameObject Player;
    
    [Header("Post Score Canvas")]
    public GameObject PostScoreCanvas; 
    public float delayBeforePostScore = 3f; 

    [Header("Controllo Mouse / Gioco")]
    public MouseClicker mouseClickerScript; 

    // Variabili che gestiscono il tempo e lo stato del gioco
    private float timeRemaining = 300f;
    private bool isGameOver = false;
    private bool isWin = false;
    private bool isPaused = false;

    void Start()
    {
        if (GameOverText != null) GameOverText.gameObject.SetActive(false);
        if (WinText != null) WinText.gameObject.SetActive(false);
        if (PostScoreCanvas != null) PostScoreCanvas.SetActive(false);

        if (TimerText != null)
        {
            int minutes = (int)(timeRemaining / 60);
            int seconds = (int)(timeRemaining % 60);
            TimerText.text = minutes + ":" + seconds;
        }
    }

    void Update()
    {
        // Il timer scorre solo se non abbiamo perso, non abbiamo vinto e non è in pausa
        if (isGameOver == false && isWin == false && isPaused == false)
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

                // Formattazione per mostrare sempre i secondi a due cifre (es. 05 invece di 5)
                TimerText.text = minutes + ":" + seconds.ToString("00");
            }

            if (timeRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    void TriggerGameOver()
    {
        if (isGameOver || isWin) return; // Evita conflitti se il gioco è già terminato
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

        if (mouseClickerScript != null)
        {
            mouseClickerScript.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(ShowPostScoreRoutine());
    }

    public void TriggerWin() // Resa public così puoi chiamarla da altri script quando il giocatore vince
    {
        if (isGameOver || isWin) return; // Evita conflitti
        isWin = true;

        if (TimerText != null) TimerText.gameObject.SetActive(false);

        // Controllo corretto sul componente Text di Unity
        if (WinText != null)
        {
            WinText.text = "Win";
            WinText.gameObject.SetActive(true);
        }

        if (Player != null)
        {
            Player.SetActive(false);
        }

        if (mouseClickerScript != null)
        {
            mouseClickerScript.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(ShowPostScoreRoutine());
    }

    IEnumerator ShowPostScoreRoutine()
    {
        yield return new WaitForSeconds(delayBeforePostScore);

        if (PostScoreCanvas != null)
        {
            PostScoreCanvas.SetActive(true);
        }
    }
}