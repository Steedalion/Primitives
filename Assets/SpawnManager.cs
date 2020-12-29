using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject obstaclePrefab;
	public GameObject powerupPrefab;
	public float xmin, xmax;
	float delay = 2f;
	WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
	    wait = new WaitForSeconds(delay);
	    StartCoroutine(SpawnObstacles(5));
	    StartCoroutine(SpawnPowerup(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    
	IEnumerator SpawnObstacles( int number)
	{
		for (int i = 0; i < number; i++) {
			Instantiate(obstaclePrefab, RandomSpawnPosition(), Quaternion.identity);
			yield return wait;
		}
		
	}
	
	IEnumerator SpawnPowerup(int number)
	{
		float totalWaveTime = delay*number;
		yield return new WaitForSeconds(Random.Range(0,totalWaveTime));
		Instantiate(powerupPrefab, RandomSpawnPosition(), Quaternion.identity);
		
	}
	
	Vector3 RandomSpawnPosition()
	{
		return new Vector3(Random.Range(xmin,xmax), 0, transform.position.z);
	}
    
    
}
