using UnityEngine;
public enum ItemType
{
    Food,
    Equipment,
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
[CreateAssetMenu(fileName = "ItemDataTable", menuName = "Scriptable Object/ItemDataTable", order = int.MaxValue)]
public class ItemDataTable : ScriptableObject
{
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
