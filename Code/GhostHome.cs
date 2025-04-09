/*using UnityEngine;
using System.Collections;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;
    public Ghost ghost;  // Sørg for at sætte denne i Inspector

    private void Awake()
    {
        if (ghost == null)  // Check hvis ghost ikke er tildelt
        {
            ghost = GetComponent<Ghost>();
            Debug.Log("Ghost assigned: " + (ghost != null));
        }
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        Debug.Log("Ghost assigned: " + (ghost != null));
    }

    private void OnDisable()
    {
        if (gameObject.activeInHierarchy) {
            StartCoroutine(ExitTransition());
        }
    }

    private IEnumerator ExitTransition()
    {
        if (ghost == null || ghost.movement == null)
        {
            Debug.LogError("Ghost or GhostMovement is null in ExitTransition.");
            yield break;
        }

        ghost.movement.SetDirection(Vector2.up, true);
        ghost.movement.enabled = false;

        Vector3 position = transform.position;
        float duration = 0.5f;
        float elapsed = 0f;

        // Log for debugging
        Debug.Log("Starting ExitTransition");
        Debug.Log("Inside is null? " + (inside == null));
        Debug.Log("Outside is null? " + (outside == null));
        Debug.Log("Ghost is null? " + (ghost == null));
        Debug.Log("Ghost movement is null? " + (ghost.movement == null));

        // If anything is null, abort the transition
        if (inside == null || outside == null || ghost == null || ghost.movement == null)
        {
            Debug.LogError("ExitTransition aborted due to missing reference.");
            yield break;
        }

        // Animate to the starting point
        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(position, inside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Animate exiting the ghost home
        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Pick a random direction and re-enable movement
        ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
        ghost.movement.enabled = true;
    }

    public void OnDisable()
{
    if (ghost == null)
    {
        Debug.LogError("Ghost is null in GhostChase.OnDisable()");
        return;
    }

    if (ghost.movement == null)
    {
        Debug.LogError("Ghost movement is null in GhostChase.OnDisable()");
        return;
    }

    // Resten af OnDisable logikken
}

}
*/