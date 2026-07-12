using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlotUI : MonoBehaviour
{
    [SerializeField]
    private ItemData data;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TextMeshProUGUI discription;

    [SerializeField]
    private TextMeshProUGUI price;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        itemImage.sprite = data.Sprite;
        discription.text = data.Discription;
        price.text = data.Price.ToString() + "G";
    }
}