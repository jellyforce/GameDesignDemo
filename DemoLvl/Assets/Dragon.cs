using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    private int Health;

    // Use this for initialization
    void Start()
    {
        Health = 200;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamageToDragon(int damage)
    {
        Health -= damage;

        // make sure to check that with the animations => done


    }

	public bool IsAlive(){
		bool alive = true;
		if(Health < 0){
			alive = false;
		}
		return alive;

	}

    public int Dragonhealth(){
        return Health;
    }

}
