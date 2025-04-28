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
    public AudioSource Click;

    //Instenciations des parametres de menu
    [Header("CanvasGroup")]
    public CanvasGroup CGMenuPrincipale;
    public CanvasGroup CGMenuParametre;
    public CanvasGroup CGMenuLevel;

    //Instenciation des premiers selectionner (Pour l`unitlisation de la manette)
    [Header("First Selected")]
    public GameObject FSMenuPrincipale;
    public GameObject FSMenuParametre;
    public GameObject FSMenuLevel;

    [Header("Level Button")]
    public Button[] ArLevelButton;

    private PlayerControl playerControl;



    private void Awake()
    {

        //Initialise le menu si c'est la scene du menu principale
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            BtnRetour_OnClick();
            btnRetourMainMenu_Onclick();
            SetDoneLevel();
        }
        else
        {
            //Ferme le second menu
            CGMenuParametre.alpha = 0;
            CGMenuParametre.interactable = false;
            CGMenuParametre.blocksRaycasts = false;

            //Ferme le premier menu
            CGMenuPrincipale.alpha = 0;
            CGMenuPrincipale.interactable = false;
            CGMenuPrincipale.blocksRaycasts = false;
        }

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
        Click.Play();
        //Ouvre le second menu
        CGMenuLevel.alpha = 1;
        CGMenuLevel.interactable = true;
        CGMenuLevel.blocksRaycasts = true;

        //Ferme le premier menu
        CGMenuPrincipale.alpha = 0;
        CGMenuPrincipale.interactable = false;
        CGMenuPrincipale.blocksRaycasts = false;

        //set le premier item selectionner
        EventSys.firstSelectedGameObject = FSMenuLevel;
    }

    /// <summary>
    /// Ferme le programe
    /// </summary>
    public void BtnQuit_OnClick() 
    {
        Click.Play();
        Application.Quit();
    }

    /// <summary>
    /// Ouvre le second menu et ferme le permier
    /// </summary>
    public void BtnParametre_OnClick()
    {
        Click.Play();
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
        Click.Play();
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

    public void MenuPause(PlayerControl _playerControl)
    {
        BtnRetour_OnClick();
        playerControl = _playerControl;
    }

    public void Resume()
    {
        Click.Play();
        //recommence le temps
        Time.timeScale = 1;
        //Reactive les controle du joueur
        playerControl.enabled = true;

        //Cache le menu
        //Ferme le second menu
        CGMenuParametre.alpha = 0;
        CGMenuParametre.interactable = false;
        CGMenuParametre.blocksRaycasts = false;

        //Ferme le premier menu
        CGMenuPrincipale.alpha = 0;
        CGMenuPrincipale.interactable = false;
        CGMenuPrincipale.blocksRaycasts = false;

    }

    public void btnLVL01_Onclick()
    {
        //Load Scene
        Click.Play();
        SceneManager.LoadScene(1);
    }

    public void btnLVL02_Onclick()
    {
        //Load Scene
        Click.Play();
        SceneManager.LoadScene(2);
    }
    public void btnLVL03_Onclick()
    {
        //Load Scene
        Click.Play();
        SceneManager.LoadScene(3);
    }
    public void btnLVL04_Onclick()
    {
        //Load Scene
        Click.Play();
        SceneManager.LoadScene(4);
    }

    public void btnLVL05_Onclick()
    {
        //Load Scene
        Click.Play();
        SceneManager.LoadScene(5);
    }

    public void btnRetourMainMenu_Onclick() 
    {
        Click.Play();
        //Ferme le second menu
        CGMenuLevel.alpha = 0;
        CGMenuLevel.interactable = false;
        CGMenuLevel.blocksRaycasts = false;

        //Ouvre le premier menu
        CGMenuPrincipale.alpha = 1;
        CGMenuPrincipale.interactable = true;
        CGMenuPrincipale.blocksRaycasts = true;

        EventSys.firstSelectedGameObject = FSMenuPrincipale;
    }

    public void SetDoneLevel()
    {
        //Pour chaque bouton dans la liste de bouton
        for(int x = 0; x < ArLevelButton.Length; x++)
        {
            //Si le niveau est fais met les dernier niveau active et le prochain
            ArLevelButton[x].interactable = x <= PlayerPrefs.GetInt("LevelDone");
        }
    }

    public void BackToMainMenu_OnClick()
    {
        Click.Play();
        SceneManager.LoadScene(0);
    }
}
