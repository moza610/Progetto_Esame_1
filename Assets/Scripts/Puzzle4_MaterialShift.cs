using UnityEngine;

public class Puzzle4_MaterialShift : MonoBehaviour
{
    //crea un array dove inserire i materiali
    public Material[] Skins = new Material[5];
    public int correctMaterialIndex = 0;

    int currentInd = 0;
    Renderer objrenderer;

    public bool Correct
    {
        //segna Correct come true la posizione dell'array attuale è quella corretta
        get{ return currentInd == correctMaterialIndex; }
    }

    private void Start()
    {
        //quando il gioco inizia, assegna all'oggetto il materiale nella prima posizione dell'array (0)
        objrenderer = GetComponent<Renderer>();
        objrenderer.material = Skins[currentInd];
    }

    private void OnMouseDown()
    {
        //al clic sull'oggetto, l'array scorre di una posizione, poi chiama puzzleSolution da Puzzzle4 per controllare se è il materiale corretto o no
        currentInd = (currentInd + 1) % Skins.Length;
        objrenderer.material = Skins[currentInd];
        Puzzle4.Instance.puzzleSolution();
    }
}
