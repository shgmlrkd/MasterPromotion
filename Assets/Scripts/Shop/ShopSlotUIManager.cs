using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;

    [SerializeField]
    private Button[] itemBuyButtons;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        goldText.text = PlayerGoldManager.Instance.Gold.ToString() + "G";
    }

    private void OnEnable()
    {
        PlayerGoldManager.Instance.OnUpdateGold += UpdateGoldText;
    }

    private void OnDisable()
    {
        if(PlayerGoldManager.Instance != null)
        {
            PlayerGoldManager.Instance.OnUpdateGold -= UpdateGoldText;
        }
    }

    private void Initialize()
    {
        for(int i = 0; i < itemBuyButtons.Length; i++)
        {
            int index = i;

            itemBuyButtons[i].onClick.AddListener(() => ShopManager.Instance.BuyItem(index));
        }
    }

    private void UpdateGoldText(int gold)
    {
        goldText.text = gold.ToString() + "G";
    }
}
