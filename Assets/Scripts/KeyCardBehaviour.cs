using UnityEngine;

public class KeyCardBehaviour : MonoBehaviour
{
    
    [SerializeField] DoorSwitch correspondingDoor;
    [SerializeField] AudioClip pickupSound;

    //quando il giocatore collide con la keycard, la keycard scompare, la porta assegnata ad essa si sblocca e parte un suono
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            correspondingDoor.DoorUnlocked();

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }
            Debug.Log(gameObject.name + " ottenuta!");
            Destroy(gameObject);
        }
    }
}

