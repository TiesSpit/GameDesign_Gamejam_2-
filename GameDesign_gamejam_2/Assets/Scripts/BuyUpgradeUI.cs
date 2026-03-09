using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractButton))]
public class BuyUpgradeUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;

    [Header("Set automatically")]
    [SerializeField] Upgrade upgrade;

    private void OnEnable()
    {
        if (upgrade == null) upgrade = GetComponent<InteractButton>().GetUpgrade();
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = "BUY\n" + upgrade.GetUpgrType() + "\nCost:\n" + upgrade.GetCost();
    }


}
