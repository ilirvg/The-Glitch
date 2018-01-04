using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    public float speed, damage;
    

    void Start () {
		
	}
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
        if (attacker && health) {
            health.DealDamage(damage);
            DestroyObject(gameObject);
        }

    }
}
