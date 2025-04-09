using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public AudioSource wakawka;
    public AudioSource eheheh;
    public AudioSource taminazaefq3f;
    public AudioSource timeforafrica;
    public GameObject pacman;

    private Vector3 currentDirection = Vector3.zero;
    private Vector3 pacmanStartPos;
    private bool movementenabled = false;

    private void Awake()    
    {
        pacmanStartPos = pacman.transform.position;
        movementenabled = true;
    }

    void Update()
    {
        // Opdater bevægelsesretningen kun når en ny tast trykkes
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetDirection(Vector3.up, "MoveUp");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetDirection(Vector3.down, "MoveDown");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SetDirection(Vector3.left, "MoveLeft");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetDirection(Vector3.right, "MoveRight");
        }
        if (movementenabled == true)
        {
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
        } 
        else
        {
        movementenabled = false;
        }
    }

    private void SetDirection(Vector3 direction, string animationBool)
    {
        // Opdater bevægelsesretning
        currentDirection = direction;
    

        // Nulstil alle animationstilstande
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);

        // Aktivér den relevante animation
        animator.SetBool(animationBool, true);
    } 

    public void DeathSequence()
    {
        //movementenabled = false;
    }

    public void ResetState()
    {
        transform.position = pacmanStartPos;
        enabled = true;
    }
}