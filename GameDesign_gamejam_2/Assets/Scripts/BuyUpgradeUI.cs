using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractButton))]
public class BuyUpgradeUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;

    [Header("Set automatically")]
    [SerializeField] Upgrade upgrade;

    private void Start()
    {
        if (upgrade == null) upgrade = GetComponent<InteractButton>().GetUpgrade();
        UpdateUI();
        Upgrade.OnUpgradeBoughtSold += UpdateUI;        
    }

    private void OnDestroy()
    {
        Upgrade.OnUpgradeBoughtSold -= UpdateUI;
    }


    private void UpdateUI()
    {
        text.text = "BUY\n" + upgrade.GetUpgrType() + "\nCost:\n" + upgrade.GetCost();
    }


}
