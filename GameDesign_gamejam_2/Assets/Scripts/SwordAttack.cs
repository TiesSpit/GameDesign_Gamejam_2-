using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    [SerializeField] private float attackRange;

    [SerializeField] public int damage;

    public LayerMask enemyLayers;

    public static SwordAttack instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack");

            Collider[] hitEnemies =
            Physics.OverlapSphere(
                attackPoint.position,
                attackRange,
                enemyLayers
            );

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
