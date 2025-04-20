using UnityEngine;

namespace Power_Ups
{
    public class SlowOpponent : PowerUp
    {
        public readonly float SlowOpponentAmount;

        public SlowOpponent()
        {
            SlowOpponentAmount = 2;
            PowerUpCoolDownTime = 4f;
            PowerUpCoolDownCounter = PowerUpCoolDownTime;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PowerUpActive = true;
                var ballController = ball.GetComponent<BallController>();
                ballController.currentBallState = BallController.BallState.PowerUp;
                gameObject.transform.position = new Vector3(-50, -20, 0);
                PowerUpCoolDownCounter = PowerUpCoolDownTime;
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        protected override void ReversePowerUpEffect()
        {
            PowerUpActive = false;
            ResetPowerUpCreateCoolDownCounter();
        }
    }
}