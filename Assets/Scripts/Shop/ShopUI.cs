using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopObj;

    private void Awake()
    {
        Close();
    }

    public void Open()
    {
        shopObj.SetActive(true);
    }

    public void Close()
    {
        shopObj.SetActive(false);
    }
}