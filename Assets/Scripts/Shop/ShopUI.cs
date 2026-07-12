using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopObj;

    [SerializeField]
    private GameObject inventoryObj;

    private void Start()
    {
        Close();
    }

    public void Open()
    {
        shopObj.SetActive(true);
        inventoryObj.SetActive(true);
    }

    public void Close()
    {
        shopObj.SetActive(false);
        inventoryObj.SetActive(false);
    }
}