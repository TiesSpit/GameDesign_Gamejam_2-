using TMPro;
using UnityEngine;

public class ShowQuota : MonoBehaviour
{
    void Start()
    {
        var text = GetComponent<TextMeshProUGUI>();
        text.text = "Highest quota reached: " + QuotaManager.Instance.GetFinalQuota();
    }
}
