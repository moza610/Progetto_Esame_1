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
     if (Input.GetMouseButtonDown(0))
        {
          Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;  

          

            if (Physics.Raycast(ray, out hit))
            {
                ClickableScreen screen = hit.collider.GetComponent<ClickableScreen>();

                 if (screen != null)
                {
                    screen.ToggleColor();
                }
            }
            
           
        }
    }
}
