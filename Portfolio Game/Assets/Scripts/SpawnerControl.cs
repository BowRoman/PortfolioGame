using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerControl : MonoBehaviour {

    [SerializeField]
    GameObject SpawnObject;
    [SerializeField]
    Transform Target;

    [SerializeField]
    float timeBetweenWaves = 10.0f;
    float timeToNextWave = 3.0f;
    float timeToNextSpawn;
    int waveNumber;
    int enemiesInWave;

    string waveTimeText;

    bool spawning = false;

    [SerializeField]
    Text waveNumberText;
    [SerializeField]
    Text nextWaveText;

	void Start()
    {
        waveNumber = 1;
        enemiesInWave = waveNumber + 4;
	}
	
	void Update()
    {
        if(timeToNextWave > 0)
        {
            waveTimeText = ("Next wave in " + (int)timeToNextWave + "s");
        }
        else
        {
            waveTimeText = ("Wave " + waveNumber + " is coming!");
        }
        nextWaveText.text = waveTimeText;
        nextWaveText.transform.parent.gameObject.GetComponent<Text>().text = waveTimeText;

        timeToNextSpawn -= Time.deltaTime;
        if(timeToNextWave <= 0)
        {
            spawning = true;
            string waveNumText = ("Wave: " + waveNumber.ToString());
            waveNumberText.text = waveNumText;
            waveNumberText.transform.parent.gameObject.GetComponent<Text>().text = waveNumText;
        }
        if(spawning)
        {
            Spawn();
        }
        timeToNextWave -= Time.deltaTime;
    }

    void Spawn()
    {
        if(timeToNextSpawn <= 0)
        {
            GameObject newlySpawned = Instantiate(SpawnObject, transform.position + new Vector3(0.0f, 0.4f, 0.0f), transform.rotation) as GameObject;
            newlySpawned.GetComponent<Enemy>().SetTarget(Target);
            enemiesInWave--;
            timeToNextSpawn = 1.0f;
        }
        if(enemiesInWave <= 0)
        {
            spawning = false;
            timeToNextWave = timeBetweenWaves;
            waveNumber++;
            enemiesInWave = waveNumber + 4;
        }
    }
}
