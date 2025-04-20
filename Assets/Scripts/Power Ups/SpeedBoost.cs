using UnityEngine;

namespace Power_Ups
{
    public class SpeedBoost : PowerUp
    {
        private readonly float speedBoostAmount;

        public SpeedBoost()
        {
            speedBoostAmount = 2;
            PowerUpCoolDownTime = 1f;
            PowerUpCoolDownCounter = PowerUpCoolDownTime;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PowerUpActive = true;
                var rigidBody = ball.GetComponent<Rigidbody2D>();
                rigidBody.velocity *= speedBoostAmount;
                var ballController = ball.GetComponent<BallController>();
                ballController.currentBallState = BallController.BallState.PowerUp;
                gameObject.transform.position = new Vector3(-20, -20, 0);
                PowerUpCoolDownCounter = PowerUpCoolDownTime;
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        protected override void ReversePowerUpEffect()
        {
            var ballController = ball.GetComponent<BallController>();
            var rigidBody = ball.GetComponent<Rigidbody2D>();
            if (ballController.currentBallState == BallController.BallState.PowerUp)
            {
                rigidBody.velocity /= speedBoostAmount;
                ballController.currentBallState = BallController.BallState.Normal;
            }

            PowerUpActive = false;
            ResetPowerUpCreateCoolDownCounter();
        }
    }
}