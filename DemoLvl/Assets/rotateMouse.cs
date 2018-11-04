using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMouse : MonoBehaviour
{

    [Range(0.1f, 3f)]
    public float speedHorizontal = 2.0f;
    public float speedVertical = 2.0f;


    private float horizontal = 0.0f;
    private float vertical = 0.0f;



    // Update is called once per frame
    void Update()
    {
        horizontal += speedHorizontal * Input.GetAxis("Mouse X");
        vertical -= speedVertical * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, horizontal, 0.0f);
    }
}