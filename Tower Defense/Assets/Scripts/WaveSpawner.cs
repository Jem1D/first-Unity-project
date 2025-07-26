using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    private float waveNumber = 1;
    public Transform SpawnPoint;
    public Text WaveCountdown;

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;

        WaveCountdown.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }
    
}
