using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BotTest : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;
    public RaycastHit hit_info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(R, out hit_info, 200);
        if (Input.GetMouseButton(1))
        {
            Agent.destination = hit_info.point;//координаты это distanation , сделать ботов идущих по зову клика мыши

        }
        
        




    }
}
