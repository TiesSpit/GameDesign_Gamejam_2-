using UnityEngine;

public class InteractButton : MonoBehaviour
{

	enum Function
	{
		Money, Buy, Sell
	}

	[SerializeField] private Function functionality;

	[Header("Choose one")]
	[SerializeField] private Upgrade upgrade;
	[SerializeField] private BuildingPosition sellPosition;


	public void Interact()
	{
		switch (functionality)
		{
			case Function.Money: ClickManager.Instance.Click();
				break;
			case Function.Buy: UpgradeManager.Instance.BuyThing(upgrade); 
				break;
			case Function.Sell: MoneyManager.Instance.AddMoney(sellPosition.DestroyBuilding()); 
				break;
		}
	}

	public Upgrade GetUpgrade()
	{
		return upgrade;
	}

}
