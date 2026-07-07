using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDoorCode : MonoBehaviour
{
    public string CorrectCode = "124569";
    public GameObject PswScreen;
    public TMP_InputField UIPswDoor;
    private bool isKeyboardActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //all'inizio deve essere spento
      if (PswScreen != null)
        {
            PswScreen.SetActive(false);
        } 
    }

    //attiviamo il tastierino per inserire la password
        public void ActiveKeyboard()
        {
        PswScreen.SetActive(true);//canvas attivo

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UIPswDoor.text = ""; // Pulisce il testo precedente
        UIPswDoor.ActivateInputField();

        isKeyboardActive = true; // Impostiamo a vero quando si apre
        PswScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        UIPswDoor.text = "";
        UIPswDoor.ActivateInputField();
     
    }

    //controlla se la psw è corretta
    public void CheckPassword(string userInput)
    {
      if (userInput == CorrectCode)
        {
            Debug.Log("Password Corretta");
        }
        else
        {
            Debug.Log("Password Sbagliata");
            UIPswDoor.text = "";
            UIPswDoor.ActivateInputField(); //riporta il cursore nella casella
        }
    }

    void CloseKeyboard() 
    {
      PswScreen.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;

      isKeyboardActive = false; // Impostiamo a falso quando si chiude
      PswScreen.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked; // Blocca il mouse
       
    }
    
    // Update is called once per frame
    void Update()
    {
     // Se il tastierino è attivo e premi ESC, allora chiudi
        if (isKeyboardActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseKeyboard();
        }   
    }
}
