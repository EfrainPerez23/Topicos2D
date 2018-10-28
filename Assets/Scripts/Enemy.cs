using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health <= 0) {
			Destroy(this.gameObject);
		}	
		
	}

	public void TakeDamage(int damage) {
		this.health -= damage;
	}
}
