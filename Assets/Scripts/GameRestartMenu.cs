using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRestartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        about.SetActive(false);
    }

    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        about.SetActive(true);
    }
}
