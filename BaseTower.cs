using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public float range = 3f;

    [SerializeField] LayerMask whatIsEnemy;

    private Collider[] collidersInRange;
    public List<Enemy> enemiesInRange = new List<Enemy>();

    private float targetCheckCounter;
    [SerializeField] float targetCheckTime = .2f;

    public bool EnemiesUpdated;

    [SerializeField] GameObject RangeIndicator;

    [SerializeField] public int cost = 100;

    void Start()
    {
        targetCheckCounter = targetCheckTime;
    }

    void Update()
    {
        

        FindEnemiesInRange();
        RangeIndicator.transform.localScale = new Vector3(range, 1, range);

    }
    void FindEnemiesInRange()
    {
        ///countdown 
        targetCheckCounter -= Time.deltaTime;

        EnemiesUpdated = false;

        if (targetCheckCounter <= 0)
        {
            /// reset timer
            targetCheckCounter = targetCheckTime;


            // implement functionality
            
            ///find enemy colliders in range
            collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            ///clear enemy list
            enemiesInRange.Clear();

            ///loop through collider array and add enemy controllers to list
            foreach (Collider col in collidersInRange)
            {
                enemiesInRange.Add(col.GetComponent<Enemy>());
            }
            EnemiesUpdated = true;
        }
        
    }
    

}
