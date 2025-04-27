using UnityEngine;

namespace Power_Ups
{
    public class ExtraLife : PowerUp
    {
        public ExtraLife()
        {
            PowerUpCoolDownTime = 5f;
            PowerUpCoolDownCounter = PowerUpCoolDownTime;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PowerUpActive = true;
                var gameManager = FindObjectOfType<GameManager>();
                gameManager.playerScore += 1;
                var uiManager = FindObjectOfType<UIManager>();
                uiManager.UpdateScores(gameManager.playerScore, gameManager.computerScore);
                var ballController = ball.GetComponent<BallController>();
                ballController.currentBallState = BallController.BallState.PowerUp;
                gameObject.transform.position = new Vector3(-40, -20, 0);
                PowerUpCoolDownCounter = PowerUpCoolDownTime;
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        protected override void ReversePowerUpEffect()
        {
            var ballController = ball.GetComponent<BallController>();
            if (ballController.currentBallState == BallController.BallState.PowerUp)
                ballController.currentBallState = BallController.BallState.Normal;

            PowerUpActive = false;
            ResetPowerUpCreateCoolDownCounter();
        }
    }
}