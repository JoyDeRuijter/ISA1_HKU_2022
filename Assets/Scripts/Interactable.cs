// Written by Joy de Ruijter
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Variables

    public float radius = 2f;
    [HideInInspector] public bool isFocussed, hasInteracted;
    public Transform interactionTransform;
    private Transform player;

    #endregion

    private void Awake()
    {
        isFocussed = false;
        hasInteracted = false;
    }

    private void Update()
    {
        if (isFocussed && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    public void OnFocus(Transform playerTransform)
    { 
        isFocussed = true;
        player = playerTransform;
        hasInteracted = false;    
    }

    public void OnDefocus()
    { 
        isFocussed = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
