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

    // Start is called before the first frame update
    void Start()
    {
        Links l = Links.GetInstance();
        WeightStash_Back = l.WeightStash_Back;
        WeightStash_Forward = l.WeightStash_Forward;

        ScalesControlPosition = transform.position; // Интересна только координата Х

        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        Vector3 xleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 xcenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, distance));
        
        float x_board = xleft.x;
        
        x_center = xcenter.x;
        length = x_center - x_board;
    }

    // Update is called once per frame
    void Update()
    {
        float rightmass = 0;
        float leftmass = 0;

        foreach (Transform t in WeightStash_Forward)
        {          
            Rigidbody rb = t.GetComponent<Rigidbody>();
            float mass = rb.mass;

            float t_xpos = t.position.x;
            float t_lenght = Math.Abs(x_center - t_xpos);
            float relate = 1 - t_lenght / length;

            mass *= relate;

            //float dist = Mathf.Abs(ScalesControlPosition.x - t.position.x);

            if (ScalesControlPosition.x > t.position.x)
            {
                leftmass += mass;
            }
            else if(ScalesControlPosition.x < t.position.x)
            {
                rightmass += mass;
            }
            else
            {

            }
        }

        foreach (Transform t in WeightStash_Back)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            float mass = rb.mass;

            float t_xpos = t.position.x;
            float t_lenght = Math.Abs(x_center - t_xpos);
            float relate = 1 - t_lenght / length;

            mass *= relate;

            if (ScalesControlPosition.x > t.position.x)
            {
                leftmass += mass;
            }
            else if (ScalesControlPosition.x < t.position.x)
            {
                rightmass += mass;
            }
            else
            {

            }
        }

        //float summary = rightmass + leftmass;
        _Bar.ShowResult(leftmass, rightmass);
        //m_TextMeshPro.text = (int) (leftmass/summary * 100) + " " + (int) (rightmass/summary * 100);
    }
}
