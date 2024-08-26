using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    BaseTower BaseTower;

    [SerializeField] GameObject Projectile;
    [SerializeField] Transform FirePoint;
    [SerializeField] Transform weaponModelPivot;
    

    public float fireRate = 1f; /// time between shots
    private float shotCounter;

    private Transform target;

    
    void Start()
    {
        BaseTower = GetComponent<BaseTower>();
        shotCounter = fireRate;
    }

    void Update()
    {
        FireProjectile();
        FindNearestEnemy();
        HandleModelRotation();



    }
    void FireProjectile()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0 && target != null)
        {
            /// reset timer
            shotCounter = fireRate;

            ///rotate firepoint to look at target
            FirePoint.LookAt(target);

            ///spawn projectile
            Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
            Debug.Log("Firing Projectile");
        }
    }
    void FindNearestEnemy()
    {
        if (!BaseTower.EnemiesUpdated)
        {
            return;
        }


        if (BaseTower.enemiesInRange.Count > 0)
        {
            float minDistance = BaseTower.range + 1;
            foreach (Enemy enemy in BaseTower.enemiesInRange)
            {
                if (enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        target = enemy.transform;
                    }
                }
            }
        }
        else
        {
            target = null;
        }

        Debug.Log("Current Target = " + target);
    }
    void HandleModelRotation()
    {
        if (target != null)
        {
            weaponModelPivot.rotation = Quaternion.Slerp(weaponModelPivot.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);
            
            weaponModelPivot.rotation = Quaternion.Euler(0f, weaponModelPivot.rotation.eulerAngles.y, 0f);

        }
    }
    
}
