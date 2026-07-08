using UnityEngine;

public class DoorController : MonoBehaviour
{
     public bool[] screenStates = new bool[4]; //facciamo aprire la porta quando il prim puzzle è completo e corretto

    private bool[] targetCombination = { false, false, true, false };
    public DoorBehaviour doorScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

       public void CheckDoor()
    {
        bool isCorrect = true;
        for (int i = 0; i < 4; i++) //controlliamo se gli schermi sono nell'ordine giusto, uno alla volta
        {
            if (screenStates[i] != targetCombination[i])
                isCorrect = false;
        }  

        // Se la combinazione è corretta, apri la porta!
        if (isCorrect)
        {
            doorScript.IsDoorOpen = true; // Questo fa partire l'animazione della porta
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
