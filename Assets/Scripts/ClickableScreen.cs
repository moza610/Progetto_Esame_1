using UnityEngine;

public class ClickableScreen : MonoBehaviour
{
    
    public Material ScreenRed;
    public Material ScreenGreen;
 

    private Renderer rend;
    private bool isOn = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (ScreenRed != null && rend != null)
        {
            rend.material = ScreenRed; 
        }

    }

    public void ToggleColor()
    {
        isOn = !isOn;
          
   
        if (isOn == true)
        {
            rend.material = ScreenGreen;
        }
        else
        {
            rend.material = ScreenRed;
        }
    } 
}