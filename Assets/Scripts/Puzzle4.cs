using UnityEngine;

public class Puzzle4 : MonoBehaviour
{
    public static Puzzle4 Instance { get; private set; }

    private bool puzzleSolved = false;

    public Puzzle4_UpAndDown[] upAndDown = new Puzzle4_UpAndDown[3];
    public bool[] CorrectPos = new bool[3];

    public Puzzle4_MaterialShift[] MaterialShift = new Puzzle4_MaterialShift[3];

    public DoorSwitch correspondingDoor;

    void Awake()
    {
        Instance = this;
    }

    public void puzzleSolution()
    {
        if (puzzleSolved) return;

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

        Debug.Log("Puzzle risolto!");
    }
}
