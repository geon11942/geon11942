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
    public float Hp = 150;
    public float Hunger = 150;
    public float San = 200;
    public float AtkPer = 1f;

    Image HpBar;
    Image HungerBar;
    Image SanBar;
    void Start()
    {
        Hp=100;
        Hunger = 100;
        San = 100;
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
            Debug.Log("���� �� ü�� :" + Hp);
            Hp += value;
            if(Hp > MaxHp )Hp = MaxHp;
            HpBar.fillAmount = Hp/MaxHp;
            Debug.Log("���� �� ü�� :" + Hp);
        }
    }
    public float SetHunger
    {
        get { return Hunger; }
        set
        {
            Debug.Log("���� �� ��� :" + Hunger);
            Hunger += value;
            if( Hunger > MaxHunger ) Hunger = MaxHunger;
            HungerBar.fillAmount = Hunger / MaxHunger;
            Debug.Log("���� �� ��� :" + Hunger);
        }
    }
    public float SetSan
    {
        get { return San; }
        set
        {
            Debug.Log("���� �� ���ŷ� :" + San);
            San += value;
            if( San > MaxSan ) San = MaxSan;
            SanBar.fillAmount = San / MaxSan;
            Debug.Log("���� �� ���ŷ� :" + San);
        }
    }
}
