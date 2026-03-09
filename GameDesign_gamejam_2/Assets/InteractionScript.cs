using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField]
    private float interactRange;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField] 
    private Transform cameraObject;

    [SerializeField]
    private KeyCode interactionButton;

    private void Update()
    {
        if (Input.GetKeyDown(interactionButton))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraObject.position, cameraObject.TransformDirection(Vector3.forward), out hit, interactRange, layerMask))
        {
            if (hit.transform.TryGetComponent(out InteractButton button))
            {
                button.Interact();
            }

            if (hit.transform.tag.ToLower() == "button")
            {
                Debug.Log("Hurray!!!");
            }
            //TryInteract(hit); // Separate method for tag and interaction check
        }
        else
        {
            Debug.Log("Raycast didn't hit anything");
        }
    }
}
