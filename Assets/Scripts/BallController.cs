using UnityEngine;

public class BallController : MonoBehaviour
{
    public enum BallState
    {
        Normal,
        PowerUp
    }

    public float initialSpeed = 5f;
    [SerializeField] public GameManager gameManager;
    public BallState currentBallState = BallState.Normal;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // Update is called once per frame
    private void Update()
    {
    }


    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 20f && currentBallState == BallState.Normal) rb.velocity *= 1.001f;
        // Prevent nearly-horizontal movement
        if (Mathf.Abs(rb.velocity.y) < 0.5f)
        {
            var newY = Random.Range(0.5f, 0.8f) * (Random.value < 0.5f ? -1 : 1);
            rb.velocity = new Vector2(rb.velocity.x, newY).normalized * rb.velocity.magnitude;
        }
    }

    private void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        var rand = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = 0;
        if (rand == 1) y = Random.Range(-1f, -0.5f);
        else y = Random.Range(0.5f, 1f);
        var direction = new Vector2(x, y).normalized;
        rb.velocity = direction * initialSpeed;
    }

    public void ResetBall(bool isPlayerGoal)
    {
        // Reset position to center
        transform.position = Vector3.zero;

        // Stop movement briefly (optional)
        rb.velocity = Vector2.zero;

        currentBallState = BallState.Normal;

        if (gameManager.gameIsOver == false) Invoke(nameof(LaunchBall), 1f); // 1 second pause
    }
}