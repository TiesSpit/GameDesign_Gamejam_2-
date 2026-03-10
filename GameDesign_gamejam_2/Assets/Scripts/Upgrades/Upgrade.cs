using System;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static event Action OnUpgradeBoughtSold;

    [SerializeField] protected int cost;

    [SerializeField] protected int sellValue;

    [SerializeField] protected string type;

    public GameObject SpawnUpgrade(Transform pPosition)
    {
        DoUpgrade();
        return Instantiate(gameObject, pPosition);
    }

    protected virtual void DoUpgrade()
    {
        OnUpgradeBoughtSold?.Invoke();
    }

    protected virtual void DoRevert()
    {

    }
    private void OnDestroy()
    {
        OnUpgradeBoughtSold?.Invoke();
        DoRevert();
    }

    public int GetCost() 
    {  
        if (UpgradeManager.Instance != null)
        {
            return Mathf.RoundToInt(cost * UpgradeManager.Instance.GetCostMultiplier()); 
        }
        return cost;
    }
    public int GetSellValue() { return sellValue; }
    public string GetUpgrType() { return type; }

}
