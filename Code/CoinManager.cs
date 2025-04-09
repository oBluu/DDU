using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TMP_Text coinText;
    public TMP_Text highScoreText;
    public int currentCoins = 0;

    private int coinsCollectet;
    private GameObject[] allCoins; // Gemmer alle mønter
    private GameObject[] allPowers;


    public GhostAI ghostAI;

    public GameObject pacman;
    public GameObject blinky; // Reference til Pac-Man
    public GameObject inky;
    public GameObject pinky; // Reference til Pac-Man
    public GameObject clyde;

    private Vector3 pacmanstartPosition;
    private Vector3 blinkystartPosition;
    private Vector3 inkystartPosition;
    private Vector3 pinkystartPosition;
    private Vector3 clydestartPosition;


    void Awake()
    {
        allCoins = GameObject.FindGameObjectsWithTag("Point");
        allPowers = GameObject.FindGameObjectsWithTag("Power");
        blinkystartPosition = new Vector3 (135f, 124f,0f);
        inkystartPosition = inky.transform.position; // Gem spøgelsets rigtige startposition
        pinkystartPosition = pinky.transform.position; // Gem spøgelsets rigtige startposition
        clydestartPosition = clyde.transform.position; // Gem spøgelsets rigtige startposition
        pacmanstartPosition = pacman.transform.position; // Gem spøgelsets rigtige startposition
        instance = this;
    }

    void Start()
    {
        allCoins = GameObject.FindGameObjectsWithTag("Point"); // Find alle mønter i starten
        allPowers = GameObject.FindGameObjectsWithTag("Power");
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
        PlayerPrefs.GetInt("Highscore", 0);
        
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinsCollectet += v;
        
        PlayerPrefs.SetInt("Highscore", currentCoins);
        PlayerPrefs.GetInt("Highscore");
        coinText.text = "Score: " + currentCoins.ToString();
        CheckHighScore();

        if (coinsCollectet/10 >= allCoins.Length) // Hvis alle mønter er samlet
        {
            Invoke("RespawnLevel", 1f); // Vent 1 sekunder før banen genstarter
        }
        
    }

    void CheckHighScore()
    {
        if(currentCoins > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", currentCoins);
            UpdateUI();
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    void UpdateUI()
    {
        coinText.text = "Score: " + currentCoins.ToString();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    public void RespawnLevel()
    {
        coinsCollectet = 0; //nulstil score

        if (currentCoins > PlayerPrefs.GetInt("Highscore", 0))
        {
            UpdateUI();

        }

        // Aktivér alle mønter igen
        foreach (GameObject coin in allCoins)
        {
            if (coin != null)
                coin.SetActive(true);
        }
        foreach (GameObject power in allPowers)
        {
            if (power != null)
                power.SetActive(true);
        }

        // Reset Pac-Man til startposition
        pacman.transform.position = pacmanstartPosition;
        blinky.transform.position = blinkystartPosition;
        inky.transform.position = inkystartPosition;
        pinky.transform.position = pinkystartPosition;
        clyde.transform.position = clydestartPosition;

    }


    
}
