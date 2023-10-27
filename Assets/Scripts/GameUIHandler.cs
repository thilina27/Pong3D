using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI p1Score;
    [SerializeField] private TextMeshProUGUI p2Score;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject pause;

    private int scoreP1;
    private int scoreP2;

    private void Awake()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        p1Score.SetText(scoreP1.ToString());
        p2Score.SetText(scoreP2.ToString());
    }
    public void Addscore(bool playerOne)
    {
        if(playerOne)
        {
            scoreP1++;
            p1Score.SetText(scoreP1.ToString());
        }
        else
        {
            scoreP2++;
            p2Score.SetText(scoreP2.ToString());
        }
        this.ToggleResumeText();
    }

    public void ToggleResumeText()
    {
        resume.SetActive(!resume.activeSelf);
    }

    public void ToglePauseScreen(bool active)
    {
        pause.SetActive(active);
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
