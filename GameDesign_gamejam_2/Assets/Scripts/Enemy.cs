using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;


    private void Awake()
    {
        target = Base.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = target.position - transform.position;
        displacement.y = 0;
        Vector3 direction = Vector3.Normalize(displacement);
        Vector3 movement = direction * speed;

        transform.Translate(movement * Time.deltaTime);
    }
}
