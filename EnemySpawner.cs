using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;

    float waveTimer = 6f;
    float countdown = 2f;

    private int waveIndex = 0;


    private void Awake()
    {
        /// initilize static reference
        Instance = this; 
    }

    void Start()
    {

    }

    void Update()
    {
        HandleWaveCountdown();
    }
    IEnumerator SpawnWave()
    {
        Debug.Log("Incoming Wave");
        waveIndex++;
        

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void HandleWaveCountdown()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //SpawnEnemy();
            countdown = waveTimer;
        }

        countdown -= Time.deltaTime;
    }

}
