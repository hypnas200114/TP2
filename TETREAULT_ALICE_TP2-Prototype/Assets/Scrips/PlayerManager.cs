using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Variables
    public ParticleSystem ps;
    AudioSource sound;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialisation des variables
        sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        //Effectue le sons et particule si la velocite de l'objet et de 2 et pas des balles
        if(collision.relativeVelocity.magnitude > 2f && collision.gameObject.layer !=7 ){
            ps.Play();
            
            //Si la velocite divise par 10 est plus grand que 1
            if(collision.relativeVelocity.magnitude/10 > 1)
            {
                //met le volume a 1
                sound.volume = 1;
            }
            else
            {
                //Met le volume relatif
                sound.volume = collision.relativeVelocity.magnitude / 10;
            }

            //set random Pitch
            float ptich = (float)Random.Range(5, 10) / 10;
            sound.pitch = ptich;

            //joue le sons
            sound.Play();
        }


        
    }
}
