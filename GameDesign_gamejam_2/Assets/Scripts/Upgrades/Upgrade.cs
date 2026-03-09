using UnityEngine;

public class Upgrade : MonoBehaviour
{

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

    }


    public int GetCost() {  return cost; }
    public int GetSellValue() { return sellValue; }
    public string GetUpgrType() { return type; }

}
