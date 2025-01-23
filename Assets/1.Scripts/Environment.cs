using UnityEngine;


[CreateAssetMenu(fileName = "Environment Data", menuName = "Scriptable Object/Environment Data", order = int.MaxValue)]
public class EnvironmentData : ScriptableObject
{
    public bool Action = false;
    public bool Volatility = false;
    public bool RandomDrop = false;
    public int PowerHp = 5;
    public int Power_Axe = -1;
    public int Power_PickAxe = -1;
    public float RegenTime = 8f;
    public int Obj_ID = -1;
    public float DelayPer = 1f;
    public ItemDataTable[] itemDatas;
}

public class Environment : MonoBehaviour
{
    public Sprite OnSprite;
    public Sprite OffSprite;
    public EnvironmentData EData;
    public GameObject SpriteChild;
    GameObject Player;
    void Start()
    {
        if (SpriteChild == null)
        {
            SpriteChild = transform.GetChild(0).gameObject;
        }
        Player = GameObject.Find("Player");
        switch (EData.Obj_ID) 
        {
            case 1:
                EData.Action = true;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ObjAction()
    {
        switch(EData.Obj_ID)
        {
            case 1:
                GameObject ItemObj = Instantiate(Resources.Load("Item") as GameObject);
                ItemObj.transform.position = transform.position;
                ItemObj.gameObject.GetComponent<ItemData>().DataSet(EData.itemDatas[0]);
                if (Player.gameObject.GetComponent<Inventory>() != null)
                {
                    Player.gameObject.GetComponent<Inventory>().ItemGS = ItemObj.gameObject;
                }
                Destroy(ItemObj.gameObject);
                SpriteChild.GetComponent<SpriteRenderer>().sprite = OffSprite;
                EData.Action = false;
                break;
            default:
                break;
        }
    }
    public bool CheckAction()
    {
        return EData.Action;
    }
    public int NeedAxePower
    {
        get { return EData.Power_Axe; }
    }
    public int NeedPickAxePower
    {
        get { return EData.Power_PickAxe; }
    }
    public float DelayPerGet
    {
        get { return EData.DelayPer; }
    }
}
