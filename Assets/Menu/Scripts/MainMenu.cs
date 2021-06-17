using UnityEngine;
using System.Collections;
using RTS;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{

    protected override void SetButtons()
    {
        buttons = new string[] { "New Game", "Change Player", "Quit Game" };
    }

    protected override void HandleButton(string text)
    {
        switch (text)
        {
            case "New Game": NewGame(); break;
            case "Change Player": ChangePlayer(); break;
            case "Quit Game": ExitGame(); break;
            default: break;
        }
    }

    private void NewGame()
    {
        ResourceManager.MenuOpen = false;
        SceneManager.LoadScene("Map");
        //makes sure that the loaded level runs at normal speed
        Time.timeScale = 1.0f;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Cursor.visible = true;
        if (PlayerManager.GetPlayerName() == "")
        {
            //no player yet selected so enable SetPlayerMenu
            GetComponent<MainMenu>().enabled = false;
            GetComponent<SelectPlayerMenu>().enabled = true;
        }
        else
        {
            //player selected so enable MainMenu
            GetComponent<MainMenu>().enabled = true;
            GetComponent<SelectPlayerMenu>().enabled = false;
        }
    }

    private void ChangePlayer()
    {
        GetComponent<MainMenu>().enabled = false;
        GetComponent<SelectPlayerMenu>().enabled = true;
        SelectionList.LoadEntries(PlayerManager.GetPlayerNames());
    }
}