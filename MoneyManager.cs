using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField] int currentMoney;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        /// update ui text value
        UiController.instance.GoldText.text = currentMoney.ToString();
    }
    void Update()
    {
        
    }
    public void GiveMoney(int _amountToGive)
    {
        ///add amount to give to current value
        currentMoney += _amountToGive;

        /// update ui text value
        UiController.instance.GoldText.text = currentMoney.ToString();
    }
    public bool SpendMoney(int _amountToSpend)
    {
        bool _canSpend = false;

        ///if player has enough money to complete purchase
        if (_amountToSpend <= currentMoney)
        {
            _canSpend = true;

            Debug.Log("Spent " +  _amountToSpend);

            ///subtract amount from of current
            currentMoney -= _amountToSpend;
        }
        /// update ui text value
        UiController.instance.GoldText.text = currentMoney.ToString();

        return _canSpend;
    }
}
