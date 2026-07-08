using UnityEngine;

//gestisce la chiusura della porta e il suo stato di blocco
public class DoorSwitch : MonoBehaviour
{
    //richiama doorBehaviour per aprire e chiudere la porta
    private DoorBehaviour doorBehaviour;
    private bool isDoorLocked = true;
    private bool keyNeeded = true;

    private void Awake()
    {
        //ottiene il componente DoorBehaviour associato a questo oggetto
        doorBehaviour = GetComponent<DoorBehaviour>();

        //vede se la porta ha un tag FreeDoor, in quel caso sarà sempre sbloccata
        keyNeeded = !CompareTag("FreeDoor");

        if (!keyNeeded)
        {
            isDoorLocked = false;
        }
    }
    
    //cosa succede cliccando la porta
    private void OnMouseDown()
    {
        //se è bloccata non succede niente, altrimenti attiva doorbehaviour, quando si apre, parte il timer di 5 secondi per richiuderla
        if (isDoorLocked) return;
        
        doorBehaviour.IsDoorOpen = !doorBehaviour.IsDoorOpen;
        
        if (doorBehaviour.IsDoorOpen)
        {
            doorBehaviour.StartCoroutine(doorBehaviour.CloseDoorAfterDelay(5f));
        }
    }

    //metodo pubblico per sbloccare la porta, comunica con KeyBehaviour
    public void DoorUnlocked()
    {
        isDoorLocked = !isDoorLocked;
    }
}
