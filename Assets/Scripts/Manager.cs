using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    [SerializeField] public Ball ball;
    [SerializeField] private Player playerOne;
    [SerializeField] private Player playerTwo;

    [SerializeField] private GameUIHandler ui;
    [SerializeField] private PlayerDataSO playMode;

    public bool gameToReset;
    public bool pauseUIShowed;

    private void Awake()
    {
        Instance = this;
        if (playMode.mode == PlayerDataSO.PLAYER_MODE.ONE)
        {
            playerTwo.IsAI = true;
        }
        else if (playMode.mode == PlayerDataSO.PLAYER_MODE.TWO)
        {
            playerOne.IsAI = false;
        }
    }
    private void Update()
    {
        if (gameToReset && !pauseUIShowed)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                this.ResetGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUIShowed)
            {
                this.ResumeGame();
            }
            else
            {
                this.PauseGame();
            }
        }
        
    }


    public void ResumeGame()
    {
        pauseUIShowed = false;
        ui.ToglePauseScreen(pauseUIShowed);
        if(!gameToReset)
        {
            ball.isEnabled = true;
            playerOne.IsEnabled = true;
            playerTwo.IsEnabled = true;
        }
    }

    private void PauseGame()
    {
        pauseUIShowed = true;
        ui.ToglePauseScreen(pauseUIShowed);
        if (!gameToReset)
        {
            ball.isEnabled = false;
            playerOne.IsEnabled = false;
            playerTwo.IsEnabled = false;
        }
    }

    private void ResetGame()
    {
        ball.isEnabled = true;
        playerOne.IsEnabled = true;
        playerTwo.IsEnabled = true;
        ball.direction = -1 * ball.direction;
        ball.ResetSpeed();
        gameToReset = false;
        ui.ToggleResumeText();
    }


    public void UpdatePlayerOneScore()
    {
        ui.Addscore(true);
    }

    public void UpdatePlayerTwoScore()
    {
        ui.Addscore(false);
    }
}
