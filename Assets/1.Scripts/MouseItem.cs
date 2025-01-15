using UnityEngine;

public class MouseItem : MonoBehaviour
{
    Camera Camera;
    ItemData IData;
    Vector2 MousePos;
    bool NeedItem = false;

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.position = MousePos;
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
            GetComponent<SpriteRenderer>().sprite=IData.ImageGS;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
    public void ItemEmpty()
    {
        NeedItem = false;
        IData = null;
        GetComponentInChildren<SpriteRenderer>().sprite=null;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
}
