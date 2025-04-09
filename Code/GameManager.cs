using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public CoinManager coinManager;
    public GameObject pacmanmodel;

    [SerializeField] private PlayerMovement pacman;
    [SerializeField] private Transform pellets;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 1;

    private int ghostMultiplier = 1;
    private Vector3 pacmanStartPos;
    private GameObject[] allCoins; // Gemmer alle mønter

    private void Awake()
    {
        pacmanStartPos = pacmanmodel.transform.position;
        Debug.Log(pacmanmodel.transform.position);
        allCoins = GameObject.FindGameObjectsWithTag("Point");

        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetLives(1);
         //NewRound();
    }

    public void NewRound()
    {
        //gameOverText.enabled = false;
    foreach (GameObject coin in allCoins)
    {
        if (coin != null)
            coin.SetActive(true);
    }
        //pacmanmodel.transform.position = pacmanStartPos;

        //coinManager.RespawnLevel();
    }

   /*private void GameOver()
    {
        //gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }*/

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void PacmanEaten()
    {
        //pacman.DeathSequence();

        SetLives(lives - 1);

        if (lives == 0) {
            //GameOver();
        }
    }
}