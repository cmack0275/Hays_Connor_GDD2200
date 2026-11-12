using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    //Delegate that calls OnClickSpawn, OnClickGoToGame, OnClickGoToMenu, & OnClickQuitGame. 
    public delegate void ClickAction();
    
    //Events that the delegate calls when the ball spawn/menu/quit buttons are clicked.
    public static event ClickAction OnClickBallSpawn;
    public static event ClickAction OnClickGoToGame;
    public static event ClickAction OnClickGoToMenu;
    public static event ClickAction OnClickQuitGame;

    //Updates every frame.
    private void Update()
    {
        //When the space bar is pressed on a keyboard a ball is summoned. 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallSpawnButtonChecker();
        }
    }
    
    public void BallSpawnButtonChecker()
    {
        //If the spawn ball button or space bar have been pressed, then the ball spawn method is called.  
        OnClickBallSpawn?.Invoke();
    }
    
    public void GameButtonChecker()
    {
        //If the start button has been pressed, then the PlayToGame method is called.  
        OnClickGoToGame?.Invoke();
    }

    public void MenuButtonChecker()
    {
        //If the menu button has been pressed, then the GoToMenu method is called. 
        OnClickGoToMenu?.Invoke();
    }

    public void QuitGameButtonChecker()
    {
        //If the quit button has been pressed, then the QuitGame method is called. 
        OnClickQuitGame?.Invoke();
    }
}
