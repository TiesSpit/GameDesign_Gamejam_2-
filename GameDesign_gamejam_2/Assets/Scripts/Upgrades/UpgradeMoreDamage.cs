using UnityEngine;

public class UpgradeMoreDamage : Upgrade
{
    [SerializeField] private int damageIncreaseAmount;

    protected override void DoUpgrade()
    {
        base.DoUpgrade();
        SwordAttack.instance.damage += damageIncreaseAmount;
    }

    protected override void DoRevert()
    {
        base.DoRevert();
        SwordAttack.instance.damage -= damageIncreaseAmount;
    }
}
