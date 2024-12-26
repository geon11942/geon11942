using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 4f;
    public float SpeedPer = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Position=transform.position;

        Position.x += Horizontal * Time.deltaTime * (MoveSpeed * SpeedPer);
        Position.z += Vertical * Time.deltaTime * (MoveSpeed * SpeedPer);

        transform.position = Position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Item")
        {
            if (gameObject.GetComponent<Inventory>() != null)
            {
                //if (other.GetComponent<ItemData>().TypeGS==ItemData.ItemType.Food)
                //{
                //    gameObject.GetComponent<PlayerData>().SetHp = other.GetComponent<ItemData>().F_HpGet;
                //    gameObject.GetComponent<PlayerData>().SetHunger = other.GetComponent<ItemData>().F_HungerGet;
                //    gameObject.GetComponent<PlayerData>().SetSan = other.GetComponent<ItemData>().F_SanGet;
                //}
                gameObject.GetComponent<Inventory>().Item=other.gameObject;
            }
            Destroy(other.gameObject);
        }
    }
}
