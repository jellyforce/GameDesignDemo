using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlatform : MonoBehaviour
{

    public Text Objectivetext;


    private void Start()
    {
        Objectivetext.text = "";
    }

    // checks for collison with player
    // if so, ask player to agree to enter the quest zone anmd teleport the player

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print("player on transportPlatform");
            Objectivetext.text = "Press E to enter QuestZone";


            // if player presses E, player must be teleported to the new area
            if (Input.GetButton("Submit"))
            {
                {
                    print("players wants to teleport");
					var player = other.gameObject.GetComponent<Player>();
					player.TeleportPlayerToQuestLocation();
                }

            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // show the objective again instead of portal information
            Objectivetext.text = "";
        }
    }
}

