using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Weight ControllW;

    void Start()
    {
        
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Weight a = hit.transform.gameObject.GetComponent<Weight>();
                
        //        ControllW = a;
        //        ControllW.ChangeActive(true);

        //        //Transform objectHit = hit.transform;

        //        //Debug.Log("Pressed primary button." + objectHit);
        //    }
        //}   

        //if (Input.GetMouseButtonUp(0))
        //{
        //    ControllW.ChangeActive(false);
        //}
            //Debug.Log("unPressed primary button.");
    }
}
