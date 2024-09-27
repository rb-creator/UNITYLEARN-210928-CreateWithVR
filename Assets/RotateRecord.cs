using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour
{

    //Assign a GameObject in the Inspector to rotate around
    public GameObject target;
    private float speed = 75f;


    void Update()
    {
        // Spin the object around the target .
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }


   
}
