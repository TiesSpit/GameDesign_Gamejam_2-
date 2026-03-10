using UnityEngine;

public class ClickManager : MonoBehaviour
{

    [SerializeField]
    private int moneyPerClick;

    [SerializeField]
    private int moneyPerSecond;

    [SerializeField]
    private float mpsTimer;

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

    private void FixedUpdate()
    {
        mpsTimer += Time.fixedDeltaTime;

        while (mpsTimer > 1)
        {
            MoneyManager.Instance.AddMoney(moneyPerSecond);
            mpsTimer--;
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

    public void IncreaseMoneyPerSecond(int pAmount)
    {
        moneyPerSecond += pAmount;
    }

}
