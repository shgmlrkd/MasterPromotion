using System;
using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{
    public static PlayerGoldManager Instance;

    private int gold = 10000;
    public int Gold => gold;

    public event Action<int> OnUpdateGold;

    private void Awake()
    {
        Instance = this;
    }

    public bool TryUseGold(int price)
    {
        if (gold < price)
        {
            NoticeUI.Instance.OpenNotEnoughGold();

            return false;
        }

        gold -= price;

        OnUpdateGold?.Invoke(gold);

        return true;
    }
}
