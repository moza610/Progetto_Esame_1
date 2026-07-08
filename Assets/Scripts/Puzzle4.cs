using UnityEngine;

public class Puzzle4 : MonoBehaviour
{
    private bool activatedObj = true;
    Vector3 startingPos;
    Vector3 activatedPos;
    float speedObj = 2f;

    void Awake()
    {
        startingPos = transform.position;
        activatedPos = new Vector3(transform.position.x,
        transform.position.y + 1f, transform.position.z);
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

    private void OnMouseDown()
    {
        activatedObj = !activatedObj;
    }

    void Update()
    {
        if (activatedObj)
        {
            Activated();
        }
        else
        {
            Deactivated();
        }
    }
}
