using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    
    private DoorBehaviour doorBehaviour;
    private bool isDoorLocked = true;
    private bool keyNeeded = true;

    private void Awake()
    {
        doorBehaviour = GetComponent<DoorBehaviour>();

        keyNeeded = !CompareTag("FreeDoor");

        if (!keyNeeded)
        {
            isDoorLocked = false;
        }
    }

    private void OnMouseDown()
    {
        doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
        
        if (doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.StartCoroutine(doorBehaviour.CloseDoorAfterDelay(5f));
        }
    }

    public void DoorUnlocked()
    {
        isDoorLocked = !isDoorLocked;
    }
}
