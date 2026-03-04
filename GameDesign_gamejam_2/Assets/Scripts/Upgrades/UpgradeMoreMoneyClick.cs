using UnityEngine;

public class UpgradeMoreMoneyClick : Upgrade
{
    [SerializeField]
    private int increaseAmount;

    protected override void DoUpgrade()
    {
        base.DoUpgrade(); 
        ClickManager.Instance.IncreaseClickMoney(increaseAmount);
    }
}
