using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playMode;
    public void StartSP()
    {
        playMode.mode = PlayerDataSO.PLAYER_MODE.ONE;
        StartGame();
    }

    public void StartMP()
    {
        playMode.mode = PlayerDataSO.PLAYER_MODE.TWO;
        StartGame();
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
