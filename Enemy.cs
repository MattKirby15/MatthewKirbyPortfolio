using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private Transform target;
    [SerializeField] float speed = 10f;
    private int waypointIndex = 0;
    [SerializeField] private float attackDamage = 1f;
    private Castle castle;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        target = gameManager.EnemyWaypoints[waypointIndex];

        ///if no castle is assigned, find one
        if (castle == null)
        {
            castle = FindObjectOfType<Castle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }
    void MoveToTarget()
    {
        /// find targets position and move towards it
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        /// if the enemy reaches the target
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            /// find next waypoint
            GetNextWaypoint();
            ///rotate enemy to face target
            transform.LookAt(target);
        }
        
    }
    void GetNextWaypoint()
    {
        /// if the enemy reaches the last waypoint 
        if (waypointIndex >= gameManager.EnemyWaypoints.Length - 1)
        {
            /// damage the castle
            castle.TakeDamage(attackDamage);

            Destroy(gameObject);
            return;
        }

        ///update index to next waypoint
        waypointIndex++;
        /// set target to new waypoint   
        target = gameManager.EnemyWaypoints[waypointIndex];
        
    }
    
}
