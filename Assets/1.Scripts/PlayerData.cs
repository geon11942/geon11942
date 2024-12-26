using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public enum PlayerType
    {
        Human,
        Spider,
        Pig,
        Merman,
    }
    public PlayerType P_Type = PlayerType.Human;
    public float MaxHp = 150;
    public float MaxHunger = 150;
    public float MaxSan = 200;
    float Hp = 150;
    float Hunger = 150;
    float San = 200;
    public float AtkPer = 1f;

    Image HpBar;
    Image HungerBar;
    Image SanBar;
    void Start()
    {
        Hp=MaxHp;
        Hunger = MaxHunger;
        San = MaxSan;
        HpBar = GameObject.Find("HpBar").GetComponent<Image>();
        HungerBar = GameObject.Find("HungerBar").GetComponent<Image>();
        SanBar = GameObject.Find("SanBar").GetComponent<Image>();
        HpBar.fillAmount =Hp/MaxHp;
        HungerBar.fillAmount = Hunger / MaxHunger;
        SanBar.fillAmount = San / MaxSan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float SetHp
    {
        get {return Hp;}
        set
        {
            Debug.Log("변동 전 체력 :" + Hp);
            Hp += value;
            HpBar.fillAmount = Hp/MaxHp;
            Debug.Log("변동 후 체력 :" + Hp);
        }
    }
    public float SetHunger
    {
        get { return Hunger; }
        set
        {
            Debug.Log("변동 전 허기 :" + Hunger);
            Hunger += value;
            HungerBar.fillAmount = Hunger / MaxHunger;
            Debug.Log("변동 후 허기 :" + Hunger);
        }
    }
    public float SetSan
    {
        get { return San; }
        set
        {
            Debug.Log("변동 전 정신력 :" + San);
            San += value;
            SanBar.fillAmount = San / MaxSan;
            Debug.Log("변동 후 정신력 :" + San);
        }
    }
}
