using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    int slotIndex;
    GameObject item;
#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        slotIndex = 0;
    }
#endif
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Item
    {
        get { return item; }
        set 
        {
            item = value;
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[slotIndex].ItemGS != null)
                {
                    slots[slotIndex].ItemGS = item.GetComponent<ItemData>();
                    break;
                }
            }
        }
    }
}
