using UnityEngine;

public class UpgradeMoneyPerSecond : Upgrade
{
    [SerializeField]
    private int increaseAmount;

    protected override void DoUpgrade()
    {
        base.DoUpgrade();
        ClickManager.Instance.IncreaseMoneyPerSecond(increaseAmount);
    }

    protected override void DoRevert()
    {
        ClickManager.Instance.IncreaseMoneyPerSecond(-increaseAmount);
    }
}
