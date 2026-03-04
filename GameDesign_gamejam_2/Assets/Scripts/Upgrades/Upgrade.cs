using UnityEngine;

public class Upgrade : MonoBehaviour
{

    [SerializeField] protected int cost;

    [SerializeField] protected int sellValue;


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


}
