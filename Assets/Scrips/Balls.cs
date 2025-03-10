using UnityEngine;

public class Balls : MonoBehaviour
{
    AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound=GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Effectue le sons et particule si la velocite de l'objet et de 2 et pas des balles
        if (collision.relativeVelocity.magnitude > 2f && collision.gameObject.layer != 7)
        {
            //set random Pitch
            float ptich = (float)Random.Range(1, 10) / 10;
            sound.pitch = ptich;

            //joue le sons
            sound.Play();
        }
        
    }
}
