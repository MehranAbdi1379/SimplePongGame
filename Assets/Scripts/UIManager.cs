using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;

    public TextMeshProUGUI winMessageText;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void UpdateScores(int playerScore, int computerScore)
    {
        playerScoreText.text = "Player: " + playerScore;
        computerScoreText.text = "Computer: " + computerScore;
    }

    public void ShowWinMessage(string winner)
    {
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = winner + " wins!";
        Invoke(nameof(ReloadScene), 2f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}