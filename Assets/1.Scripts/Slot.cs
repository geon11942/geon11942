using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    ItemData _itemData;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public ItemData ItemGS
    {
        get { return _itemData; }
        set 
        { 
            _itemData = value;
            ImageGS = _itemData.Item_Image;
        }
    }
    Image ImageGS
    {
        get { return image; }
        set 
        { 
            image = value; 
            
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Mouse Click Button : Left");
        }
        //else if (eventData.button == PointerEventData.InputButton.Middle)
        //{
        //    Debug.Log("Mouse Click Button : Middle");
        //}
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Mouse Click Button : Right");
        }

        //Debug.Log("Mouse Position : " + eventData.position);
        //Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
}
