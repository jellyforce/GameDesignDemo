using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{

    public GameObject arrowPrefab;
    public GameObject arrowEmitter;


    [Range(1f, 1000f)]
    public float arrowSpeed;
    private bool isFireing = false;



    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFireing && Input.GetMouseButtonDown(0))
        {
            print("fire arrow");
            StartCoroutine(FireArrow());
        }
    }

    IEnumerator FireArrow()
    {

        print("fire");
        isFireing = true;

        GameObject arrowHandler;
        arrowHandler = Instantiate(arrowPrefab, transform.position, transform.rotation);

        Rigidbody rbArrow;
        rbArrow = arrowHandler.GetComponent<Rigidbody>();

        rbArrow.AddForce(transform.forward * arrowSpeed);

        // sound of the arrow has to be played
        audioSource.Play();

        yield return new WaitForSeconds(0.5f);

        isFireing = false;
        yield return null;



    }
}
