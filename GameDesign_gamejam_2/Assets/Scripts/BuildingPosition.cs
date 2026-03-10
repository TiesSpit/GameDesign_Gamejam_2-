using UnityEngine;

public class BuildingPosition : MonoBehaviour
{

    [SerializeField]
    private Upgrade heldUpgrade;

    [SerializeField]
    private Transform spawnPos;

    public bool SpawnBuilding(Upgrade pUpgrade)
    {
        if (heldUpgrade != null) 
        {
            // THIS MEANS THIS PLACE SHOULDN'T GET THE THING
            return false;
        }
        else
        {
            UpgradeManager.Instance?.ChangeBuildingAmount(1);
            heldUpgrade = pUpgrade.SpawnUpgrade(spawnPos).GetComponent<Upgrade>();
            return true;
        }
    }

    public int DestroyBuilding()
    {
        if (heldUpgrade != null)
        {
            int sellValue = heldUpgrade.GetSellValue();
            Destroy(heldUpgrade.gameObject);
            UpgradeManager.Instance?.ChangeBuildingAmount(-1);
            return sellValue;
        }

        // NO BUILDING TO SELL, NO MONEY FOR YOU
        return 0;
    }



}
