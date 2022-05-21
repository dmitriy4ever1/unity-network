using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMgr : MonoBehaviour
{
    Vector3 origin;

    void Start()
    {
        origin = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            transform.RotateAround(Center.ORIGIN.position,Vector3.up,15);
        }
      
        if (Input.GetKeyDown("d"))
        {
            transform.RotateAround(Center.ORIGIN.position,Vector3.up,-15);
        }
        if (Input.GetKeyDown("w"))
        {
            transform.RotateAround(Center.ORIGIN.position, Vector3.left, -15);
        }
        if (Input.GetKeyDown("s"))
        {
            transform.RotateAround(Center.ORIGIN.position, Vector3.left, 15);
        }   

    }
}
