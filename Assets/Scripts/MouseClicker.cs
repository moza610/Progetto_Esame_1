using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mousebotton attiva un raggio invisibile dal puntatore al centro dello schermo che colpisce gli oggetti
     if (Input.GetMouseButtonDown(0))
        {
          Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;  

          
           
            if (Physics.Raycast(ray, out hit))  //Funzionamento schermi per il Puzzle 1
            {
                ClickableScreen screen = hit.collider.GetComponent<ClickableScreen>();

                 if (screen != null)
                {
                    screen.ToggleColor();
                }

                PuzzleDoorCode puzzle = hit.collider.GetComponent<PuzzleDoorCode>();
                if (puzzle != null)
                {
                    puzzle.ActiveKeyboard();
                }

            }
            
           
        }

    
    }
}
