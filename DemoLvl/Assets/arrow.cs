using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

	// prob wrong place but.. easiest for now for audio => dragon already has an audiosource
	private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
        StartCoroutine(SelfDestuct());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SelfDestuct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Dragon")
        {
            var dragon = other.gameObject.GetComponent<Dragon>();
            dragon.DealDamageToDragon(10);
            print("dragon hit by an arrow;   dragon health: " + dragon.Dragonhealth());
			
			// impact of an arrow
			audioSource.Play();


            // yay colors
            


        }
    }




}
