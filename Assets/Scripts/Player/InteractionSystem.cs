using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    private IInteractable currentInteractable = null;

    private bool isInteracting = false;

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (currentInteractable == null) return;

            isInteracting = !isInteracting;

            if (isInteracting)
            {
                currentInteractable.ExitInteract();
            }
            else
            {
                currentInteractable.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
            interactable.ShowInteractUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.CloseShopOnExitRange();
            currentInteractable = null;
            isInteracting = true;
        }
    }
}
