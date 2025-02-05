using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.LightingExplorerTableColumn;

public class MouseItem : MonoBehaviour
{
    Camera Camera;
    [SerializeField]
    ItemDataTable ItemData;
    Vector2 MousePos;
    bool NeedItem = false;
    GameObject ImageObj;
    void Start()
    {
        ImageObj = GameObject.Find("MouseItemImage");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ImageObj.GetComponent<Image>().sprite = null;
        ImageObj.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.position = MousePos;
        ImageObj.transform.position = Camera.main.WorldToScreenPoint( MousePos);
        //Debug.Log(MousePos);
    }
    public bool CheckNeedItem()
    {
        return NeedItem;
    }
    public ItemDataTable ItemGS
    {
        get { return ItemData; }
        set 
        { 
            ItemData = value;
            NeedItem = true;
            ImageObj.GetComponent<Image>().sprite=ItemData.Item_Image;
            ImageObj.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
    public ItemType TypeGS
    {
        get { return ItemData.Item_Type; }
        set { ItemData.Item_Type = value; }
    } 
    public EquipType ETypeGS
    {
        get { return ItemData.Equip_Type; }
        set { ItemData.Equip_Type = value; }
    }
    public void ItemEmpty()
    {
        NeedItem = false;
        ItemData = null;
        ImageObj.GetComponent<Image>().sprite = null;
        ImageObj.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
