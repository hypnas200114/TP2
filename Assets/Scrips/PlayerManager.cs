using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Variables
    ParticleSystem ps;
    AudioSource sound;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialisation des variables
        ps = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 2f){
            Debug.Log("test");
        }
    }
}
