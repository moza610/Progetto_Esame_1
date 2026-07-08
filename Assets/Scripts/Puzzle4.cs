using UnityEngine;

public class Puzzle4 : MonoBehaviour
{
    public static Puzzle4 Instance { get; private set; }

    private bool puzzleSolved = false;

    //chiama lo script Puzzle4_UpAndDown e crea un array con gli oggetti assegnati a quello script (stessa cosa con Puzzle4_MaterialShift)
    public Puzzle4_UpAndDown[] upAndDown = new Puzzle4_UpAndDown[3];

    //inserisce nell'inspector tre bool dove inserire le risposte corrette dei primi tre oggetti
    public bool[] CorrectPos = new bool[3];

    public Puzzle4_MaterialShift[] MaterialShift = new Puzzle4_MaterialShift[3];

    public DoorSwitch correspondingDoor;

    public AudioSource audioSource;
    public AudioClip solvedClip;

    void Awake()
    {
        //mantiene l'istanza attiva
        Instance = this;
    }

    public void puzzleSolution()
    {
        //se il puzzle è già risolto non parte (per non far partire i controlli di continuo)
        if (puzzleSolved) return;

        //ogni volta che viene chiamata dagli altri due script, vede se tutti i bool di UpAndDown e
        //i materiali asseganti sono corretti (quest'ultimi dal correctMaterialIndex di Puzzle4_MaterialShift)
        //se tutto è corretto, puzzleSolved diventa true, la porta viene aperta (richiamando DoorSwitch) e parte il suono

        for (int i = 0; i < upAndDown.Length; i++)
        {
            if (upAndDown[i].ActivatedObj != CorrectPos[i])
            {
                return;
            }
        }

        foreach (Puzzle4_MaterialShift objMaterial in MaterialShift)
        {
            if (!objMaterial.Correct)
            {
                return;
            }
        }

        puzzleSolved = true;

        if (correspondingDoor != null)
        {
            correspondingDoor.DoorUnlocked();
        }

        if (audioSource != null && solvedClip != null)
        {
            audioSource.PlayOneShot(solvedClip);
        }

        Debug.Log("Puzzle risolto!");
    }
}
