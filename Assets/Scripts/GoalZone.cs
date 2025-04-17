using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public bool isPlayerGoal;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            var gameController = FindObjectOfType<GameManager>();
            if (isPlayerGoal) gameController.ComputerScored();
            else gameController.PlayerScored();
            FindObjectOfType<BallController>().ResetBall(isPlayerGoal);
        }
    }
}