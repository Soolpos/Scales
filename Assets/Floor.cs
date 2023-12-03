using Assets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Weight a = collision.gameObject.GetComponent<Weight>();
        
        if (a != null)
        {
            a.changeOnthefloor(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Weight a = collision.gameObject.GetComponent<Weight>();

        if (a != null)
        {
            a.changeOnthefloor(false);
        }
    }
}
