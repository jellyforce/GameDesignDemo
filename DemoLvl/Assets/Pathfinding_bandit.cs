using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding_bandit : MonoBehaviour
{

    public Transform[] pathnotes;

    bool walkCicleStarted = false;

    NavMeshAgent agent;

    Vector3 currentPositionAgent;



    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!walkCicleStarted)
        {
            StartCoroutine(StartWalkCicle());
        }




    }
    private void FixedUpdate()
    {

    }



    private IEnumerator StartWalkCicle()
    {
        walkCicleStarted = true;

        print("Pathfinding_bandit started");

        // 5 notes total
        for (int i = 1; i < pathnotes.Length; i++)
        {
            if (i > pathnotes.Length)
            {
                // last note = base note at [0]
                transform.LookAt(pathnotes[0].position);
                agent.SetDestination(pathnotes[0].position);
                yield return new WaitUntil(() => Vector3.Distance(transform.position, pathnotes[0].position) <= 0.1f);
                //done
            }
            else
            {
                // rotation and destination
                transform.LookAt(pathnotes[i].position);
                agent.SetDestination(pathnotes[i].position);

                // print("distance: " + Vector3.Distance(transform.position, pathnotes[i].position));
                yield return new WaitUntil(() => Vector3.Distance(transform.position, pathnotes[i].position) <= 0.1f);
                print("in distance for next note");
            }

        }

        walkCicleStarted = false;
        yield return null;
    }



    // IEnumerator StartWalkCicle(){


    // 	walkCicleStarted = true;
    // 	yield return new WaitForSeconds(2f);
    // 	yield return null;
    // }
}
