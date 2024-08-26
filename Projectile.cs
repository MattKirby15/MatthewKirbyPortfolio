using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;

    [SerializeField] float moveSpeed;

    [SerializeField] public float damage;

    bool HasDoneDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        ///if other is tagged as enemy & this projectile has not done damage yet
        if (other.tag == "Enemy" && !HasDoneDamage)
        {
            /// access the enemy's health controller applies damage amount
            other.GetComponent<EnemyHealthController>().TakeDamage(damage);

            ///this projectile has done damage
            HasDoneDamage = true;
        }

        Destroy(gameObject);
    }

}
