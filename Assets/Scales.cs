using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scales : MonoBehaviour
{
    [SerializeField] Bar _Bar;
    Transform WeightStash_Forward;
    Transform WeightStash_Back;

    Vector3 ScalesControlPosition;
    float length;
    float x_center;
    
    float x_board;
    float r_board;

    void Start()
    {
        Links l = Links.GetInstance();
        WeightStash_Back = l.WeightStash_Back;
        WeightStash_Forward = l.WeightStash_Forward;

        ScalesControlPosition = transform.position; // Интересна только координата Х

        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        Vector3 xleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 xright = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        Vector3 xcenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, distance));
        
        x_board = xleft.x;
        r_board = xright.x;

        x_center = xcenter.x;
        length = x_center - x_board;
    }

    void Update()
    {
        float rightmass = 0;
        float leftmass = 0;

        foreach (Transform t in WeightStash_Forward)
        {          
            Rigidbody rb = t.GetComponent<Rigidbody>();
            float mass = rb.mass;

            float hitleft = 0;
            float hitright = 0;

            t.gameObject.layer = 30;
            int layerMask = (1 << 30);

            RaycastHit l_hit;
            Ray l_ray = new Ray(new Vector3(x_board, t.position.y, WeightStash_Forward.position.z), new Vector3(1,0,0));

            RaycastHit r_hit;
            Ray r_ray = new Ray(new Vector3(r_board, t.position.y, WeightStash_Forward.position.z), new Vector3(-1, 0, 0));

            if (Physics.Raycast(l_ray, out l_hit, 500, layerMask))
            {
                hitleft = l_hit.point.x;
            }

            if (Physics.Raycast(r_ray, out r_hit, 500, layerMask))
            {
                hitright = r_hit.point.x;
            }
            
            t.gameObject.layer = 0;

           // test
            float lenghtleft = Mathf.Abs(x_center - hitleft);
            float lenghright = Mathf.Abs(x_center - hitright);

            if (hitleft > x_center)
            {
                rightmass += lenghtleft / length * mass;
            }
            else
            {
                leftmass += lenghtleft / length * mass;
            }

            if (hitright > x_center)
            {
                rightmass += lenghright / length * mass;
            }
            else
            {
                leftmass += lenghright / length * mass;
            }
            //test


            //if (hitleft > x_center && hitright > x_center)
            //{
            //    float t_lenght = Math.Abs(x_center - t.position.x);
            //    float relate = t_lenght / length; //1 - t_lenght / length;

            //    rightmass += mass * relate;
            //}
            //else if (hitleft < x_center && hitright < x_center)
            //{
            //    float t_lenght = Math.Abs(x_center - t.position.x);
            //    float relate = t_lenght / length; //1 - t_lenght / length;

            //    leftmass += mass * relate;
            //}
            //else
            //{
            //    float lenghtleft = Mathf.Abs(x_center - hitleft);
            //    float lenghright = Mathf.Abs(x_center - hitright);

            //    leftmass += lenghtleft / length * mass;
            //    rightmass += lenghright / length * mass;
            //}
        }

        foreach (Transform t in WeightStash_Back)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            float mass = rb.mass;

            float hitleft = 0;
            float hitright = 0;

            t.gameObject.layer = 30;
            int layerMask = (1 << 30);

            RaycastHit l_hit;
            Ray l_ray = new Ray(new Vector3(x_board, t.position.y, WeightStash_Forward.position.z), new Vector3(1, 0, 0));

            RaycastHit r_hit;
            Ray r_ray = new Ray(new Vector3(r_board, t.position.y, WeightStash_Forward.position.z), new Vector3(-1, 0, 0));

            if (Physics.Raycast(l_ray, out l_hit, 500, layerMask))
            {
                hitleft = l_hit.point.x;
            }

            if (Physics.Raycast(r_ray, out r_hit, 500, layerMask))
            {
                hitright = r_hit.point.x;
            }

            t.gameObject.layer = 0;

            // test
            float lenghtleft = Mathf.Abs(x_center - hitleft);
            float lenghright = Mathf.Abs(x_center - hitright);

            if (hitleft > x_center)
            {
                rightmass += lenghtleft / length * mass;
            }
            else
            {
                leftmass += lenghtleft / length * mass;
            }

            if (hitright > x_center)
            {
                rightmass += lenghright / length * mass;
            }
            else
            {
                leftmass += lenghright / length * mass;
            }
            //test
        }

        _Bar.ShowResult(leftmass, rightmass);
    }

}
