using UnityEngine;

public class Bumper : MonoBehaviour
{
    [Header("Settings")]
    public float BounceForce;

    Animator BumperAnimations;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BumperAnimations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Si le joueur entre en collision
        if (collision.transform.CompareTag("Player")) 
        {
            //Ajoute une force d'explosion au joueur
            Rigidbody playerRB = collision.rigidbody;
            playerRB.AddExplosionForce(BounceForce, collision.contacts[0].point, 5);

            //Joue la bounce animation
            BumperAnimations.SetTrigger("Bounce");
        }
    }
}
