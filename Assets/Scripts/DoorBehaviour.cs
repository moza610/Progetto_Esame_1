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
        //doorClosedPosition prende la posizione iniziale dell'oggetto assegnato, mentre doorOpenPosition la prende traslandola, però, più in alto
        doorClosedPosition = transform.position;
        doorOpenPosition = new Vector3(transform.position.x, transform.position.y + 3f, 
        transform.position.z);
    }

    void Update()
    {
        //Controlla se la porta è aperta o chiusa e chiama la funzione corrispondente
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
        //Controlla se la porta è aperta, se non lo è, la apre
        if (transform.position != doorOpenPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            doorOpenPosition, doorSpeed * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        //Controlla se la porta è chiusa, se non lo è, la chiude
        if (transform.position != doorClosedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            doorClosedPosition, doorSpeed * Time.deltaTime);
        }
    }

    //Aspetta 5 secondi, poi il bool IsDoorOpen diventa false e la porta si chiude
    public IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsDoorOpen = false;
    }
}
