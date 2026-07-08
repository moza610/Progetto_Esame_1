using UnityEngine;

public class Puzzle4_UpAndDown : MonoBehaviour
{
    public bool ActivatedObj = false;
    Vector3 startingPos;
    Vector3 activatedPos;
    float speedObj = 2f;

    void Awake()
    {
        startingPos = transform.position;
        activatedPos = new Vector3(transform.position.x,
        transform.position.y + 0.5f, transform.position.z);
    }

    void Activated()
    {
        if(transform.position != activatedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            activatedPos, speedObj * Time.deltaTime);
        }
    }

    void Deactivated()
    {
        if(transform.position != startingPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            startingPos, speedObj * Time.deltaTime);
        }
    }

    void Update()
    {
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
        ActivatedObj = !ActivatedObj;
        Puzzle4.Instance.puzzleSolution();
    }

}
