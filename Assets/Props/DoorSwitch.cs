using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    /*private DoorBehaviour doorBehaviour;
    public bool DoorOpenSwitch = true;
    public bool DoorClosedSwitch = false;

    private void OnMouseDown()
    {
        if (DoorOpenSwitch && !doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.IsDoorOpen = true;
        }
        else if (DoorClosedSwitch && doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.IsDoorOpen = false;
        }
    }*/
    private DoorBehaviour doorBehaviour;

    private void Awake()
    {
        doorBehaviour = GetComponent<DoorBehaviour>();
    }

    private void OnMouseDown()
    {
        doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
    }
}
