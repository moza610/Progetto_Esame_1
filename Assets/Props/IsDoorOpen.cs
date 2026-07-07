using UnityEngine;

public class IsDoorOpen : MonoBehaviour
{
    public bool isDoorOpen = false; //cambia in rivate a lavoro finito
    private Vector3 doorStartPosition;
    private Vector3 doorOpenPosition;
    float speedAnimation = 10f;

    void Start()
    {
        doorStartPosition = transform.position;
        doorOpenPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);


    }

    void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
        }
        else if (!isDoorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != doorOpenPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            doorOpenPosition, speedAnimation * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        if (transform.position != doorStartPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            doorStartPosition, speedAnimation * Time.deltaTime);
        }
    }
}
