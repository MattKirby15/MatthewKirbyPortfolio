using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    [SerializeField] public Transform[] EnemyWaypoints;

    

    private void Awake()
    {
        Instance = this;
        SetupGame();
        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void SetupGame()
    {
        
    }
    
    
}
