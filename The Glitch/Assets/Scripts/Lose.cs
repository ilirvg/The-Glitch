using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

    //private Attacker attacker;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        //attacker = FindObjectOfType<Attacker>();
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Attacker>() != null) {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
