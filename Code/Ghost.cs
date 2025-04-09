/*using UnityEngine;

public class Ghost : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        home = GetComponent<GhostHome>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        ResetState();
    }

    public void ResetState()
    {
gameObject.SetActive(true);

    if (frightened != null) frightened.Disable();
    if (chase != null) chase.Disable();
    if (scatter != null) scatter.Enable();

    if (home != null && home != initialBehavior) home.Disable();
    if (initialBehavior != null) initialBehavior.Enable();
    }
    
    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled) {
                GameManager.Instance.GhostEaten(this);
            } else {
                GameManager.Instance.PacmanEaten();
            }
        }
    }

}

*/