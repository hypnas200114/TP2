using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //Declare les variables necesaires 
    InputAction rotateMap;
    InputAction pause;
    float rotation;


    [Header("Valeurs")]
    public float speed = 1;
    public Animator animationPersonnage;

    [Header("Pause")]
    public MenuManager menuManager;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //initie les variables et inputs
        rotateMap = InputSystem.actions.FindAction("Rotate");
        pause = InputSystem.actions.FindAction("Pause");
        rotation = 0;
        pause.Enable();
        pause.performed += Pause_OnPress;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Va cherche la valeur de l'input 
        float _valeurInput = rotateMap.ReadValue<float>();
        //Applique la valeur de l'input selon la vitesse
        rotation += -_valeurInput * speed;
        //Met a jour la rotation
        transform.rotation = Quaternion.Euler(0, 0, rotation);

    }

    /// <summary>
    /// Met le jeu sur pause
    /// </summary>
    public void Pause_OnPress(InputAction.CallbackContext _context)
    {
        //Stops Time
        Time.timeScale = 0;
        //Ouvre Menu Pause
        menuManager.MenuPause(this);

        //Arrete les interaction du joueur sur le jeu
        enabled = false;
    }
}
