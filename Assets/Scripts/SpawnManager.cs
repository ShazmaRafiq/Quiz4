using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab,spawnpos,bulletenemy;
    private float spawnRange = 9.0f;
    public static int waveNumber = 5;
    public int enemyCount;
    public Button pause,resume;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
       if (enemyCount == 0)
        {
           waveNumber++;
           SpawnEnemyWave(waveNumber);
           
        }

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab,spawnpos.transform.position , enemyPrefab.transform.rotation);
            GameObject prefab = Instantiate(bulletenemy, new Vector3(spawnpos.transform.position.x, spawnpos.transform.position.y, spawnpos.transform.position.z - 2), bulletenemy.transform.rotation);
            Rigidbody rbprefab = prefab.GetComponent<Rigidbody>();
            rbprefab.AddForce(Vector3.down * 1, ForceMode.Impulse);
            spawnpos.transform.position = new Vector3(spawnpos.transform.position.x+2, spawnpos.transform.position.y, spawnpos.transform.position.z);
        }
        enemiesToSpawn += 1;
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(true);
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }
}
