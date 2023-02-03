using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_controller : MonoBehaviour// доступный всем скриптам класс 
{
    public LayerMask BotLayer;
    public LayerMask GraundLayer;
    public bool InBuldingModeActive = true;// доступная всем скриптам переменная , имеющая значение 1
    public Spawner_house Builder;// доступная всем скриптам переменная из скрипта spawner house
    public float bulding_rotation;// публичная флоат перременная 
    public float speed_of_rotation; // публичная флоат переменная 
    // Start is called before the first frame update
    void Start()//
    {
        Builder = GetComponent<Spawner_house>();//получение компоненты из spawner house


    }
    
 

    // Update is called once per frame
    void Update()//
    {
        RaycastHit hit_info;// куда падает луч
        Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);// луч привязан к камере

        if (InBuldingModeActive)//если режим староительсва
        {
            
            bool hit = Physics.Raycast(R, out hit_info, 200,GraundLayer);// переменная типа ложь или истина равна месту падаения луча
            if (hit)
            {
                Builder.Blueprint_house_printing(hit_info.point,bulding_rotation);
                if (Input.GetMouseButtonDown(0))// если активен мод строительства
                {

                    Builder.BuldingHouses(hit_info.point, bulding_rotation);// строительствао дома

                }
            }
            
            if (Input.GetKey(KeyCode.E)) // если прожата кнопка e
            {
                bulding_rotation += 1 * Time.deltaTime * speed_of_rotation; // изменение ротации

            }
            if (Input.GetKey(KeyCode.G)) // если прожата кнопка g
            {
                bulding_rotation -= 1 * Time.deltaTime * speed_of_rotation; // изменение ротации

            }

        
        }
        else 
        {
         bool Otschet = Physics.Raycast(R,out hit_info,404,BotLayer);
            if (Otschet)//попали в бота или нет
            {
                hit_info.collider.GetComponent<BotAI>().Targeting = true;
                GetComponent<botManager>().LastSelectedBot = hit_info.collider.GetComponent<BotAI>();


            }
        }
        




    } //интерфейс
    
}

