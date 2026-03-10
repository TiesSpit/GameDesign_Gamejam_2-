using TMPro;
using UnityEngine;

public class QuotaManager : MonoBehaviour
{
    [Tooltip("How long does each round last?")]
    [SerializeField] private float roundTime;

    [Tooltip("How much money does the player have to collect each round? Index = round")]
    [SerializeField] private int[] quotas;

    [Tooltip("If the player manages to beat the final quota above, enter endless mode. exponentially increase the new quota with this amount")]
    [SerializeField] private float endlessExpIncrease;

    [Header("Debug")]
    [SerializeField] private static int round;

    [SerializeField] private float roundTimer;

    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI quotaText;
    [SerializeField] private TextMeshProUGUI timerText;

    public static QuotaManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        roundTimer = roundTime;
        UpdateUI(true);
    }
    private void FixedUpdate()
    {
        // count down timer
        // if timer hits 0, DoQuota

        roundTimer -= Time.deltaTime;

        if (roundTimer < 0) 
        {
            DoQuota();        
        }

        UpdateUI();
    }

    private void DoQuota()
    {
        if (!MoneyManager.Instance.BuySomething(GetQuota()))
        {
            if (roundTimer < 0)
            {
                //Debug.LogWarning("Game over!!!");
                SceneChanger.instance.GameOver();
            }
        }
        else
        {
            round++;
            roundTimer = roundTime;
            UpdateUI(true);
        }
    }

    private int GetQuota()
    {
        if (round >= quotas.Length)
        {
            return Mathf.RoundToInt(quotas[quotas.Length - 1] * Mathf.Pow(endlessExpIncrease, round - (quotas.Length - 1)));
        }
        return quotas[round];
    }

    private void UpdateUI(bool pUpdateQuota = false)
    {
        if (pUpdateQuota)
        {
            roundText.text = "Round " + round;
            quotaText.text = GetQuota().ToString();
        }
        timerText.text = Mathf.RoundToInt(roundTimer).ToString();
    }

    public void SetRoundToZero()
    {
        round = 0;
    }

    public int GetFinalQuota()
    {
        return quotas[round - 1];
    }
}
