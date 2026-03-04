using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    [SerializeField]
    private int money;

    [SerializeField]
    private TextMeshProUGUI moneyText;

    public static MoneyManager Instance;

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


    public void AddMoney(int pAmount)
    {
        money += pAmount;
        UpdateUI();
    }

    public bool BuySomething(int pCost)
    {
        if (pCost > money) return false;
        money -= pCost;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        moneyText.text = "Money: " + money;
    }

}
