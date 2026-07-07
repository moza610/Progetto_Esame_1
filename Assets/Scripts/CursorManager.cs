using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Cursor.visible = true;
     Cursor.lockState = CursorLockMode.Locked;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
