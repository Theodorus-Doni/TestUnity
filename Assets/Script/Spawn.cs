using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private Transform[] transSpawn = null;

    [SerializeField]
    private GameObject gameobjKnifePerfab = null;

    Vector2 vec2SpawnPos;

    float TimeSpawn;

    int intRandomLocation;

    private void Awake()
    {
        TimeSpawn = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        TimeSpawn -= 1 * Time.deltaTime;
        if (TimeSpawn <= 0) {
            TimeSpawn = 1;
            RandomPosSpawn();
        }
	}

    private void SpawnKnife(Vector3 pos) {
        Instantiate(gameobjKnifePerfab,pos,Quaternion.identity);
    }

    private void RandomPosSpawn() {
        intRandomLocation = Random.Range(1, 4);
        switch (intRandomLocation) {
            case 1:
                SpawnKnife(transSpawn[1].position);
                break;
            case 2:
                SpawnKnife(transSpawn[2].position);
                break;
            case 3:
                SpawnKnife(transSpawn[3].position);
                break;
            case 4:
                SpawnKnife(transSpawn[4].position);
                break;
        }
    }

}
