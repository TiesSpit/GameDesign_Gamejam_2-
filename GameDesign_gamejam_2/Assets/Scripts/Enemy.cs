using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    [Header("SmallEnemySettings")]
    [SerializeField] private bool isSmall;
    [SerializeField] private float sineWaveAmplitude;
    [SerializeField] private float sineWaveSpeed;
    float originalX;


    private void Awake()
    {
        target = Base.instance.transform;
        originalX = transform.localPosition.x;
    }

    void Update()
    {

        Vector3 displacement = target.position - transform.position;
        displacement.y = 0;
        Vector3 direction = Vector3.Normalize(displacement);
        Vector3 movement = direction * speed;

        transform.Translate(movement * Time.deltaTime);
        //if (isSmall)
        //    SmallMovement();
    }

    //private void SmallMovement()
    //{
    //    Vector3 position = transform.position;
    //    position.x = originalX * sineWaveAmplitude * Mathf.Sin(Time.time * sineWaveSpeed);
    //    transform.localPosition = position;
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
