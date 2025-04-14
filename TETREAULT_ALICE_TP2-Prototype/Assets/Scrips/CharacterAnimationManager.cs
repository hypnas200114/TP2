using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    [Header("AudioClips")]
    public AudioClip pleur;
    public AudioClip musique;


    //Initialise les valeurs prive
    Animator animator;
    AudioSource audioSource;
    ParticleSystem ps;

    bool hasBeenHit = false;

    private void Start()
    {
        //Initialise les valeurs et va les chercher dans le personnage
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Effectue l'animation de douleur
        animator.SetTrigger("Impact");

        //Effectue l'effet de particule
        ps.Play();

        //si n'a jamais ete toucher
        if (!hasBeenHit) { 
        //change la musique pour des pleures
        audioSource.resource = pleur;
        audioSource.loop = true;
        audioSource.Play();
        hasBeenHit = true;
        }
    }

}
