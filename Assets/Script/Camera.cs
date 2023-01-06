using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   public float distance;
   public GameObject MyCube;
    void Start()
    {
        MyCube.GetComponent<Transform>();
        //MyCube = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (MyCube.transform.position.z - transform.position.z > distance)
        {
            Vector3 position = transform.position;
            position.z = MyCube.transform.position.z - distance;
            transform.position = position;
        }
    }
}
