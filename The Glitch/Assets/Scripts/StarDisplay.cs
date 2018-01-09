using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {
    Text text;
    int stars = 100;
    public enum Status { SUCCESS, FAILURE};

    void Start () {
        text = GetComponent<Text>();
        UpdateDisplay();
	}

    public void AddStrs(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        else {
            return Status.FAILURE;
        }
    }

    void UpdateDisplay() {
        text.text = stars.ToString();
    }
}
