using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] public GameObject[] Towers;
    [SerializeField] public Transform[] TowerSpawns;

    [SerializeField] public GameObject towerMenu;
    int towerIndex = 0;
    int towerSpawnIndex = 0;

    int towerCost;

    bool canBuild;


    void Start()
    {
        towerMenu.SetActive(false);
        Debug.Log("TowerSpawnIndex = " + towerSpawnIndex);
    }

    void Update()
    {
        towerCost = Towers[towerIndex].gameObject.GetComponent<BaseTower>().cost;
    }
    public void InstantiateTower(GameObject _TowerToSpawn, Transform _SpawnLocationIndex)
    {
        Instantiate(_TowerToSpawn, _SpawnLocationIndex.position, _SpawnLocationIndex.rotation);
        // towerIndex++;

        Debug.Log("TowerSpawnIndex = " + towerSpawnIndex);
    }

    public void OpenTowerMenu()
    {
        towerMenu.SetActive(true);
    }

    public void CloseTowerMenu()
    {
        towerMenu.SetActive(false);
    }

    public void BuildTower()
    {
        if (towerSpawnIndex <= TowerSpawns.Length)
        {
           
            if (MoneyManager.instance.SpendMoney(towerCost))
            {
                InstantiateTower(Towers[towerIndex], TowerSpawns[towerSpawnIndex]);
                towerSpawnIndex++;

            }
        }
        else if (towerSpawnIndex > TowerSpawns.Length)
        {

        }
        
    }
}
