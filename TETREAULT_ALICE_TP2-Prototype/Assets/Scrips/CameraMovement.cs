using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Informations")]
    public Transform positionJoueur; //Positionnement du personnage

    Camera mCamera;
    float timeTransition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mCamera = GetComponent<Camera>(); //Prend la camera
    }

    // Update is called once per frame
    void Update()
    {
        timeTransition += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionJoueur.position.x, positionJoueur.position.y, transform.position.z), timeTransition);
    }
}
