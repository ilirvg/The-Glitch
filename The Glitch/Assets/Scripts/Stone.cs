using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
    
    }
    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("AAAAAA");
        if (collision.GetComponent<Attacker>()) {
            animator.SetTrigger("underAttack trigger");
        }
    }
}
