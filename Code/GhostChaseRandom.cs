using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class GhostChaseRandom : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    public LayerMask wallLayer; // Tildel "Wall" layer i inspector
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public CoinManager coinManager;

    private Rigidbody2D rb;
    private Vector2[] directions = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    private Vector2 currentDirection;
    private float changeDirectionTime = 2f;
    private float changeDirectionTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        PickNewDirection();
    }

    void Update()
    {
        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0f || IsHittingWall())
        {
            PickNewDirection();
        }

        Move();
    }

    private void PickNewDirection()
    {
        // Prøv op til 10 gange at finde en gyldig retning
        for (int i = 0; i < 10; i++)
        {
            Vector2 randomDirection = directions[Random.Range(0, directions.Length)];
            if (!WillHitWall(randomDirection))
            {
                currentDirection = randomDirection;
                break;
            }
        }

        changeDirectionTimer = changeDirectionTime;
    }

    private void Move()
    {
        rb.linearVelocity = currentDirection * moveSpeed;
    }

    private bool WillHitWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, wallLayer);
        return hit.collider != null;
    }

    private bool IsHittingWall()
    {
        return WillHitWall(currentDirection);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.DeathSequence();
            //gameManager.NewRound();
            coinManager.RespawnLevel(); 
            coinManager.currentCoins = 0;
        }
    }
}
