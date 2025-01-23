using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.LightingExplorerTableColumn;

public class MouseItem : MonoBehaviour
{
    Camera Camera;
    [SerializeField]
    ItemData IData;
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
    public ItemData ItemGS
    {
        get { return IData; }
        set 
        { 
            IData = value;
            NeedItem = true;
            ImageObj.GetComponent<Image>().sprite=IData.ImageGS;
            ImageObj.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
    public ItemType TypeGS
    {
        get { return IData.ItemDataTable.IType; }
        set { IData.ItemDataTable.IType = value; }
    } 
    public EquipType ETypeGS
    {
        get { return IData.ItemDataTable.EType; }
        set { IData.ItemDataTable.EType = value; }
    }
    public void ItemEmpty()
    {
        NeedItem = false;
        IData = null;
        ImageObj.GetComponent<Image>().sprite = null;
        ImageObj.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
