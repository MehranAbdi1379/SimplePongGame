using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore = 3;

    public int computerScore = 3;
    public UIManager uiManager;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayerScored()
    {
        computerScore--;
        uiManager.UpdateScores(playerScore, computerScore);

        if (computerScore <= 0) uiManager.ShowWinMessage("Computer");
    }

    public void ComputerScored()
    {
        playerScore--;
        uiManager.UpdateScores(playerScore, computerScore);

        if (computerScore <= 0) uiManager.ShowWinMessage("Player");
    }
}