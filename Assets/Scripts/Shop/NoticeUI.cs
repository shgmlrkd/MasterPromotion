using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    public static NoticeUI Instance;

    [SerializeField]
    private GameObject noticeObj;

    [SerializeField]
    private Button okButton;

    private void Awake()
    {
        Instance = this;

        Initialize(); 
        CloseNotice();
    }

    private void Initialize()
    {
        okButton.onClick.AddListener(() => CloseNotice());
    }

    private void CloseNotice()
    {
        noticeObj.SetActive(false);
    }

    public void OpenNotEnoughGold()
    {
        noticeObj.SetActive(true);
    }
}
