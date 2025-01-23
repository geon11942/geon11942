using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    GameObject MouseSys;
    GameObject Player;
    public GameObject[] EquipSlot = new GameObject[3];
    public GameObject[] SlotImages = new GameObject[3];
    //public ItemDataTable[] itemDatas = new ItemDataTable[3];
    [SerializeField]
    ItemData[] _itemData = new ItemData[3];
    bool HandOn = false;
    bool BodyOn = false;
    bool HeadOn = false;
    void Start()
    {
        MouseSys = GameObject.Find("MouseSystem");
        Player = GameObject.Find("Player");
        EquipSlot[0] = GameObject.Find("Hand");
        SlotImages[0] = EquipSlot[0].gameObject.transform.GetChild(0).gameObject;
        EquipSlot[1] = GameObject.Find("Body");
        SlotImages[1] = EquipSlot[1].gameObject.transform.GetChild(0).gameObject;
        EquipSlot[2] = GameObject.Find("Head");
        SlotImages[2] = EquipSlot[2].gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < EquipSlot.Length; i++)
            {
                Vector3 SlotPos = Camera.main.ScreenToWorldPoint(new Vector3(EquipSlot[i].transform.position.x,
                           EquipSlot[i].transform.position.y, -Camera.main.transform.position.z));
                Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, -Camera.main.transform.position.z));
                if (SlotPos.x - 0.35f < MousePos.x && SlotPos.x + 0.35f > MousePos.x &&
                        SlotPos.y - 0.35f < MousePos.y && SlotPos.y + 0.35f > MousePos.y)
                {
                    if(SlotCheckItem(i))
                    {
                        if (MouseSys.GetComponent<MouseItem>().CheckNeedItem())
                        {
                            if (MouseSys.GetComponent<MouseItem>().TypeGS == ItemType.Equipment)
                            {
                                if(MouseSys.GetComponent<MouseItem>().ETypeGS==EquipType.Hand && i!=0)
                                {
                                    continue;
                                }
                                else if (MouseSys.GetComponent<MouseItem>().ETypeGS == EquipType.Body && i != 1)
                                {
                                    continue;
                                }
                                else if (MouseSys.GetComponent<MouseItem>().ETypeGS == EquipType.Head && i != 2)
                                {
                                    continue;
                                }
                                ItemData Idata = null;
                                int slotnum = -1;
                                switch (MouseSys.GetComponent<MouseItem>().ETypeGS)
                                {
                                    case EquipType.Hand:
                                        Idata = _itemData[0];
                                        _itemData[0] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        MouseSys.GetComponent<MouseItem>().ItemGS = Idata;
                                        slotnum = 0;
                                        if (!HandOn)
                                        {
                                            MouseSys.GetComponent<MouseItem>().ItemEmpty();
                                        }
                                        break;
                                    case EquipType.Body:
                                        Idata = _itemData[1];
                                        _itemData[1] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        MouseSys.GetComponent<MouseItem>().ItemGS = Idata;
                                        slotnum = 1;
                                        if (!BodyOn)
                                        {
                                            MouseSys.GetComponent<MouseItem>().ItemEmpty();
                                        }
                                        break;
                                    case EquipType.Head:
                                        Idata = _itemData[2];
                                        _itemData[2] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        MouseSys.GetComponent<MouseItem>().ItemGS = Idata;
                                        slotnum = 2;
                                        if (!HeadOn)
                                        {
                                            MouseSys.GetComponent<MouseItem>().ItemEmpty();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                Idata = null;
                                EquipSet(slotnum);
                            }
                        }
                        else
                        {
                            MouseSys.GetComponent<MouseItem>().ItemGS = _itemData[i];
                            SlotEmpty(i);
                        }
                    }
                    else
                    {
                        if (MouseSys.GetComponent<MouseItem>().CheckNeedItem())
                        {
                            if (MouseSys.GetComponent<MouseItem>().TypeGS == ItemType.Equipment)
                            {
                                if (MouseSys.GetComponent<MouseItem>().ETypeGS == EquipType.Hand && i != 0)
                                {
                                    continue;
                                }
                                else if (MouseSys.GetComponent<MouseItem>().ETypeGS == EquipType.Body && i != 1)
                                {
                                    continue;
                                }
                                else if (MouseSys.GetComponent<MouseItem>().ETypeGS == EquipType.Head && i != 2)
                                {
                                    continue;
                                }
                                int slotnum = -1;
                                switch (MouseSys.GetComponent<MouseItem>().ETypeGS)
                                {
                                    case EquipType.Hand:
                                        _itemData[0] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        slotnum = 0;
                                        break;
                                    case EquipType.Body:
                                        _itemData[1] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        slotnum = 1;
                                        break;
                                    case EquipType.Head:
                                        _itemData[2] = MouseSys.GetComponent<MouseItem>().ItemGS;
                                        slotnum = 2;
                                        break;
                                    default:
                                        break;
                                }
                                MouseSys.GetComponent<MouseItem>().ItemEmpty();
                                EquipSet(slotnum);
                            }
                        }
                    }
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            if (HandOn || BodyOn || HeadOn)
            {
                for (int i = 0; i < EquipSlot.Length; i++)
                {
                    if (!HandOn && i == 0)
                    {
                        continue;
                    }
                    else if (!BodyOn && i == 1)
                    {
                        continue;
                    }
                    else if (!HeadOn && i == 2)
                    {
                        continue;
                    }
                    Vector3 SlotPos = Camera.main.ScreenToWorldPoint(new Vector3(EquipSlot[i].transform.position.x,
                               EquipSlot[i].transform.position.y, -Camera.main.transform.position.z));
                    Vector3 MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));
                    if (SlotPos.x - 0.35f < MousePos.x && SlotPos.x + 0.35f > MousePos.x &&
                            SlotPos.y - 0.35f < MousePos.y && SlotPos.y + 0.35f > MousePos.y)
                    {
                        if(HandOn && i == 0)
                        {
                            if (Player.GetComponent<Inventory>().UnEquipItem(_itemData[i]))
                            {
                                SlotEmpty(i);
                            }
                        }
                        else if (BodyOn && i == 1)
                        {
                            if (Player.GetComponent<Inventory>().UnEquipItem(_itemData[i]))
                            {
                                SlotEmpty(i);
                            }
                        }
                        else if (HeadOn && i == 2)
                        {
                            if (Player.GetComponent<Inventory>().UnEquipItem(_itemData[i]))
                            {
                                SlotEmpty(i);
                            }
                        }
                    }
                }
            }
        }
    }
    public ItemData UseEquipItem(ItemData item)
    {
        switch (item.ETypeGS)
        {
            case EquipType.Hand:
                if(HandOn)
                {
                    ItemData Idata=_itemData[0];
                    _itemData[0] = item;
                    EquipSet(0);
                    return Idata;
                }
                else
                {
                    _itemData[0] = item;
                    EquipSet(0);
                    return null;
                }
            case EquipType.Body:
                if (BodyOn)
                {
                    ItemData Idata = _itemData[1];
                    _itemData[1] = item;
                    EquipSet(1);
                    return Idata;
                }
                else
                {
                    _itemData[1] = item;
                    EquipSet(1);
                    return null;
                }
            case EquipType.Head:
                if (HeadOn)
                {
                    ItemData Idata = _itemData[2];
                    _itemData[2] = item;
                    EquipSet(2);
                    return Idata;
                }
                else
                {
                    _itemData[2] = item;
                    EquipSet(2);
                    return null;
                }
            default:
                return null;
        }
    }
    bool SlotCheckItem(int slotnum) 
    {
        switch (slotnum) 
        {
            case 0:
                if (HandOn) return true;
                else return false;
            case 1:
                if (BodyOn) return true;
                else return false;
            case 2:
                if (HeadOn) return true;
                else return false;
            default:
                return false;
        }
    }
    void EquipSet(int s_slotnum)
    {
        switch (s_slotnum)
        {
            case 0:
                HandOn = true;
                break;
            case 1:
                BodyOn = true;
                break;
            case 2:
                HeadOn = true;
                break;
            default:
                return;
        }
        SlotImages[s_slotnum].gameObject.GetComponent<Image>().sprite = _itemData[s_slotnum].ImageGS;
        SlotImages[s_slotnum].gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void SlotEmpty(int s_slotnum)
    {
        _itemData[s_slotnum] = null;
        switch (s_slotnum) 
        {
            case 0:
                HandOn = false;
                break;
            case 1:
                BodyOn= false;
                break;
            case 2:
                HeadOn = false;
                break;
            default:
                break;
        }
        SlotImages[s_slotnum].gameObject.GetComponent<Image>().sprite = null;
        SlotImages[s_slotnum].gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        //CheckStack();
    }
}
