using UnityEngine;

namespace Power_Ups
{
    public class ShrinkOpponent : PowerUp
    {
        private readonly float shrinkOpponentAmount;

        public ShrinkOpponent()
        {
            shrinkOpponentAmount = 2;
            PowerUpCoolDownTime = 4f;
            PowerUpCoolDownCounter = PowerUpCoolDownTime;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PowerUpActive = true;
                var opponent = FindObjectOfType<AIPaddleController>().gameObject;
                opponent.transform.localScale = new Vector3(opponent.transform.localScale.x,
                    opponent.transform.localScale.y / shrinkOpponentAmount, opponent.transform.localScale.z);
                var ballController = ball.GetComponent<BallController>();
                ballController.currentBallState = BallController.BallState.PowerUp;
                gameObject.transform.position = new Vector3(-20, -20, 0);
                PowerUpCoolDownCounter = PowerUpCoolDownTime;
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        protected override void ReversePowerUpEffect()
        {
            var opponent = FindObjectOfType<AIPaddleController>().gameObject;
            opponent.transform.localScale = new Vector3(opponent.transform.localScale.x,
                opponent.transform.localScale.y * shrinkOpponentAmount, opponent.transform.localScale.z);

            var ballController = ball.GetComponent<BallController>();
            if (ballController.currentBallState == BallController.BallState.PowerUp)
                ballController.currentBallState = BallController.BallState.Normal;

            PowerUpActive = false;
            ResetPowerUpCreateCoolDownCounter();
        }
    }
}