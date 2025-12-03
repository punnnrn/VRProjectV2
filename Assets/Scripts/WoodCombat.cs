using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WoodCombat : MonoBehaviour
{
    public float damageAmout = 10;

    [SerializeField]
    private Rigidbody rb;

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out EnemyHealth currentHealth))
        {
            currentHealth.TakeDamage(damageAmout);
        }
    }
}
