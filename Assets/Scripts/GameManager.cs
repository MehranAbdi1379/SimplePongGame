using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore = 3;

    public int computerScore = 3;
    public UIManager uiManager;
    public bool gameIsOver;

    // Start is called before the first frame update
    private void Start()
    {
        uiManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayerScored()
    {
        computerScore--;
        uiManager.UpdateScores(playerScore, computerScore);

        if (computerScore <= 0)
        {
            uiManager.ShowWinMessage("Player");
            gameIsOver = true;
        }
    }

    public void ComputerScored()
    {
        playerScore--;
        uiManager.UpdateScores(playerScore, computerScore);

        if (playerScore <= 0)
        {
            uiManager.ShowWinMessage("Computer");
            gameIsOver = true;
        }
    }
}