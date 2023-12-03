using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DragDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    float doubleClickTime = .2f, lastClickTime;
    Rigidbody rb;
    Transform WeightStash_Forward;
    Transform WeightStash_Back;
   
    // protected Mouse _mouse;

    bool sleep = true;
    bool drag = false;
    bool onthefloor = false;

    Vector3 leftBot;
    Vector3 rightTop;

    public virtual void Start()
    { 
        Links l = Links.GetInstance();
        WeightStash_Back = l.WeightStash_Back;
        WeightStash_Forward = l.WeightStash_Forward;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if(!sleep && !drag)
        {
            float x_left = leftBot.x;
            float x_right = rightTop.x;
            float y_top = rightTop.y;
            float y_bot = leftBot.y;

            if ((transform.position.x < x_left || transform.position.x > x_right) || (transform.position.y < y_bot )) //|| transform.position.y > y_top
                Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        float timeSinceLastClick = Time.time - lastClickTime;

        if (timeSinceLastClick <= doubleClickTime)
        {
            //it's double click
            Transform newp;

            if (transform.parent == WeightStash_Forward)
            {
                newp = WeightStash_Back;
            }
            else
            {
                newp = WeightStash_Forward;
            }

            MoveOnOtherStash(newp);
        }
        
        lastClickTime = Time.time;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        
    }

    void MoveOnOtherStash(Transform newp)
    {
        transform.parent = newp;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.parent.position.z);

        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = Vector3.Project(cameraToObject, Camera.main.transform.forward).z;
        leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, distance));
        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.95f, distance));
    }    

    void OnMouseDrag()
    {
        drag = true;

        if (sleep)
        {
            // create copy on menu stash
            GameObject copy = Instantiate(this.gameObject, this.transform.position, Quaternion.identity, this.transform.parent);

            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;

            MoveOnOtherStash(WeightStash_Forward);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.parent.position.z);

            Links.GetInstance()._StashMenu.Close();
            gameObject.layer = 0;

            // Расчет массы
            rb.mass *= transform.localScale.x;
            //

            sleep = false;
        }

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        if (onthefloor)
        {
            if (cursorPosition.y < transform.position.y)
                cursorPosition.y = transform.position.y;// Links.GetInstance()._floor.position.y;
        }

        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.parent.position.z);

        //Stop Moving/Translating & stop rotating
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        drag = false;

        // ChangeActive(false);
    }

    public void changeOnthefloor(bool t)
    {
        onthefloor = t;
    }
}

