using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{

    [Header("Ressources")]
    public int Level;
    public ParticleSystem MainParticleSystem;
    public AudioSource SoundSource;

    float Timer=1;
    bool PlayParticule = false;

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0 && PlayParticule )
        {
            Timer -= Time.deltaTime;
        }
        else if(PlayParticule && Timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si le joueur entre dans la zone de fin
        if (other.CompareTag("Player"))
        {
            //Joue les particules de victoire
            MainParticleSystem.Play();
            SoundSource.Play();
            PlayParticule = true;

            //Change les dernier niveau terminer pour debloquer le prochain
            if (PlayerPrefs.GetInt("LevelDone")< Level)
            {
                PlayerPrefs.SetInt("LevelDone",Level);
            }
        }
    }
}
