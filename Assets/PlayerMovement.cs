using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // NEW: Required for TextMeshPro UI elements

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float doubleJumpMultiplier = 0.8f;

    public GameObject gameOverPanel;
    public GameObject gameWonPanel;

    // NEW: Reference to the UI Text
    public TMP_Text scoreText; 

    public int score = 0;
    private bool isGameOver = false;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canDoubleJump;

    private float playerWidth;
    private float playerHeight;

    private float leftBound = -11f;
    private float rightBound = 11.20f;
    private float bottomBound = -3f;
    private float topBound = 3.5f;

    void Start()
    {
        Time.timeScale = 1f;
        score = 0; 

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (gameWonPanel != null) gameWonPanel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            playerWidth = sr.bounds.extents.x;
            playerHeight = sr.bounds.extents.y;
        }

        // NEW: Update the text to show 0 right when the game starts
        UpdateScoreText(); 
    }

    void Update()
    {
        if (isGameOver) return;

        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * doubleJumpMultiplier);
                canDoubleJump = false;
            }
        }

        KeepInBounds();
    }

    void KeepInBounds()
    {
        Vector3 pos = transform.position;

        float minX = leftBound + playerWidth;
        float maxX = rightBound - playerWidth;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        float minY = bottomBound + playerHeight;
        float maxY = topBound - playerHeight;

        if (pos.y < minY)
        {
            pos.y = minY;
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                isGrounded = true;
            }
        }

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KeyGold"))
        {
            score += 25; 
            UpdateScoreText(); // NEW: Refresh the text on the screen
            Destroy(other.gameObject); 
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            if (score >= 75)
            {
                score = 100;
                UpdateScoreText(); // NEW: Show the final 100 score
                GameWon(); 
            }
        }
    }

    // NEW: Helper method to safely update the UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void GameWon()
    {
        isGameOver = true;
        if (gameWonPanel != null)
            gameWonPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void GameOverFromHealth()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}