using UnityEngine;

public class Puzzle4_UpAndDown : MonoBehaviour
{
    public bool ActivatedObj = false;
    Vector3 startingPos;
    Vector3 activatedPos;
    float speedObj = 2f;

    void Awake()
    {
        //prende come posizione iniziale quella dell'oggetto assegnato, activatedPos la sposta verso l'alto
        startingPos = transform.position;
        activatedPos = new Vector3(transform.position.x,
        transform.position.y + 0.5f, transform.position.z);
    }

    void Activated()
    {
        //se l'oggetto non è nella posizione di activatedPos, lo sposta verso quella posizione
        if(transform.position != activatedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            activatedPos, speedObj * Time.deltaTime);
        }
    }

    void Deactivated()
    {
        //se l'oggetto non è nella posizione di startingPos, lo sposta verso quella posizione
        if(transform.position != startingPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            startingPos, speedObj * Time.deltaTime);
        }
    }

    void Update()
    {
        //controlla se l'oggetto è attivato o disattivato e chiama la funzione corrispondente
        if (ActivatedObj)
        {
            Activated();
        }
        else
        {
            Deactivated();
        }
    }

    private void OnMouseDown()
    {
        //all'interazione col mouse cambia lo stato e chiama l'istanza di Puzzle4 per aggiornare lo stato della soluzione
        ActivatedObj = !ActivatedObj;
        Puzzle4.Instance.puzzleSolution();
    }

}
