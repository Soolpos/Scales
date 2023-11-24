using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    [SerializeField] GameObject CreateButton;
    [SerializeField] GameObject CancelButton;
  
    Transform WeightStash_Forward;
    Transform WeightStash_Back;

    [SerializeField] GameObject Menu1;
    [SerializeField] GameObject Menu2;
    [SerializeField] GameObject Menu3;

    GameObject form;
    float size;
    Material color;
    float mass;

    private void Start()
    {
        Links l = Links.GetInstance();
        WeightStash_Back = l.WeightStash_Back;
        WeightStash_Forward = l.WeightStash_Forward;
    }

    public void CreateButton_onClick()
    {
        CancelButton.SetActive(true);

        Menu1.SetActive(true);
    }

    public void CancelButton_onClick()
    {
        CancelButton.SetActive(false);

        Menu1.SetActive(false);
        Menu2.SetActive(false);
        Menu3.SetActive(false);
    }

    public void Choise_Minu1(GameObject _form)
    {
        form = _form;

        Menu1.SetActive(false);
        Menu2.SetActive(true);   
    }

    public void Choise_Minu2(float _size)
    {
        size = _size;

        Menu2.SetActive(false);
        Menu3.SetActive(true);
    }

    public void Choise_Minu3(Material _color, float _mass)
    {
        color = _color;
        mass = _mass;

        CreateWeight();
    }

    void CreateWeight()
    {
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = Vector3.Project(cameraToObject, Camera.main.transform.forward).z;
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.9f, distance));

        form.transform.localScale = new Vector3(size, size, size);
        form.GetComponent<MeshRenderer>().material = color;

        // Расчет массы
        mass *= size;
        form.GetComponent<Rigidbody>().mass = mass;
        //

        Instantiate(form, pos, Quaternion.identity, WeightStash_Forward);

        CancelButton_onClick();
    }
}
