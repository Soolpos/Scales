using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MenuWeight: MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    //float doubleClickTime = .2f, lastClickTime;

    Transform WeightStash_Forward;
    Transform WeightStash_Back;

    bool active = true;

    public virtual void Start()
    {
        Links l = Links.GetInstance();
        WeightStash_Back = l.WeightStash_Back;
        WeightStash_Forward = l.WeightStash_Forward;


    }

    void OnMouseDown()
    {
        //float timeSinceLastClick = Time.time - lastClickTime;

        //if (timeSinceLastClick <= doubleClickTime)
        //{
        //    //it's double click
        //    MoveOnOtherStash();
        //}

        //lastClickTime = Time.time;

        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if(active)
        {
            CreateWeight();
        }
    }

    void CreateWeight()
    {
        GameObject NewW = Instantiate(gameObject, transform.position, Quaternion.identity, WeightStash_Forward);
        NewW.AddComponent<Weight>();
        NewW.GetComponent<MenuWeight>().Deactivate();
        Rigidbody rb = NewW.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

        gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        active = false;
    }

    private void OnMouseUp()
    {
        //Vector3 cameraToObject = transform.position - Camera.main.transform.position;

        //// отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        //float distance = Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        //// вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        //Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, distance));
        //Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.9f, distance));

        //// границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        //float x_left = leftBot.x;
        //float x_right = rightTop.x;
        //float y_top = rightTop.y;
        //float y_bot = leftBot.y;

        //// ограничиваем объект в плоскости XZ
        //if ((transform.position.x < x_left || transform.position.x > x_right) || (transform.position.y < y_bot || transform.position.y > y_top))
        //    Destroy(gameObject);

        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;

        ////if (transform.position.y < y_bot || transform.position.y > y_top)
        ////    Debug.Log("y");

    }

}
