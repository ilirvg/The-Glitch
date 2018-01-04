using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

    Attacker attacker;
    Animator animator;

    // Use this for initialization
    void Start() {
        //attacker = GameObject.FindObjectOfType<Attacker>();
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        /*if (collision.name == "Gravestone") {
            animator.SetTrigger("jump trigger");
        }
        else if (collision.gameObject.CompareTag("Projectiles") == false){
            animator.SetBool("isAttacking", true);
        }*/
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Deffender>()) {
            return;
        }
        else {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
