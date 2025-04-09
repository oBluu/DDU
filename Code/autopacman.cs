using UnityEngine;
using UnityEngine.AI;

public class autopacman : MonoBehaviour
{
    public Transform pacman;
    public GameObject pacmanz;
        
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false; // Sørg for, at han ikke roterer undervejs
        agent.updateUpAxis = false; // Gør det kompatibelt med 2D
    }

    // Update is called once per frame
    void Update()
    {
        if (pacman != null)
        {
            agent.SetDestination(pacman.position);
        }
    }
}
