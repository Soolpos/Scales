using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateWeight_Size : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CreateMenu CreateMenu;
    [SerializeField] float Size;

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
        CreateMenu.Choise_Minu2(Size);
    }

}
