using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
	public float damage = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		// like in java  use other class and use method in that class
		other.gameObject.GetComponent<HpMonster>().TakeDamage(damage);

		
	}


}
