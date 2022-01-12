// Written by Joy de Ruijter
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Variables

    public float radius = 2f;
    [HideInInspector] public bool isInRange;
    [HideInInspector] public bool hasInteracted = false;
    public Transform interactionTransform;
    private Transform player;
    private PlayerManager playerManager;

    #endregion

    private void Start()
    {
        playerManager = PlayerManager.instance;
        player = playerManager.player.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        // Debug.Log("Interacting with " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
