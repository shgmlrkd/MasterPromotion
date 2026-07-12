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
        // destroy에서 처리하기 때문에 이미 구독 중일 경우 다시 제거후 구독
        PlayerGoldManager.Instance.OnUpdateGold -= UpdateGoldText;
        PlayerGoldManager.Instance.OnUpdateGold += UpdateGoldText;
    }

    private void OnDestroy()
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
        goldText.text = gold + "G";
    }
}
