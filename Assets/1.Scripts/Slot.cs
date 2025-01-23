using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Sprite image;
    [SerializeField]
    ItemData _itemData=null;
    bool NeedItem=false;
    GameObject Player;
    GameObject _Image;
    GameObject _text;
    void Start()
    {
        Player = GameObject.Find("Player");
        _Image = transform.GetChild(0).gameObject;
        _text = transform.GetChild(1).gameObject;
        if (image != null)
        {
            _Image.gameObject.GetComponent<Image>().sprite = image;
            _Image.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            _Image.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        _text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public bool CheckNeedItem()
    {
        if(NeedItem)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public void CheckStack()
    {
        if(NeedItem)
        {
            if (_itemData.StackGS > 1)
            {
                _text.SetActive(true);
                _text.GetComponent<Text>().text = _itemData.StackGS.ToString();
            }
            else
            {
                _text.SetActive(false);
            }
        }
        else
        {
            _text.SetActive(false);
        }
    }
    public void DataSet(ItemData data)
    {
        //_itemData.Item_Image = data.Item_Image;
        //_itemData.Name = data.Name;
        //_itemData.Item_ID = data.Item_ID;
        //_itemData.IType = data.IType;
        //_itemData.Durability = data.Durability;
        //_itemData.TimeLimit = data.TimeLimit;
        //_itemData.UseCount = data.UseCount;
        //_itemData.Atk = data.Atk;
        //_itemData.Def = data.Def;
        //_itemData.F_Hp = data.F_Hp;
        //_itemData.F_Hunger = data.F_Hunger;
        //_itemData.F_San = data.F_San;
        //_itemData.MaxStack = data.MaxStack;
        //_itemData.Stack = data.Stack;
        //_itemData.EType = data.EType;
    }
    public ItemData ItemGS
    {
        get { return _itemData; }
        set 
        {
            _itemData = value;
            DataSet(_itemData);
            NeedItem=true;
            CheckStack();
            ImageGS = _itemData.ImageGS;
        }
    }
    Sprite ImageGS
    {
        get { return image; }
        set 
        { 
            image = value;
            _Image.gameObject.GetComponent<Image>().sprite = image;
            if (_itemData.StackGS > 0) 
            {
                _Image.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            else
            {
                _Image.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
    }
    public void SlotUse()
    {
        if (CheckNeedItem())
        {
            Debug.Log("아이템 사용");
            switch (_itemData.TypeGS)
            {
                case ItemType.Food:
                    Debug.Log("음식 사용");
                    UseFood();
                    break;
                case ItemType.Equipment:
                    UseEquipment();
                    break;
                case ItemType.Furniture:
                    break;

            }
        }
    }
    public void UseFood()
    {
        Player.GetComponent<PlayerData>().SetHp = _itemData.F_HpGet;
        Player.GetComponent<PlayerData>().SetHunger = _itemData.F_HungerGet;
        Player.GetComponent<PlayerData>().SetSan = _itemData.F_SanGet;
        _itemData.StackGS=-1;
        CheckStack();
        if(_itemData.StackGS==0)
        {
            SlotEmpty();
        }
    }
    void UseEquipment()
    {
        ItemData Edata = Player.GetComponent<Equipment>().UseEquipItem(_itemData);
        //Debug.Log(Edata.ToString());
        if(Edata != null)
        {
            _itemData = Edata;
            CheckStack();
            ImageGS = _itemData.ImageGS;
        }
        else
        {
            SlotEmpty();
        }
        
    }
    public void SlotEmpty()
    {
        _itemData = null;
        image = null;
        _Image.gameObject.GetComponent<Image>().sprite = null;
        _Image.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        NeedItem = false;
        CheckStack();
    }
}
