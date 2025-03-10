using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //Declare les variables necesaires 
    InputAction rotateMap;
    float rotation;

    [Header("Valeurs")]
    public float speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initie les variables et inputs
        rotateMap = InputSystem.actions.FindAction("Rotate");
        rotation = 0;
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
}
