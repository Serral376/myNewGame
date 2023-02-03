using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BotAI : MonoBehaviour
{
    public bool Targeting;
    public Transform Target;
    public UnityEngine.AI.NavMeshAgent Agent;
    public RaycastHit hit_info;
    public float HP;
    public float Hunger;
    public float Stomina;
    public float IngriseRateOfHP;
    public float DegriseRateOfHP;
    public float IncrieseRateOfHunger;
    public float DegriseOfStomina;
    public float EndOfLife;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        

    }

    // Update is called once per frame
    void HeartBit ()
    {
        HungerController();
        StominaController();
        HPcontroller();
        //Debug.Log("end")
        Death();
    }
    void Death()
    {
       if (HP == 0)
       {
            Debug.Log("Билли Бонс умер");
            EndOfLife = 1;
       }
        
    }
    void HungerController()
    {
        Hunger += IncrieseRateOfHunger * Time.deltaTime;
        Hunger = Mathf.Clamp(Hunger, 0, 100);
    }
    void StominaController()
    {
        Stomina -= DegriseOfStomina * Time.deltaTime;
        Stomina = Mathf.Clamp(Stomina, 0, 100);

    }
    void HPcontroller()
    {
        if (Stomina == 0 || Hunger >= 50)
        {
            HP -= DegriseRateOfHP * Time.deltaTime;
        }
        else if (Stomina > 75 && Hunger <15 )
        {
            HP += IncrieseRateOfHunger * Time.deltaTime;
        }
        HP = Mathf.Clamp(HP, 0, 100);
    }
    void Update()
    {
        HeartBit();
        Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(R, out hit_info, 200);
        if (Input.GetMouseButton(1))
        {
            Agent.destination = hit_info.point;//���������� ��� distanation , ������� ����� ������ �� ���� ����� ����

        }

    }
}
