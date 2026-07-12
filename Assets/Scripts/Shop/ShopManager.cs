using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private ItemData[] shopItems;

    [SerializeField]
    private Inventory inventory;

    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void BuyItem(int index)
    {
        ItemData item = shopItems[index];

        if (!PlayerGoldManager.Instance.TryUseGold(item.Price))
            return;

        inventory.CollectedItem(item);
    }
}
