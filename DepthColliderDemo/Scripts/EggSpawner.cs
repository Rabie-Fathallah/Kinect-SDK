using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour 
{
    public Transform eggPrefab;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;
 	
	void Update () 
	{
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
            nextEggTime = Time.time + spawnRate;

            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

    void SpawnEgg()
    {
		KinectManager manager = KinectManager.Instance;

		if(eggPrefab && manager && manager.IsInitialized() && manager.IsUserDetected())
		{
			uint userId = manager.GetPlayer1ID();
			Vector3 posUser = manager.GetUserPosition(userId);

			float addXPos = Random.Range(-10f, 10f);
			Vector3 spawnPos = new Vector3(addXPos, 10f, posUser.z);
			
			Transform eggTransform = Instantiate(eggPrefab, spawnPos, Quaternion.identity) as Transform;
			eggTransform.parent = transform;
		}
    }

}
