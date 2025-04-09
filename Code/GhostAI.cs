using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public Transform pacman; // Reference til Pac-Man
    private NavMeshAgent agent;
    public CoinManager coinManager;
    public static Vector3 startPosition;
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public GameObject ghost;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Sørg for, at han ikke roterer undervejs
        agent.updateUpAxis = false; // Gør det kompatibelt med 2D
    }

    void Update()
    {
        if (pacman != null)
        {
            agent.SetDestination(pacman.position);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collider din bitch");
            playerMovement.DeathSequence();
            //gameManager.NewRound();
            Debug.Log("ny runde virker?");
            coinManager.RespawnLevel(); 
            coinManager.currentCoins = 0;
        }
    }
}
