using UnityEngine;
using System.Collections;
using Unity.UI;
using TMPro;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject[] Enemies;
    public WaveData[] waves;

    public Transform spawnPoint;
    public float timeBetweenWaves = 30.5f;
    public float timeBetweenEnemies = 2.0f;
    private float countdown = 5.5f;
    private int waveNumber;

    public TextMeshProUGUI countdownText;
    private void Start()
    {
        waveNumber = 0;
        
    }

    private void Update()
    {
        if (countdown <= 0.0f)
        {
            Debug.Log("Countdown is 0");
            StartCoroutine(SpawnCurrentWave());
            waveNumber += 1;
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;    
        countdownText.text = Mathf.Round(countdown).ToString();
    }

    //Custoom Method for spawning n numbers of x type of enemies
    IEnumerator SpawnEnemies(int quantity, int enemyIndex) 
    {
        for (int i = 0; i < quantity; i++)
        {
            Instantiate(Enemies[enemyIndex], spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnWave1() 
    {
        StartCoroutine(SpawnEnemies(5, 0));
    }

    void SpawnWave2()
    {
        StartCoroutine(SpawnEnemies(5, 0));
    }

    IEnumerator  SpawnCurrentWave() 
    {
        Debug.Log("Wave: " + waveNumber + " başladı");
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SpawnEnemies(waves[waveNumber].enemy0Number, 0));
        Debug.Log("enemy0lar geliyor");
        yield return new WaitForSeconds((2.0f * waves[waveNumber].enemy0Number) + 2.0f);
        StartCoroutine(SpawnEnemies(waves[waveNumber].enemy1Number, 1));
        Debug.Log("enemy1lar geliyor");
        yield return new WaitForSeconds((2.0f * waves[waveNumber].enemy1Number) + 2.0f);
        StartCoroutine(SpawnEnemies(waves[waveNumber].enemy2Number, 2));
        Debug.Log("enemy2lar geliyor");
        yield return new WaitForSeconds((2.0f * waves[waveNumber].enemy2Number) + 2.0f);
    }

    public void NextWaveButton() 
    {
        countdown = 0.5f;
    }
}
