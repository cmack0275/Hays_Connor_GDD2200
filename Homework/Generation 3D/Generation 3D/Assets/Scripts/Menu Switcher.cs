using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitcher : MonoBehaviour
{
    private void OnEnable()
    {
        //When one of the buttons is pressed, the event manager signals that it was clicked. The method 
        //corresponding to that call is then turned on and done.
        EventManager.OnClickGoToGame += PlayTheGame;
        EventManager.OnClickGoToMenu += LoadTheMenu;
        EventManager.OnClickQuitGame += QuitTheGame;
    }

    private void OnDisable()
    {
        //When none of the buttons are pressed, the event manager keeps the methods disabled. This is to prevent
        //a major fuck up and potential memory leaks.
        EventManager.OnClickGoToGame -= PlayTheGame;
        EventManager.OnClickGoToMenu -= LoadTheMenu;
        EventManager.OnClickQuitGame -= QuitTheGame;
    }
    
    //When a button is pressed, the game scene of SPHERES is loaded.
    public void PlayTheGame()
    {
        Time.timeScale = 1f; //Makes the game wait a small moment, so the scene can be properly loaded without thing breaking.
        SceneManager.LoadScene("SPHERES");
    }

    //When a button is pressed, the menu scene is loaded.
    public void LoadTheMenu()
    {
        Time.timeScale = 1f; //Makes the game wait a small moment, so the scene can be properly loaded without thing breaking.
        SceneManager.LoadScene("Menu");
    }
    
    //Quits the game if in a build.
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
