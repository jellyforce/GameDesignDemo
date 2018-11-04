using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector3 playerStartposition;

    public Transform Questposition;

    public GameObject dragon;


    private int health;

	public Slider healthslider;


    private AudioSource audioSource;





    // Use this for initialization
    void Start()
    {
        playerStartposition = transform.position;

        health = 100;
		healthslider.value = health;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per framew	void Update () {



    public void TeleportPlayerToQuestLocation()
    {
        transform.position = Questposition.position;
        // transform.LookAt(dragon.transform);
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, dragon.transform.rotation, Time.deltaTime * 5.0f);
    }

    public void DealDamageToPlayer(int damage)
    {
        // take damage
        health -= damage;
        
		// show on UI;
		healthslider.value = health;

        audioSource.Play();


    }

    public void ReturnPlayerToBase(){
        transform.position = playerStartposition;
    }

}
