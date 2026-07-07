using UnityEngine;

public class KeyCard_System : MonoBehaviour
{
    public DoorSwitch SwitchBehaviour;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) //cambia con input
    {
        if (collision.CompareTag("Player"))
        {
            SwitchBehaviour.DoorLockedStatus();
            Debug.Log("Door status changed");
        }
    }
}
