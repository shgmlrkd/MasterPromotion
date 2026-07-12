using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SlotUI
{
    public GameObject slotObj;
    public Image Image;
    public Button Button;
    public Image OutLine;
    public TextMeshProUGUI Count;
}

public class InventorySoltUIManager : MonoBehaviour
{
    [Header("인벤토리 슬롯")]
    [SerializeField]
    private SlotUI[] slotUIs;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private TextMeshProUGUI goldText;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        inventory.OnUpdateInventory += UpdateInventoryUI;

        // destroy에서 처리하기 때문에 이미 구독 중일 경우 다시 제거후 구독
        PlayerGoldManager.Instance.OnUpdateGold -= UpdateGoldText;
        PlayerGoldManager.Instance.OnUpdateGold += UpdateGoldText;
    }

    private void OnDestroy()
    {
        if (inventory != null)
        {
            inventory.OnUpdateInventory -= UpdateInventoryUI;
        }

        if (PlayerGoldManager.Instance != null)
        {
            PlayerGoldManager.Instance.OnUpdateGold -= UpdateGoldText;
        }
    }

    private void Start()
    {
        goldText.text = PlayerGoldManager.Instance.Gold.ToString() + "G";
    }

    private void UpdateGoldText(int gold)
    {
        goldText.text = gold.ToString() + "G";
    }

    private void Initialize()
    {
        for (int i = 0; i < slotUIs.Length; i++)
        {
            int index = i;

            slotUIs[i].Button.onClick.AddListener(() => OnClickSlot(index));

            // 우클릭 감지 컴포넌트를 버튼 오브젝트에 부착
            SlotClickHandler clickHandler = slotUIs[i].Button.gameObject.AddComponent<SlotClickHandler>();
            clickHandler.Setup(index, OnRightClickSlot);

            slotUIs[i].Button.interactable = false;
            slotUIs[i].slotObj.gameObject.SetActive(false);
        }
    }

    private void OnRightClickSlot(int index)
    {
        if (!slotUIs[index].OutLine.gameObject.activeSelf) return;

        // 인벤토리에서 내부적으로 정리
        inventory.UseItem(index);
    }

    private void OnClickSlot(int index)
    {
        for (int i = 0; i < slotUIs.Length; i++)
        {
            if (i == index) continue;

            slotUIs[i].OutLine.gameObject.SetActive(false);
        }

        slotUIs[index].OutLine.gameObject.SetActive(true);
    }

    private void UpdateInventoryUI(int index, int count, Sprite sprite)
    {
        if (slotUIs.Length - 1 < index) return;

        if (count <= 0)
        {
            slotUIs[index].OutLine.gameObject.SetActive(false);
            slotUIs[index].Button.interactable = false;
            slotUIs[index].Image.sprite = null;
            slotUIs[index].Count.text = "";
            slotUIs[index].slotObj.gameObject.SetActive(false);

            return;
        }
        else if(count > 0 && !slotUIs[index].slotObj.activeSelf)
        {
            slotUIs[index].Image.sprite = sprite;
            slotUIs[index].Button.interactable = true;
            slotUIs[index].slotObj.gameObject.SetActive(true);
        }

        int selectedIndex = -1;
        bool hasOutLine = false;

        for(int i = 0; i < slotUIs.Length;i++)
        {
            if(slotUIs[i].OutLine.gameObject.activeSelf)
            {
                hasOutLine = true;
                selectedIndex = i;
                break;
            }
        }

        if (!hasOutLine)
        {
            slotUIs[0].OutLine.gameObject.SetActive(true);
        }
        else
        {
            if(index != selectedIndex)
            {
                slotUIs[index].OutLine.gameObject.SetActive(false);
            }
        }

        slotUIs[index].Count.text = count.ToString();
    }
}