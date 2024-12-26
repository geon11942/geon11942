using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemData : MonoBehaviour
{
    public enum ItemType
    {
        Food,
        Equipent,
        Furniture,
        UseItem,
        Material,
    }
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
    public Image Item_Image;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public ItemType TypeGS
    {
        get { return IType; }
        set { IType = value; }
    }
    public float F_HpGet {  get { return F_Hp; } }
    public float F_HungerGet { get { return F_Hunger; } }
    public float F_SanGet { get { return F_San; } }
}
