using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timers : MonoBehaviour
{
    // Elementi dell'interfaccia e player
    public Text TimerText;
    public Text GameOverText;
    public GameObject Player;
    
    [Header("Post Score Canvas")]
    public GameObject PostScoreCanvas; 
    public float delayBeforePostScore = 3f; 

    [Header("Controllo Mouse / Gioco")]
    public MouseClicker mouseClickerScript; // Trascina qui l'oggetto che ha lo script MouseClicker

    // Variabili che gestiscono il tempo e lo stato del gioco
    private float timeRemaining = 300f;
    private bool isGameOver = false;
    private bool isPaused = false;

    void Start()
    {
        if (GameOverText != null) GameOverText.gameObject.SetActive(false);
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

        // 1. DISATTIVA LO SCRIPT DEL MOUSE (così non spara più raycast e libera il cursore)
        if (mouseClickerScript != null)
        {
            mouseClickerScript.enabled = false;
        }

        // 2. Assicurati che il cursore del mouse sia visibile e sbloccato
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