using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			// player takes damage
			print("player hit by fireball");
			var player = other.gameObject.GetComponent<Player>();
			player.DealDamageToPlayer(27);
		}
	}
}
