using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float powerUpCreateCoolDownCounter = 5f;
    [SerializeField] private GameObject speedBoostObject;
    [SerializeField] private GameObject slowOpponentObject;
    [SerializeField] private GameObject extraLifeObject;
    [SerializeField] private GameObject shrinkOpponentObject;
    public bool powerUpCreated;
    public float PowerUpCreateCoolDownTime { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        PowerUpCreateCoolDownTime = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (powerUpCreateCoolDownCounter > 0) powerUpCreateCoolDownCounter -= Time.deltaTime;

        if (powerUpCreateCoolDownCounter <= 0 && !powerUpCreated)
        {
            var random = Random.Range(0, 4);

            GameObject currentPowerUp;

            switch (random)
            {
                case 0:
                    currentPowerUp = speedBoostObject;
                    break;
                case 1:
                    currentPowerUp = slowOpponentObject;
                    break;
                case 2:
                    currentPowerUp = extraLifeObject;
                    break;
                case 3:
                    currentPowerUp = shrinkOpponentObject;
                    break;
                default:
                    currentPowerUp = speedBoostObject;
                    break;
            }

            currentPowerUp.SetActive(true);
            var randX = Random.Range(-5f, 5f);
            var randY = Random.Range(-3.0f, 3.0f);
            currentPowerUp.transform.position = new Vector3(randX, randY, 0);
            powerUpCreated = true;
        }
    }
}