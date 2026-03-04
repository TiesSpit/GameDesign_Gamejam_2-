using UnityEngine;

public class ClickManager : MonoBehaviour
{

    [SerializeField]
    private int moneyPerClick;



    public static ClickManager Instance;
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

    public void Click()
    {
        MoneyManager.Instance.AddMoney(moneyPerClick);
    }

    public void IncreaseClickMoney(int pAmount)
    {
        moneyPerClick += pAmount;
    }

}
