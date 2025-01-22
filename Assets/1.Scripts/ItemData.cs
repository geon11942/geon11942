using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Analytics.IAnalytic;


public enum ItemType
{
    Food,
    Equipent,
    Furniture,
    UseItem,
    Material,
}
public enum EquipType
{
    None,
    Hand,
    Body,
    Head
}
[CreateAssetMenu(fileName = "ItemTable Data", menuName = "Scriptable Object/ItemTable Data", order = int.MaxValue)]
[System.Serializable]
public class ItemDataTable : ScriptableObject
{

    [SerializeField]
    public Sprite Obj_image;
    public Sprite Item_Image;
    public string Name;
    public int Item_ID = -1;
    public ItemType IType = ItemType.Material;
    public int Durability = 100;
    public int TimeLimit = -1;
    public int UseCount = -1;
    public float Atk = -1;
    public float Def = -1;
    public float F_Hp = -1;
    public float F_Hunger = -1;
    public float F_San = -1;
    public int MaxStack = 1;
    public int Stack = 1;
    
    public void DataSet(ItemDataTable data)
    {
        Item_Image = data.Item_Image;
        Name = data.Name;
        Item_ID = data.Item_ID;
        IType = data.IType;
        Durability = data.Durability;
        TimeLimit = data.TimeLimit;
        UseCount = data.UseCount;
        Atk = data.Atk;
        Def = data.Def;
        F_Hp = data.F_Hp;
        F_Hunger = data.F_Hunger;
        F_San = data.F_San;
        MaxStack = data.MaxStack;
        Stack = data.Stack;
    }
    public ItemType TypeGS
    {
        get { return IType; }
        set { IType = value; }
    }
    public Sprite ImageGS
    {
        get { return Item_Image; }
        set { Item_Image = value; }
    }
    public int IDGS
    {
        get { return Item_ID; }
        set { IDGS = value; }
    }
    public int MaxStackGS
    {
        get { return MaxStack; }
        set { MaxStack = value; }
    }
    public int StackGS
    {
        get { return Stack; }
        set { Stack += value; }
    }
    public float F_HpGet { get { return F_Hp; } }
    public float F_HungerGet { get { return F_Hunger; } }
    public float F_SanGet { get { return F_San; } }
}




public class ItemData : MonoBehaviour
{
    //public enum ItemType
    //{
    //    Food,
    //    Equipent,
    //    Furniture,
    //    UseItem,
    //    Material,
    //}
    [SerializeField]
    private Sprite Item_Image;
    public string Name;
    public int Item_ID = -1;
    public ItemType IType = ItemType.Material;
    public int Durability = 100;
    public int TimeLimit = -1;
    public int UseCount = -1;
    public float Atk = -1;
    public float Def = -1;
    public float F_Hp = -1;
    public float F_Hunger = -1;
    public float F_San = -1;
    public int MaxStack = 1;
    public int Stack = 1;
    public EquipType EType = EquipType.None;


    //public ItemDataTable m_LinkeItemData = null;

    void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Item_Image;
            //gameObject.GetComponent<SpriteRenderer>().sprite = m_LinkeItemData.Item_Image;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DataSet(ItemData data)
    {
        Item_Image =data.Item_Image;
        Name =data.Name;
        Item_ID = data.Item_ID;
        IType = data.IType;
        Durability = data.Durability;
        TimeLimit = data.TimeLimit;
        UseCount = data.UseCount;
        Atk = data.Atk;
        Def = data.Def;
        F_Hp = data.F_Hp;
        F_Hunger = data.F_Hunger;
        F_San = data.F_San;
        MaxStack = data.MaxStack;
        Stack = data.Stack;
    }
    public void DataSet(ItemDataTable data)
    {
        Item_Image = data.Item_Image;
        Name = data.Name;
        Item_ID = data.Item_ID;
        IType = data.IType;
        Durability = data.Durability;
        TimeLimit = data.TimeLimit;
        UseCount = data.UseCount;
        Atk = data.Atk;
        Def = data.Def;
        F_Hp = data.F_Hp;
        F_Hunger = data.F_Hunger;
        F_San = data.F_San;
        MaxStack = data.MaxStack;
        Stack = data.Stack;
    }
    public EquipType ETypeGS
    {
        get { return EType; }
        set { EType = value; }
    }
    public ItemType TypeGS
    {
        get { return IType; }
        set { IType = value; }
    }
    public Sprite ImageGS
    { 
        get { return Item_Image; }
        set { Item_Image = value; }
    }
    public int IDGS
    {
        get { return Item_ID; }
        set { Item_ID = value; }
    }
    public int MaxStackGS
    {
        get { return MaxStack; }
        set { MaxStack = value; }
    }
    public int StackGS
    {
        get { return Stack; }
        set { Stack += value; }
    }
    public float F_HpGet {  get { return F_Hp; } }
    public float F_HungerGet { get { return F_Hunger; } }
    public float F_SanGet { get { return F_San; } }
}
