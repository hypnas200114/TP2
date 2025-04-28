using UnityEngine;

public class Teleport : MonoBehaviour
{
    //Initialisation des valeurs
    [Header("Destination")]
    public Teleport TeleportDestination;

    [Header("Etat")]
    public bool Destination = false;

    [Header("Ressources")]
    public AudioSource SoundSource;

    private void OnTriggerEnter(Collider other)
    {


        //Si la destination de la teleportation est initialise
        if (TeleportDestination)
        {


            //Si l'objet est le joueur
            if (other.CompareTag("Player"))
            {

                //Attribue la position au joueur
                other.transform.position = MovePlayer(other.transform);
            }
        }
        else
        {
            Debug.LogError("La destination du " + name +" n'est pas initialise");
        }
    }

    /// <summary>
    /// Bouge le joueur vers le 2e teleporteur
    /// </summary>
    /// <param name="_TransformDestination">Le transform du joueur</param>
    private Vector3 MovePlayer(Transform _TransformDestination)
    {
        //Si ce teleporter est la n'est pas la destination
        if (!Destination) 
        {
            SoundSource.Play();
            //Rend la destination comme une autre destination
            TeleportDestination.Destination = true;
            return TeleportDestination.transform.position;

        }
        else
        {
            return _TransformDestination.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Si le joueur sort du colider transform reset l'etat initiale
        if(other.CompareTag("Player")) Destination = false;
    }


}
