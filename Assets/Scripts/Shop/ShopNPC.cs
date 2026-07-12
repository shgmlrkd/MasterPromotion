using UnityEngine;

public class ShopNPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ShopUI shopUI;

    [SerializeField]
    private GameObject interactUI;

    private void Awake()
    {
        interactUI.SetActive(false);
    }

    public void ShowInteractUI()
    {
        interactUI.SetActive(true);
    }

    public void HideInteractUI()
    {
        interactUI.SetActive(false);
    }

    public void Interact()
    {
        shopUI.Open();
        HideInteractUI();
    }

    public void ExitInteract()
    {
        shopUI.Close();
        ShowInteractUI();
    }

    public void CloseShopOnExitRange()
    {
        shopUI.Close();
        HideInteractUI();
    }
}