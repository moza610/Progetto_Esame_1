using UnityEngine;

public class Puzzle4_MaterialShift : MonoBehaviour
{
    public Material[] Skins = new Material[5];
    public int correctMaterialIndex = 0;

    int currentInd = 0;
    Renderer objrenderer;

    public bool Correct
    {
        get{ return currentInd == correctMaterialIndex; }
    }

    private void Start()
    {
        objrenderer = GetComponent<Renderer>();
        objrenderer.material = Skins[currentInd];
    }

    private void OnMouseDown()
    {
        currentInd = (currentInd + 1) % Skins.Length;
        objrenderer.material = Skins[currentInd];
        Puzzle4.Instance.puzzleSolution();
    }
}
