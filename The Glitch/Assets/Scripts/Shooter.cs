using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;
    //int a;
    private void Start() {
        myLaneSpawner = FindObjectOfType<Spawner>();
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
    }

    private void Update() {
        //a = myLaneSpawner.transform.childCount;
        if (IsAttackerAheadInTheLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }    
    }

    void SetMyLaneSpawner() {
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
        foreach (Spawner thisSpawner in spawnerArray) {
            if (thisSpawner.transform.position.y == transform.position.y) {
                myLaneSpawner = thisSpawner;
                return;
            }
        }
        Debug.LogError("There is no spawner");
    }

    bool IsAttackerAheadInTheLane() {
        /*if (myLaneSpawner.transform.childCount > 0 && myLaneSpawner.transform.GetChild(a-1).transform.position.x > transform.position.x) {
            Debug.Log("There is an attacker");
            return true;
        }
        else {
            return false;
        }*/
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        foreach (Transform deffender in myLaneSpawner.transform) {
            if (deffender.transform.position.x > transform.position.x) {
                return true;
            }
        }
        return false;

    }
    public void Fire() {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }


}
