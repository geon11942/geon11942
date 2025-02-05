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
    ItemDataTable _itemData =null;
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
            if (_itemData.Stack > 1)
            {
                _text.SetActive(true);
                _text.GetComponent<Text>().text = _itemData.Stack.ToString();
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
    public void DataSet(ItemDataTable data)
    {
        _itemData= data;
    }
    public ItemDataTable ItemGS
    {
        get { return _itemData; }
        set 
        {
            _itemData = value;
            DataSet(_itemData);
            NeedItem=true;
            CheckStack();
            ImageGS = _itemData.Item_Image;
        }
    }
    Sprite ImageGS
    {
        get { return image; }
        set 
        { 
            image = value;
            _Image.gameObject.GetComponent<Image>().sprite = image;
            if (_itemData.Stack > 0) 
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
            switch (_itemData.Item_Type)
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
        Player.GetComponent<PlayerData>().SetHp = _itemData.F_Hp;
        Player.GetComponent<PlayerData>().SetHunger = _itemData.F_Hunger;
        Player.GetComponent<PlayerData>().SetSan = _itemData.F_San;
        _itemData.Stack =-1;
        CheckStack();
        if(_itemData.Stack ==0)
        {
            SlotEmpty();
        }
    }
    void UseEquipment()
    {
        ItemDataTable Edata = Player.GetComponent<Equipment>().UseEquipItem(_itemData);
        //Debug.Log(Edata.ToString());
        if(Edata != null)
        {
            _itemData = Edata;
            CheckStack();
            ImageGS = _itemData.Item_Image;
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
