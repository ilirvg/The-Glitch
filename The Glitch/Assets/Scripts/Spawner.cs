using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	void Update () {
        foreach (GameObject thisAttacker in attackerPrefabArray) {
            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
                
            }
        }
	}

    bool isTimeToSpawn(GameObject attackerGameObject) {
        Attacker atck = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = atck.seenEverySeconds - SceneManager.GetActiveScene().buildIndex;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("you can not spawn in this framerate");
        }
        float threshhold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshhold);
    }

    public void Spawn(GameObject myGameObject) {
        GameObject myAttacker = Instantiate(myGameObject, transform.position, Quaternion.identity) as GameObject;
        myAttacker.transform.parent = transform;
    }
}
