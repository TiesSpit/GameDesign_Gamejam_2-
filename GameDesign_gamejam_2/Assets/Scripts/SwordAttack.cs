using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private bool canAttack;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private float attackRange;

    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
                Destroy(enemy.gameObject);
            }
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
