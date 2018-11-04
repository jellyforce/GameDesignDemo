using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{

    public Text eventText;

    public Text activeQuestText;

    public Transform playerTarget;

    private bool questNotAccepted = true;

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(playerTarget.position, transform.position);
        // print("distance: " + distance);
        // some weird problem with distance.. but this will fix it for now

        var dragon = GameObject.Find("DarkDragon").GetComponent<Dragon>();

        if (dragon.IsAlive())
        {
            if (questNotAccepted && distance < 1090)
            {
                // show text to accept quest
                eventText.text = "press E to accept my dragonslayer quest!";
                if (Input.GetButton("Submit"))
                {
                    eventText.text = "Quest to complete: DragonSlayer";
                    print("e pressed");
                    questNotAccepted = false;
                    activeQuestText.text = "DragonSlayer";
                    activeQuestText.color = Color.white;
                }
            }
            else if (questNotAccepted)
            {
                eventText.text = "Find your quest";
            }
        }
		else if(!dragon.IsAlive()){
			// dragon is dead
			eventText.text = "You Have Completed The Game! Amazing job =D";
		}


    }
}
