using UnityEngine;

public class GoldZone : MonoBehaviour
{
    private float goldInterval = 1.5f;
    private float timer = 0.0f;

    [SerializeField]
    private int goldAmount = 200;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer > goldInterval)
            {
                timer = 0.0f;
                PlayerGoldManager.Instance.AddGold(goldAmount);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0.0f;
        }
    }
}
