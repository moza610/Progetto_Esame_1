using UnityEngine;

public class KeyCardBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

