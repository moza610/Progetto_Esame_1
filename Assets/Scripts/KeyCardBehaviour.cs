using UnityEngine;

public class KeyCardBehaviour : MonoBehaviour
{

    [SerializeField] DoorSwitch correspondingDoor;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            correspondingDoor.DoorUnlocked();
            Debug.Log(gameObject.name + " ottenuta!");
            Destroy(gameObject);
        }
    }
}
