using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    //Instenciations
    [Header("Fonctionnement Globale")]
    public EventSystem EventSys;
    public AudioMixer AudioMixerPrincipale;

    //Instenciations des parametres de menu
    [Header("CanvasGroup")]
    public CanvasGroup CGMenuPrincipale;
    public CanvasGroup CGMenuParametre;

    //Instenciation des premiers selectionner (Pour l`unitlisation de la manette)
    [Header("First Selected")]
    public GameObject FSMenuPrincipale;
    public GameObject FSMenuParametre;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialise le menu
        BtnRetour_OnClick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Effectuer la transition vers le scene de jeu
    /// </summary>
    public void BtnPlay_OnClick()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Ferme le programe
    /// </summary>
    public void BtnQuit_OnClick() 
    {
        Application.Quit();
    }

    /// <summary>
    /// Ouvre le second menu et ferme le permier
    /// </summary>
    public void BtnParametre_OnClick()
    {
        //Ouvre le second menu
        CGMenuParametre.alpha = 1;
        CGMenuParametre.interactable = true;
        CGMenuParametre.blocksRaycasts = true;

        //Ferme le premier menu
        CGMenuPrincipale.alpha = 0;
        CGMenuPrincipale.interactable = false;
        CGMenuPrincipale.blocksRaycasts = false;

        //set le premier item selectionner
        EventSys.firstSelectedGameObject = FSMenuParametre;

    }

    /// <summary>
    /// Ouvre le premier menu et ferme le second
    /// </summary>
    public void BtnRetour_OnClick()
    {
        //Ferme le second menu
        CGMenuParametre.alpha = 0;
        CGMenuParametre.interactable = false;
        CGMenuParametre.blocksRaycasts = false;

        //Ouvre le premier menu
        CGMenuPrincipale.alpha = 1;
        CGMenuPrincipale.interactable = true;
        CGMenuPrincipale.blocksRaycasts = true;

        EventSys.firstSelectedGameObject = FSMenuPrincipale;
    }

    /// <summary>
    /// Change le volume principale
    /// </summary>
    /// <param name="_value">Valeur du volume</param>
    public void SldSonsMaster_OnChange(float _value)
    {
       AudioMixerPrincipale.SetFloat("MasterVolume",Mathf.Log(_value)*20);
       
    }

    /// <summary>
    /// Change le volume de la musique
    /// </summary>
    /// <param name="_value">Valeur du volume</param>
    public void SldSonsMusic_OnChange(float _value)
    {
        AudioMixerPrincipale.SetFloat("MusicVolume", Mathf.Log(_value) * 20);
    }

    /// <summary>
    /// Change le volume des effets sonores
    /// </summary>
    /// <param name="_value">Valeur du volume</param>
    public void SldSonsSFX_OnChange(float _value)
    {
        AudioMixerPrincipale.SetFloat("SFXVolume", Mathf.Log(_value) * 20);
    }
}
