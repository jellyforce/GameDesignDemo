using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovementAttack : MonoBehaviour
{

    Animator anim;

    public Transform PlayerTarget;

    public GameObject fireballPrefab;

    public Transform fireballEmitter;

    [Range(1, 1000)]
    public float fireballSpeed;

    private bool isFireing = false;


    private AudioSource audioSource;


    public AudioClip[] victoryclips;

    private bool SoundsStarted = false;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, PlayerTarget.position);

        // you need to know if the dragon is still alive..
        var dragon = gameObject.GetComponent<Dragon>();

        if (dragon.IsAlive())
        {
            if (distance < 20)
            {
                print("dragon attack");
                transform.LookAt(PlayerTarget);

                anim.SetBool("attack", true);

            }
            else
            {
                anim.SetBool("attack", false);

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("atk02") && !isFireing)
            {
                print("atk is playing");
                StartCoroutine(FireBall());
            }
        }
        else if (!dragon.IsAlive())
        {
            print("dragon should be dead now");
            // play the dead animation
            anim.SetBool("dead", true);
            anim.SetBool("attack", false);

            // make sure the UI is updated
            // game finished!

            // sounds of victory!
            if (!SoundsStarted)
            {
                StartCoroutine(SoundsOfVictory());

            }

        }


    }

    IEnumerator FireBall()
    {
        isFireing = true;
        yield return new WaitForSeconds(1f);


        GameObject fireballHandler;
        fireballHandler = Instantiate(fireballPrefab, fireballEmitter.position, fireballEmitter.rotation);

        Rigidbody rbFireball;
        rbFireball = fireballHandler.GetComponent<Rigidbody>();

        // send forward
        rbFireball.AddForce(transform.forward * fireballSpeed);

        // play sound of fireball
        audioSource.Play();

        yield return new WaitForSeconds(2.3f);

        isFireing = false;

        yield return null;
    }

    IEnumerator SoundsOfVictory()
    {

        SoundsStarted = true;
        audioSource.clip = victoryclips[0];
        audioSource.Play();

        yield return new WaitForSeconds(2f);

        audioSource.clip = victoryclips[1];
        audioSource.Play();

        yield return new WaitForSeconds(2f);
        // return player to base
        var player = GameObject.Find("Player").GetComponent<Player>();
        player.ReturnPlayerToBase();

        yield return null;

    }
}
