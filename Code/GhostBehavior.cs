/*using UnityEngine;

[RequireComponent(typeof(Ghost))]
public abstract class GhostBehavior : MonoBehaviour
{
    protected Ghost ghost;
    public float duration;

    private void Awake()
    {
        ghost = GetComponent<Ghost>();
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
    if (ghost == null)
    {
        Debug.LogError("Ghost is null in GhostBehavior.Disable()");
        return;
    }

    enabled = false;
    CancelInvoke();
    }
}
*/