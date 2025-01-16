using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 4f;
    public float SpeedPer = 1f;
    public float radius = 2f;
    public LayerMask layer;
    public Collider[] colliders;
    public Collider short_enemy;
    Camera cam;
    bool MouseMove=false;
    bool SpaceMove = false;
    bool DropMove = false;
    Vector3 MousePos;
    float SpaceDelay = 0.5f;
    GameObject MouseSys;
    GameObject InvenUI;
    void Start()
    {
        MouseSys = GameObject.Find("MouseSystem");
        InvenUI = GameObject.Find("Inventory");
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Position=transform.position;

        Position.x += Horizontal * Time.deltaTime * (MoveSpeed * SpeedPer);
        Position.y += Vertical * Time.deltaTime * (MoveSpeed * SpeedPer);

        transform.position = Position;
        if(Input.GetMouseButton(0))
        {
            SpaceDelay = 0.5f;
            MouseMove = true;
            SpaceMove = false;
            MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
            Vector3 InvenPos = Camera.main.ScreenToWorldPoint(new Vector3(InvenUI.transform.position.x,
                InvenUI.transform.position.y, -Camera.main.transform.position.z));
            if (MousePos.x> InvenPos.x-9.3f && MousePos.x < InvenPos.x + 9.3f && MousePos.y > InvenPos.y && MousePos.y < InvenPos.y + 1f)
            {
                MouseMove= false;
            }
            else
            {
                if (MouseSys.GetComponent<MouseItem>().CheckNeedItem())
                {
                    DropMove = true;
                    MouseMove = false;
                }
                else
                {
                    DropMove = false;
                    colliders = Physics.OverlapSphere(MousePos, 0.15f, layer);

                    if (colliders.Length > 0)
                    {
                        float short_distance = Vector3.Distance(MousePos, colliders[0].transform.position);
                        short_enemy = colliders[0];
                        foreach (Collider col in colliders)
                        {
                            float short_distance2 = Vector3.Distance(MousePos, col.transform.position);
                            if (short_distance > short_distance2)
                            {
                                short_distance = short_distance2;
                                short_enemy = col;
                            }
                        }
                        MouseMove = false;
                        SpaceMove = true;
                    }
                }
            }
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            MouseMove= false;
            SpaceMove=false;
            DropMove = false;
            SpaceDelay = 0.5f;
        }
        if (DropMove)
        {
            float dist = Vector2.Distance(transform.position, MousePos);
            if (dist > 0.1f)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, MousePos, MoveSpeed * Time.deltaTime);
            }
            else
            {
                DropMove = false;
                GameObject ItemObj = Instantiate(Resources.Load("Item") as GameObject);
                ItemObj.transform.position = transform.position;
                ItemObj.gameObject.GetComponent<ItemData>().DataSet(MouseSys.GetComponent<MouseItem>().ItemGS);
                MouseSys.GetComponent<MouseItem>().ItemEmpty();
            }
        }
        if (MouseMove)
        {
            float dist = Vector2.Distance(transform.position, MousePos);
            if (dist > 0.1f)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, MousePos, MoveSpeed * Time.deltaTime);
            }
            else
            {
                MouseMove=false;
            }
        }
        if(Input.GetKey(KeyCode.Space))
        {
            SpaceMove = true;
            MouseMove = false;
            DropMove = false;
            colliders = Physics.OverlapSphere(transform.position, radius, layer);

            if (colliders.Length > 0)
            {
                float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
                if (colliders[0].tag== "Object")
                {
                    if (colliders[0].GetComponent<Environment>() != null)
                    {
                        if(colliders[0].GetComponent<Environment>().CheckAction())
                        {
                            short_enemy = colliders[0];
                        }
                        else
                        {
                            short_enemy=null;
                        }
                    }
                    else
                    {
                        short_enemy = null;
                    }
                }
                else
                {
                    short_enemy = colliders[0];
                }
                foreach (Collider col in colliders)
                {
                    if(col.tag == "Object")
                    {
                        if (col.GetComponent<Environment>() == null)
                        {
                            continue;
                        }
                        if (!col.GetComponent<Environment>().CheckAction())
                        {
                            continue;
                        }
                    }
                    float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                    if (short_distance > short_distance2)
                    {
                        short_distance = short_distance2;
                        short_enemy = col;
                    }
                }
            }
            else if (colliders.Length == 0)
            {
                short_enemy = null;
            }
        }
        if(SpaceMove)
        {
            if (short_enemy != null)
            {
                float dist = Vector2.Distance(transform.position, short_enemy.transform.position);
                if (dist > 0.3f)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, short_enemy.transform.position, MoveSpeed * Time.deltaTime);
                }
                else
                {
                    if (short_enemy.gameObject.tag == "Item")
                    {
                        if (SpaceDelay > 0)
                        {
                            SpaceDelay -= Time.deltaTime*4f;
                        }
                        else
                        {
                            SpaceDelay = 0.5f;
                            SpaceMove = false;
                            Debug.Log("æ∆¿Ã≈€ »πµÊ");
                            if (gameObject.GetComponent<Inventory>() != null)
                            {
                                gameObject.GetComponent<Inventory>().ItemGS = short_enemy.gameObject;
                            }
                            Destroy(short_enemy.gameObject);
                        }
                    }
                    else if(short_enemy.gameObject.tag == "Object")
                    {
                        if (short_enemy.GetComponent<Environment>() != null)
                        {
                            if (short_enemy.GetComponent<Environment>().CheckAction())
                            {
                                if (SpaceDelay > 0)
                                {
                                    SpaceDelay -= Time.deltaTime * short_enemy.GetComponent<Environment>().DelayPerGet;
                                }
                                else
                                {
                                    SpaceDelay = 0.5f;
                                    SpaceMove = false;
                                    short_enemy.GetComponent<Environment>().ObjAction();
                                }
                            }
                            else
                            {
                                SpaceMove = false;
                            }
                        }
                        else
                        {
                            SpaceMove = false;
                        }
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
