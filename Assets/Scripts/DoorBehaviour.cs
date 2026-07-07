using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour
{
    public bool IsDoorOpen = false;
    Vector3 doorOpenPosition;
    Vector3 doorClosedPosition;
    float doorSpeed = 3f;

    void Awake()
    {
        doorClosedPosition = transform.position;
        doorOpenPosition = new Vector3(transform.position.x, transform.position.y + 3f, 
        transform.position.z);
    }

    void Update()
    {
        if (IsDoorOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != doorOpenPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPosition, 
            doorSpeed * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPosition, 
            doorSpeed * Time.deltaTime);
        }
    }

    public IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsDoorOpen = false;
    }
}
