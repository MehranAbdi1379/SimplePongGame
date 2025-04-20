using UnityEngine;

namespace Power_Ups
{
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] protected GameObject ball;
        [SerializeField] protected PowerUpManager powerUpManager;

        public bool PowerUpActive { get; protected set; }

        protected float PowerUpCoolDownCounter { get; set; }
        protected float PowerUpCoolDownTime { get; set; }

        protected void Start()
        {
            powerUpManager = FindObjectOfType<PowerUpManager>();
        }

        protected void Update()
        {
            if (PowerUpCoolDownCounter > 0 && PowerUpActive) PowerUpCoolDownCounter -= Time.deltaTime;

            if (PowerUpCoolDownCounter <= 0 && PowerUpActive)
            {
                ReversePowerUpEffect();
                gameObject.SetActive(false);
            }
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);
        protected abstract void ReversePowerUpEffect();

        protected void ResetPowerUpCreateCoolDownCounter()
        {
            powerUpManager.powerUpCreateCoolDownCounter = powerUpManager.PowerUpCreateCoolDownTime;
            powerUpManager.powerUpCreated = false;
        }
    }
}