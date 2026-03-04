using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private BuildingPosition[] buildingPositions;




    public static UpgradeManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void BuyThing(Upgrade pUpgrade)
    {
        BuyUpgrade(pUpgrade);
    }

    public bool BuyUpgrade(Upgrade pUpgrade)
    {
        if (MoneyManager.Instance.BuySomething(pUpgrade.GetCost()))
        {
            // Hurray, upgrade is bought!
            
            if (!PlaceUpgrade(pUpgrade))
            {
                // Oopsie daisy, no places left to place the building! I'll refund cause I'm generous
                MoneyManager.Instance.AddMoney(pUpgrade.GetCost());
                return false;
            }
            
            return true;
        }
        return false;
    }

    public bool BuyUpgrade(GameObject pUpgrade)
    {
        if (pUpgrade.TryGetComponent<Upgrade>(out Upgrade upgr))
        {
            return BuyUpgrade(upgr);
        }
        Debug.LogError("Tried to buy an upgrade, but the GameObject doesn't have an Upgrade component attached");
        return false;
    }

    private bool PlaceUpgrade(Upgrade pUpgrade)
    {
        for (int i = 0; i < buildingPositions.Length; i++)
        {
            if (buildingPositions[i].SpawnBuilding(pUpgrade))
            {
                return true;
            }
        }



        return false;
    }


}
