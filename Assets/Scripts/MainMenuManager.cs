using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public static MainMenuManager Instance;
    public Difficulty selectedDifficulty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this alive between scenes
        }
        else
        {
            Destroy(gameObject); // Only one allowed
        }
    }

    public void SetDifficulty(int difficultyIndex)
    {
        selectedDifficulty = (Difficulty)difficultyIndex;
    }

    public void OnClickEasy()
    {
        SetDifficulty(0); // Easy
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickNormal()
    {
        SetDifficulty(1); // Normal
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickHard()
    {
        SetDifficulty(2); // Hard
        SceneManager.LoadScene("MainScene");
    }
}