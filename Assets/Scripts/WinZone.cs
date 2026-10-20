using UnityEngine;

public class WinZone : MonoBehaviour
{
    public Timers GameTimer; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameTimer != null)
            {
                GameTimer.TriggerWin();
            }
        }
    }
}