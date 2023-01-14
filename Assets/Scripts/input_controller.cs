using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_controller : MonoBehaviour// доступный всем скриптам класс 
{

    public bool InBuldingModeActive = true;// доступная всем скриптам переменная , имеющая значение 1
    public Spawner_house Builder;// доступная всем скриптам переменная из скрипта spawner house
    public float bulding_rotation;
    public float speed_of_rotation;
    // Start is called before the first frame update
    void Start()//
    {
        Builder = GetComponent<Spawner_house>();//


    }
    
 

    // Update is called once per frame
    void Update()//
    {
        
        if (Input.GetMouseButtonDown(0))//
        {
            if (InBuldingModeActive)//
            {
                RaycastHit hit_info;//
                Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);//
                bool hit = Physics.Raycast(R, out hit_info, 200);//
                Builder.BuldingHouses(hit_info.point,bulding_rotation);//
                
            }            
        }
        if (Input.GetKey(KeyCode.E))
        {
            bulding_rotation += 1 * Time.deltaTime*speed_of_rotation;

        }
        if (Input.GetKey(KeyCode.G))
        {
            bulding_rotation -= 1 * Time.deltaTime*speed_of_rotation;

        }





    }
    
}

