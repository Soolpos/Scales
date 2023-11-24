using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateWeight_Form : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CreateMenu CreateMenu;
    [SerializeField] GameObject Form;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CreateMenu.Choise_Minu1(Form);
    }

}
