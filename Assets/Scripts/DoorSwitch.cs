using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    
    private DoorBehaviour doorBehaviour;
    private bool isDoorLocked = true;
    private bool needsKey = true;

    private void Awake()
    {
        doorBehaviour = GetComponent<DoorBehaviour>();
        needsKey = !CompareTag("noKeyDoor");

        if (!needsKey)
        {
            isDoorLocked = false;
        }
    }

    private void OnMouseDown()
    {
        if (!isDoorLocked)
        {
            doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
        }
        
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
