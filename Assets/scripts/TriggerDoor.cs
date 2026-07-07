using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
   
    public Timer GameTimer; 

    // Questa funzione si attiva nell'esatto momento in cui il giocatore ESCE dal Collider/Trigger
    void OnTriggerExit(Collider other)
    {
        // Controlliamo se l'oggetto che sta uscendo è il giocatore
        if (other.CompareTag("Player"))
        {
            if (GameTimer != null)
            {
                // Avviamo il timer
                GameTimer.StartTimer();
            }
        }
    }
}