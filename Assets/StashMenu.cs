using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StashMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonopen;
    [SerializeField] GameObject buttonclose;

    [SerializeField] Transform plane;
    [SerializeField] Transform topBorder;
    [SerializeField] Transform botBorder;

    [SerializeField] float speed;
    bool moving = false;
    bool open;
    Vector3 postomove;

    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            if(open)
            {
                if (Mathf.Abs(topBorder.position.y - postomove.y) <= 0.3f)
                {
                    moving = false;
                }
                else
                {
                    transform.position = transform.position + speed * Time.deltaTime * Vector3.up;
                }
            }
            else
            {
                if (Mathf.Abs(botBorder.position.y - postomove.y) <= 0.3f)
                {
                    moving = false;
                }
                else
                {
                    transform.position = transform.position + speed * Time.deltaTime * Vector3.down;
                }
            }
        }
    }

    public void Open()
    {
        moving = true;
        open = true;
        postomove = plane.position;
    }

    public void Close()
    {
        moving = true;
        open = false;
        postomove = plane.position + Vector3.down;

        buttonopen.SetActive(true);
        buttonclose.SetActive(false);
    }
}
