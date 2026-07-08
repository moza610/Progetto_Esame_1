using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool[] ScreenStates = new bool[4]; //facciamo aprire la porta quando il prim puzzle è completo e corretto
    private bool[] targetCombination = { false, false, true, false };
    public DoorBehaviour doorScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CheckDoor()
    {
        // 1. Controllo: se la combinazione non è corretta, esci subito (Return)
        for (int i = 0; i < 4; i++)
        {
            if (ScreenStates[i] != targetCombination[i])
            {
                return; // Se ne trova uno sbagliato, si ferma qui e non fa nulla
            }
        } 

        
        if (doorScript != null)
        {
            doorScript.IsDoorOpen = true;
            Debug.Log("Combinazione corretta: Porta aperta!");
        }  
    }
    
     

    // Update is called once per frame
    void Update()
    {
        
    }
}
