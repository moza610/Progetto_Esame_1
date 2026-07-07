using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
  
    public Timers GameTimer; 

   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameTimer != null)
            {
                GameTimer.PauseTimer();
        }
    }
}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameTimer != null)
            {
                GameTimer.ResumeTimer();
            }
        }
    }

}
