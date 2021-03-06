﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Avarage time that the attacer is seen")]
    public float seenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (currentTarget == null) {
            animator.SetBool("isAttacking", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log(name + " trigger enter");
    }
    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }
    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) { 
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }
    public void Attack(GameObject obj) {
        currentTarget = obj;
    }
}
