using Power_Ups;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float powerUpCreateCoolDownCounter = 5f;
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

            var currentPowerUp = new GameObject("PowerUp");

            switch (random)
            {
                case 0:
                    var sr = currentPowerUp.AddComponent<SpriteRenderer>();

                    sr.sprite = Resources.Load<Sprite>("BasicShapes/Square");
                    sr.color = Color.yellow;

                    var collider = currentPowerUp.AddComponent<BoxCollider2D>();
                    collider.isTrigger = true;

                    currentPowerUp.AddComponent<SpeedBoost>();
                    break;
                case 1:
                    sr = currentPowerUp.AddComponent<SpriteRenderer>();

                    sr.sprite = Resources.Load<Sprite>("BasicShapes/Circle");
                    sr.color = Color.blue;


                    var circleCollider = currentPowerUp.AddComponent<CircleCollider2D>();
                    circleCollider.isTrigger = true;

                    currentPowerUp.AddComponent<SlowOpponent>();
                    break;
                case 2:
                    sr = currentPowerUp.AddComponent<SpriteRenderer>();

                    sr.sprite = Resources.Load<Sprite>("BasicShapes/Capsule");
                    sr.color = Color.red;

                    collider = currentPowerUp.AddComponent<BoxCollider2D>();
                    collider.isTrigger = true;

                    currentPowerUp.AddComponent<ShrinkOpponent>();
                    break;
                case 3:
                    sr = currentPowerUp.AddComponent<SpriteRenderer>();

                    sr.sprite = Resources.Load<Sprite>("BasicShapes/Triangle");
                    sr.color = Color.magenta;

                    collider = currentPowerUp.AddComponent<BoxCollider2D>();
                    collider.isTrigger = true;

                    currentPowerUp.AddComponent<ExtraLife>();
                    break;
            }

            // var rb = currentPowerUp.AddComponent<Rigidbody2D>();
            // rb.gravityScale = 0f;
            // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            // rb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));

            // currentPowerUp.GetComponent<Collider2D>().sharedMaterial =
            //     Resources.Load<PhysicsMaterial2D>("Materials/BouncyMaterial");
            currentPowerUp.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
            currentPowerUp.SetActive(true);
            var randX = Random.Range(-5f, 5f);
            var randY = Random.Range(-3.0f, 3.0f);
            currentPowerUp.transform.position = new Vector3(randX, randY, 0);
            powerUpCreated = true;
        }
    }
}