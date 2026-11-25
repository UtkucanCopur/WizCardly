using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] aliens;
    [SerializeField] private GameObject[] mages;
    [SerializeField] private GameObject[] orcs;
    [SerializeField] private GameObject[] minatours;
    [SerializeField] private int activeEnemyCount;


    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private int level;
    [SerializeField] private bool isLevelContinue;
    [SerializeField] private int rand;

    private void OnEnable()
    {
        GameEvents.OnLevelUp += GetCurrentLevel;
        GameEvents.OnEnemyDied += CheckEnemyDeaths;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelUp -= GetCurrentLevel;
        GameEvents.OnEnemyDied -= CheckEnemyDeaths;
    }

    private void Awake()
    {
        isLevelContinue = true;
    }




    private void Update()
    {
        SpawnContinue();
        if (level <= 10 && isLevelContinue)
        {
            SpawnEnemy();
        }
        if (level > 10 && isLevelContinue)
        {
            InfinityPlay();
        }
        
    }

    private void InfinityPlay()
    {

    }

    private void SpawnEnemy()
    {
        switch (level)
        {
            case 1:
                
                Spawn5Alien();
                isLevelContinue = false;
                break;
            case 2:
                
                Spawn5Alien();
                for (int i = 0; i < 2; i++)
                {
                    rand = Random.Range(0, spawnPositions.Length);
                    orcs[i].SetActive(true);
                    orcs[i].transform.position = spawnPositions[rand].position;
                    orcs[i].GetComponent<EnemyStats>().SpawnStats();
                    activeEnemyCount++;
                }
                isLevelContinue = false;

                break;
            case 3:
                Spawn10Alien();
                isLevelContinue = false;
                break;
            case 4:
                Spawn5Alien();
                for (int i = 0; i < 4; i++)
                {
                    rand = Random.Range(0, spawnPositions.Length);
                    orcs[i].SetActive(true);
                    orcs[i].transform.position = spawnPositions[rand].position;
                    orcs[i].GetComponent<EnemyStats>().SpawnStats();
                    activeEnemyCount++;
                }
                for (int i = 0; i < 2; i++)
                {
                    rand = Random.Range(0, spawnPositions.Length);
                    minatours[i].SetActive(true);
                    minatours[i].transform.position = spawnPositions[rand].position;
                    minatours[i].GetComponent<EnemyStats>().SpawnStats();
                    activeEnemyCount++;
                }
                isLevelContinue = false;
                break;
            case 5:
                Spawn5Orcs();
                Spawn10Alien();
                for (int i = 0; i < 3; i++)
                {
                    rand = Random.Range(0, spawnPositions.Length);
                    minatours[i].SetActive(true);
                    minatours[i].transform.position = spawnPositions[rand].position;
                    minatours[i].GetComponent<EnemyStats>().SpawnStats();
                    activeEnemyCount++;
                }
                isLevelContinue = false;
                break;
            case 6:
                Spawn5Minatour();
                isLevelContinue = false;
                break;
            case 7:
                Spawn5Alien();
                Spawn5Orcs();
                Spawn5Minatour();
                for (int i = 0; i < 3; i++)
                {
                    rand = Random.Range(0, spawnPositions.Length);
                    mages[i].SetActive(true);
                    mages[i].transform.position = spawnPositions[rand].position;
                    mages[i].GetComponent<EnemyStats>().SpawnStats();
                    activeEnemyCount++;
                }
                isLevelContinue = false;
                break;
            case 8:
                Spawn5Alien();
                Spawn5Orcs();
                Spawn5Minatour();
                Spawn5Mage();
                isLevelContinue = false;
                break;
            default:
                break;


        }

    }

    private void Spawn5Mage()
    {
        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, spawnPositions.Length);
            mages[i].SetActive(true);
            mages[i].transform.position = spawnPositions[rand].position;
            mages[i].GetComponent<EnemyStats>().SpawnStats();
            activeEnemyCount++;
        }
    }
    private void Spawn5Minatour()
    {
        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, spawnPositions.Length);
            minatours[i].SetActive(true);
            minatours[i].transform.position = spawnPositions[rand].position;
            minatours[i].GetComponent<EnemyStats>().SpawnStats();
            activeEnemyCount++;
        }
    }
    private void Spawn5Orcs()
    {
        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, spawnPositions.Length);
            orcs[i].SetActive(true);
            orcs[i].transform.position = spawnPositions[rand].position;
            orcs[i].GetComponent<EnemyStats>().SpawnStats();
            activeEnemyCount++;
        }
    }
    private void Spawn5Alien()
    {
        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, spawnPositions.Length);
            aliens[i].SetActive(true);
            aliens[i].transform.position = spawnPositions[rand].position;
            aliens[i].GetComponent<EnemyStats>().SpawnStats();
            activeEnemyCount++;
        }
    }
    private void Spawn10Alien()
    {
        for (int i = 0; i < 10; i++)
        {
            rand = Random.Range(0, spawnPositions.Length);
            aliens[i].SetActive(true);
            aliens[i].transform.position = spawnPositions[rand].position;
            aliens[i].GetComponent<EnemyStats>().SpawnStats();
            activeEnemyCount++;
        }
    }


    private void SpawnContinue()
    {
        if (activeEnemyCount <= 0)
            isLevelContinue = true;
    }

    private void CheckEnemyDeaths() => activeEnemyCount--;

    private void GetCurrentLevel() => level++;

}
