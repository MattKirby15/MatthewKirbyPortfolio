using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] public Slider HealthBar;

    public float TotalHealth;

    [SerializeField] int MoneyOnDeath = 50;

    void Start()
    {
        HealthBar.maxValue = TotalHealth;
        HealthBar.value = TotalHealth;
    }

    void Update()
    {
        ///rotate enemy healthbars to always face camera
        HealthBar.transform.rotation = Camera.main.transform.rotation;
    }
    public void TakeDamage(float _damageAmount)
    {
        /// subtract damage from health
        TotalHealth -= _damageAmount;

        ///if health reaches 0
        if (TotalHealth <= 0)
        {
            ///clamp min health to 0
            TotalHealth = 0;

            ///give money to player
            MoneyManager.instance.GiveMoney(MoneyOnDeath);

            

            /// destroy object
            Destroy(gameObject);
        }
        /// update total health variable
        HealthBar.value = TotalHealth;

        /// set healthbar visibility to active
        HealthBar.gameObject.SetActive(true);
    }
}
