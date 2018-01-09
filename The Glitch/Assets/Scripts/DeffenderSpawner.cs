using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenderSpawner : MonoBehaviour {
    public Camera cam;
    private GameObject deffenderParent;
    private StarDisplay starDisplay;

    void Start () {
        deffenderParent = GameObject.Find("Deffender");
        starDisplay = FindObjectOfType<StarDisplay>();

        if (!deffenderParent) {
            deffenderParent = new GameObject("Deffender");
        }
    }
    private void OnMouseDown() {
        Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClicked());
        GameObject deffender = Button.selectedDeffender;
        int defenderCost = deffender.GetComponent<Deffender>().starCost;

        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
            SpawnDeffender(pos, deffender);
        }
        else {
            Debug.Log("Not enough stars");
        }
    }

    private void SpawnDeffender(Vector2 pos, GameObject deffender) {
        GameObject deffenderspawner = Instantiate(deffender, pos, Quaternion.identity) as GameObject;
        deffenderspawner.transform.parent = deffenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float a = rawWorldPos.x;
        float b = rawWorldPos.y;
        int x = Mathf.RoundToInt(a);
        int y = Mathf.RoundToInt(b);
        Vector2 roundedPos = new Vector2(x, y);
        return roundedPos;
    }

    Vector2 CalculateWorldPointOfMouseClicked() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;
        Vector3 weiredTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = cam.ScreenToWorldPoint(weiredTriplet);
        return worldPos;
    }
}
