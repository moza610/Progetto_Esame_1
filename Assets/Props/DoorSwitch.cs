using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IsDoorOpen doorBehaviour;
    private bool isDoorOpenSwitch;
    private bool isDoorClosedSwitch;
    private bool isDoorLocked = true;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player")){
            if (!isDoorLocked)
            {
                if(isDoorOpenSwitch && !doorBehaviour.isDoorOpen)
                {   
                    doorBehaviour.isDoorOpen =! doorBehaviour.isDoorOpen;
                    
                }
                else if(isDoorClosedSwitch && doorBehaviour.isDoorOpen)
                {
                    doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
                }
            }
        }
    }

    public void DoorLockedStatus()
    {
        isDoorLocked = !isDoorLocked;
    }
}
