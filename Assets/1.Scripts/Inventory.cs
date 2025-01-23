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
    GameObject MouseSys;
    GameObject item;
    bool InvenFull = false;
#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        slotIndex = 0;
    }
#endif
    void Start()
    {
        MouseSys = GameObject.Find("MouseSystem");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].CheckNeedItem())
                {
                    Vector3 SlotPos = Camera.main.ScreenToWorldPoint(new Vector3(slots[i].transform.position.x,
                        slots[i].transform.position.y, -Camera.main.transform.position.z));
                    Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));
                    Debug.Log("슬롯 위치 :" + SlotPos);
                    Debug.Log("마우스 위치 :" + MousePos);
                    if (SlotPos.x - 0.35f < MousePos.x && SlotPos.x + 0.35f > MousePos.x &&
                        SlotPos.y - 0.35f < MousePos.y && SlotPos.y + 0.35f > MousePos.y)
                    {
                        if (MouseSys.GetComponent<MouseItem>().CheckNeedItem()) 
                        { 
                            ItemData Idata = slots[i].ItemGS;
                            slots[i].ItemGS=MouseSys.GetComponent<MouseItem>().ItemGS;
                            MouseSys.GetComponent<MouseItem>().ItemGS = Idata;
                            Idata = null;
                        }
                        else
                        {
                            MouseSys.GetComponent<MouseItem>().ItemGS = slots[i].ItemGS;
                            slots[i].SlotEmpty();
                        }
                    }
                }
                else
                {
                    Vector3 SlotPos = Camera.main.ScreenToWorldPoint(new Vector3(slots[i].transform.position.x,
                        slots[i].transform.position.y, -Camera.main.transform.position.z));
                    Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));
                    Debug.Log("슬롯 위치 :" + SlotPos);
                    Debug.Log("마우스 위치 :" + MousePos);
                    if (SlotPos.x - 0.35f < MousePos.x && SlotPos.x + 0.35f > MousePos.x &&
                        SlotPos.y - 0.35f < MousePos.y && SlotPos.y + 0.35f > MousePos.y)
                    {
                        if (MouseSys.GetComponent<MouseItem>().CheckNeedItem())
                        {
                            slots[i].ItemGS = MouseSys.GetComponent<MouseItem>().ItemGS;
                            MouseSys.GetComponent<MouseItem>().ItemEmpty();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) 
        { 
            for(int i=0; i<slots.Length; i++)
            {
                if (slots[i].CheckNeedItem())
                {
                    Vector3 SlotPos = Camera.main.ScreenToWorldPoint(new Vector3(slots[i].transform.position.x,
                        slots[i].transform.position.y, -Camera.main.transform.position.z));
                    Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));
                    Debug.Log("슬롯 위치 :" + SlotPos);
                    Debug.Log("마우스 위치 :" + MousePos);
                    if (SlotPos.x-0.35f<MousePos.x && SlotPos.x + 0.35f > MousePos.x && 
                        SlotPos.y - 0.35f < MousePos.y && SlotPos.y + 0.35f > MousePos.y)
                    {
                        slots[i].SlotUse();
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        NumKeyDown();
    }

    void NumKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (slots[0].CheckNeedItem())
            {
                slots[0].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (slots[1].CheckNeedItem())
            {
                slots[1].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (slots[2].CheckNeedItem())
            {
                slots[2].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (slots[3].CheckNeedItem())
            {
                slots[3].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (slots[4].CheckNeedItem())
            {
                slots[4].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (slots[5].CheckNeedItem())
            {
                slots[5].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (slots[6].CheckNeedItem())
            {
                slots[6].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (slots[7].CheckNeedItem())
            {
                slots[7].SlotUse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (slots[8].CheckNeedItem())
            {
                slots[8].SlotUse();
            }
        }
    }
    public bool UnEquipItem(ItemData item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].CheckNeedItem())
            {
                slots[i].ItemGS = item;
                return true;
            }
        }
        return false;
    }
    public GameObject ItemGS
    {
        get { return item; }
        set 
        {
            item = value;
            InvenFull=true;
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].CheckNeedItem())
                {
                    if (slots[i].ItemGS.IDGS == item.GetComponent<ItemData>().IDGS && slots[i].ItemGS.MaxStackGS > 1 && slots[i].ItemGS.StackGS < slots[i].ItemGS.MaxStackGS)
                    {
                        if (slots[i].ItemGS.StackGS + item.GetComponent<ItemData>().StackGS > slots[i].ItemGS.MaxStackGS)
                        {
                            item.GetComponent<ItemData>().StackGS = -(slots[i].ItemGS.MaxStackGS - slots[i].ItemGS.StackGS);
                            slots[i].ItemGS.StackGS = slots[i].ItemGS.MaxStackGS - slots[i].ItemGS.StackGS;
                            slots[i].CheckStack();
                            Debug.Log("아이템 스택 초과.");
                        }
                        else
                        {
                            slots[i].ItemGS.StackGS = item.GetComponent<ItemData>().StackGS;
                            slots[i].CheckStack();
                            InvenFull = false;
                            item = null;
                            break;
                        }
                    }
                }
            }
            if (item != null)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (!slots[i].CheckNeedItem())
                    {
                        slots[i].ItemGS = item.GetComponent<ItemData>();
                        //slots[i].DataSet(item.GetComponent<ItemData>());
                        Debug.Log("획득한 아이템 칸 :" + i);
                        InvenFull = false;
                        break;
                    }
                }
            }
            if(InvenFull)
            {
                Debug.Log("인벤토리 가득 참. 아이템 드랍");
                //여기에 드랍 아이템 바닥에 버리는 코드
            }
        }
    }
    public int IndexGet
    {
        get { return slotIndex; }
    }
}
