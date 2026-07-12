using UnityEngine;

public enum ItemType
{
    HpPotion,
    StaminaPotion
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Potion Data")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private ItemType type;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string discription;

    [SerializeField]
    private float healAmount;

    [SerializeField]
    private int itemKey;

    [SerializeField]
    private int price;

    public Sprite Sprite => sprite; 
    public ItemType Type => type;
    public string ItemName => itemName;
    public string Discription => discription;
    public float HealAmount => healAmount;
    public int ItemKey => itemKey;
    public int Price => price;
}
