using UnityEngine;

public class AIPaddleController : MonoBehaviour
{
    public Transform ball;
    public Rigidbody2D ballRb;
    public float followRange = 0.25f;

    public Rigidbody2D rb;

    private float _speed = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var difficulty = MainMenuManager.Instance.selectedDifficulty;

        _speed = difficulty switch
        {
            MainMenuManager.Difficulty.Easy => 3f,
            MainMenuManager.Difficulty.Normal => 6f,
            MainMenuManager.Difficulty.Hard => 10f,
            _ => _speed
        };
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var direction = 0f;

        if (ballRb.velocity.x > 0) // ball going toward AI
        {
            if (ball.position.y > transform.position.y + followRange) direction = 1f;
            else if (ball.position.y < transform.position.y - followRange) direction = -1f;

            rb.velocity = new Vector2(0, direction * _speed);

            var clampedY = Mathf.Clamp(transform.position.y, -2.8f, 2.8f);
            transform.position = new Vector2(transform.position.x, clampedY);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}