using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float startGameTime = 10f;

    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audiSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

    void Start () {
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        slider = GetComponent<Slider>();
        audiSource = GetComponent<AudioSource>();
        slider.maxValue = startGameTime;
        FindLabel();
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        startGameTime = startGameTime - 1 * Time.deltaTime;
        slider.value = startGameTime;
        if (startGameTime <= 0 && !isEndOfLevel ) {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition() {
        DestroyAllTaggedObjects();
        audiSource.Play();
        winLabel.SetActive(true);
        print("Level won");
        isEndOfLevel = true;
        Invoke("NextLevel", audiSource.clip.length);
    }
    void DestroyAllTaggedObjects() {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObj in taggedObjectArray) {
            Destroy(taggedObj);
        }
    }

    void NextLevel() {
        levelManager.LoadNextLevel();
    }

    private void FindLabel() {
        winLabel = GameObject.Find("You Win");
        if (!winLabel) {
            Debug.LogWarning("No Win Label");
        }
    }
}
