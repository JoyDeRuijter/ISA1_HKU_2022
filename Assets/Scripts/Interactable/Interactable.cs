// Written by Joy de Ruijter
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Variables

    public float radius = 1.2f;
    [HideInInspector] public bool isInRange;
    [HideInInspector] public bool hasInteracted = false;
    public Transform interactionTransform;
    [HideInInspector] public Transform player;
    private PlayerManager playerManager;
    private bool needsOutlineComponent;
    [HideInInspector] public MeshOutliner meshOutliner;
    [HideInInspector] public bool cancelOutline;
    private float distance;

    #endregion

    private void Start()
    {
        playerManager = PlayerManager.instance;
        player = playerManager.player.GetComponent<Transform>();

        meshOutliner = GetComponentInChildren<MeshOutliner>();
        if (meshOutliner == null && !needsOutlineComponent)
        {
            GetComponentInChildren<Transform>().gameObject.AddComponent<MeshOutliner>();
            needsOutlineComponent = true;
        }
    }

    protected virtual void Update()
    {
        if (!hasInteracted)
        {
            distance = Vector3.Distance(player.position, interactionTransform.position);

            UpdateOutlines();

            if (distance <= radius && Input.GetKeyDown(KeyCode.E))
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

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    private void UpdateOutlines()
    {
        if (cancelOutline)
            GetComponentInChildren<MeshOutliner>().enabled = false;
        if (distance <= radius && !cancelOutline)
            GetComponentInChildren<MeshOutliner>().enabled = true;
        else if (distance > radius)
            GetComponentInChildren<MeshOutliner>().enabled = false;
    }
}
