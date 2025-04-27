using UnityEngine;

namespace Power_Ups
{
    public class SlowOpponent : PowerUp
    {
        public readonly float SlowOpponentAmount;
        private AIPaddleController paddleController;

        public SlowOpponent()
        {
            SlowOpponentAmount = 2;
            PowerUpCoolDownTime = 4f;
            PowerUpCoolDownCounter = PowerUpCoolDownTime;
        }

        public new void Start()
        {
            powerUpManager = FindObjectOfType<PowerUpManager>();
            ball = FindObjectOfType<BallController>().gameObject;
            paddleController = FindObjectOfType<AIPaddleController>();
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PowerUpActive = true;
                var ballController = ball.GetComponent<BallController>();
                ballController.currentBallState = BallController.BallState.PowerUp;
                gameObject.transform.position = new Vector3(-50, -20, 0);
                paddleController.isSlowOpponentActive = true;
                PowerUpCoolDownCounter = PowerUpCoolDownTime;
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        protected override void ReversePowerUpEffect()
        {
            var ballController = ball.GetComponent<BallController>();
            if (ballController.currentBallState == BallController.BallState.PowerUp)
                ballController.currentBallState = BallController.BallState.Normal;
            paddleController.isSlowOpponentActive = false;
            PowerUpActive = false;
            ResetPowerUpCreateCoolDownCounter();
        }
    }
}