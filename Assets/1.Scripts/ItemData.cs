using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Analytics.IAnalytic;



[CreateAssetMenu(fileName = "ItemTable Data", menuName = "Scriptable Object/ItemTable Data", order = int.MaxValue)]
[System.Serializable]
public class ItemDataTables : ScriptableObject
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
    
    public void DataSet(ItemDataTables data)
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


[Serializable]
public class TableItemDataCls
{
    [SerializeField]
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
    public EquipType EType = EquipType.None;
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

    //public TableItemDataCls ItemDataTable;
    public ItemDataTable ItemDataTable;

    //[SerializeField]
    //public Sprite Item_Image;
    //public string Name;
    //public int Item_ID = -1;
    //public ItemType IType = ItemType.Material;
    //public int Durability = 100;
    //public int TimeLimit = -1;
    //public int UseCount = -1;
    //public float Atk = -1;
    //public float Def = -1;
    //public float F_Hp = -1;
    //public float F_Hunger = -1;
    //public float F_San = -1;
    //public int MaxStack = 1;
    //public int Stack = 1;
    //public EquipType EType = EquipType.None;


    //public ItemDataTable m_LinkeItemData = null;

    void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ItemDataTable.Item_Image;
            //gameObject.GetComponent<SpriteRenderer>().sprite = m_LinkeItemData.Item_Image;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DataSet(ItemDataTable data)
    {
        this.ItemDataTable = data;

        //InTableData.Item_Image = data.Item_Image;
        //InTableData.Name =data.Name;
        //InTableData.Item_ID = data.Item_ID;
        //InTableData.IType = data.IType;
        //InTableData.Durability = data.Durability;
        //InTableData.TimeLimit = data.TimeLimit;
        //InTableData.UseCount = data.UseCount;
        //InTableData.Atk = data.Atk;
        //InTableData.Def = data.InTableData.Def;
        //InTableData.F_Hp = data.InTableData.F_Hp;
        //InTableData.F_Hunger = data.InTableData.F_Hunger;
        //InTableData.F_San = data.InTableData.F_San;
        //InTableData.MaxStack = data.InTableData.MaxStack;
        //InTableData.Stack = data.InTableData.Stack;
        //InTableData.EType = data.InTableData.EType;
    }
    //public void DataSet(ItemDataTable data)
    //{
    //    Item_Image = data.Item_Image;
    //    Name = data.Name;
    //    Item_ID = data.Item_ID;
    //    IType = data.IType;
    //    Durability = data.Durability;
    //    TimeLimit = data.TimeLimit;
    //    UseCount = data.UseCount;
    //    Atk = data.Atk;
    //    Def = data.Def;
    //    F_Hp = data.F_Hp;
    //    F_Hunger = data.F_Hunger;
    //    F_San = data.F_San;
    //    MaxStack = data.MaxStack;
    //    Stack = data.Stack;
    //}
    public EquipType ETypeGS
    {
        get { return ItemDataTable.EType; }
        set { ItemDataTable.EType = value; }
    }
    public ItemType TypeGS
    {
        get { return ItemDataTable.IType; }
        set { ItemDataTable.IType = value; }
    }
    public Sprite ImageGS
    {
        get { return ItemDataTable.Item_Image; }
        set { ItemDataTable.Item_Image = value; }
    }
    public int IDGS
    {
        get { return ItemDataTable.Item_ID; }
        set { ItemDataTable.Item_ID = value; }
    }
    public int MaxStackGS
    {
        get { return ItemDataTable.MaxStack; }
        set { ItemDataTable.MaxStack = value; }
    }
    public int StackGS
    {
        get { return ItemDataTable.Stack; }
        set { ItemDataTable.Stack += value; }
    }
    public float F_HpGet {  get { return ItemDataTable.F_Hp; } }
    public float F_HungerGet { get { return ItemDataTable.F_Hunger; } }
    public float F_SanGet { get { return ItemDataTable.F_San; } }
}
