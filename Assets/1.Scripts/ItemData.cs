using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Analytics.IAnalytic;

public class ItemData : MonoBehaviour
{
    public ItemDataTable ItemDataTable;

    void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ItemDataTable.Item_Image;
        }
    }
}
