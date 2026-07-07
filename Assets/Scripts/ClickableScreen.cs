using UnityEditor;
using UnityEngine;

public class ClickableScreen : MonoBehaviour
{
    public Material ScreenRed;
    public Material ScreenGreen;

    private Renderer rend;
    private bool isOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rend = GetComponent<Renderer>();
      rend.material = ScreenRed; 
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
