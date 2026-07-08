using UnityEngine;

public class Puzzle4_MaterialShift : MonoBehaviour
{
    public Material[] Skins = new Material[5];
    public int correctMaterialIndex = 0;

    int currentInd = 0;
    Renderer renderer;

    public bool Correct
    {
        get{ return currentInd == correctMaterialIndex; }
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = Skins[currentInd];
    }

    private void OnMouseDown()
    {
        currentInd = (currentInd + 1) % Skins.Length;
        renderer.material = Skins[currentInd];
        Puzzle4.Instance.puzzleSolution();
    }
}
