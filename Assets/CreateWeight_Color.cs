using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateWeight_Color : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CreateMenu CreateMenu;
    [SerializeField] Material _color;
    [SerializeField] float _weight;

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
        CreateMenu.Choise_Minu3(_color, _weight);
    }

}
