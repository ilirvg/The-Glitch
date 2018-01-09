using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject deffenderPrefab;
    public static GameObject selectedDeffender;

    private Text costText;
    private SpriteRenderer spriteRenderer;
    private Button[] buttonArray;

 	void Start() {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;

        costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.Log("No cost text added");
        }
        costText.text = deffenderPrefab.GetComponent<Deffender>().starCost.ToString();
    }
    void Update () {
    }

    private void OnMouseDown() {
        foreach (Button thisButton in buttonArray) {
            thisButton.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDeffender = deffenderPrefab;
    }

}
