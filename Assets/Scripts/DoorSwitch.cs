using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    
    private DoorBehaviour doorBehaviour;

    private void Awake()
    {
        doorBehaviour = GetComponent<DoorBehaviour>();
    }

    /*private void OnMouseDown()
    {
        doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
    }*/

    private void OnMouseDown()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
        }
        if (doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.StartCoroutine(doorBehaviour.CloseDoorAfterDelay(5f));
        }*/

        doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
        
        if (doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.StartCoroutine(doorBehaviour.CloseDoorAfterDelay(5f));
        }
    }
}
