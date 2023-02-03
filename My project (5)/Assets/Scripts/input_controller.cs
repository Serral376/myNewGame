using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_controller : MonoBehaviour// ��������� ���� �������� ����� 
{
    public LayerMask BotLayer;
    public LayerMask GraundLayer;
    public bool InBuldingModeActive = true;// ��������� ���� �������� ���������� , ������� �������� 1
    public Spawner_house Builder;// ��������� ���� �������� ���������� �� ������� spawner house
    public float bulding_rotation;// ��������� ����� ����������� 
    public float speed_of_rotation; // ��������� ����� ���������� 
    // Start is called before the first frame update
    void Start()//
    {
        Builder = GetComponent<Spawner_house>();//��������� ���������� �� spawner house


    }
    
 

    // Update is called once per frame
    void Update()//
    {
        RaycastHit hit_info;// ���� ������ ���
        Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);// ��� �������� � ������

        if (InBuldingModeActive)//���� ����� �������������
        {
            
            bool hit = Physics.Raycast(R, out hit_info, 200,GraundLayer);// ���������� ���� ���� ��� ������ ����� ����� �������� ����
            if (hit)
            {
                Builder.Blueprint_house_printing(hit_info.point,bulding_rotation);
                if (Input.GetMouseButtonDown(0))// ���� ������� ��� �������������
                {

                    Builder.BuldingHouses(hit_info.point, bulding_rotation);// �������������� ����

                }
            }
            
            if (Input.GetKey(KeyCode.E)) // ���� ������� ������ e
            {
                bulding_rotation += 1 * Time.deltaTime * speed_of_rotation; // ��������� �������

            }
            if (Input.GetKey(KeyCode.G)) // ���� ������� ������ g
            {
                bulding_rotation -= 1 * Time.deltaTime * speed_of_rotation; // ��������� �������

            }

        
        }
        else 
        {
         bool Otschet = Physics.Raycast(R,out hit_info,404,BotLayer);
            if (Otschet)//������ � ���� ��� ���
            {
                hit_info.collider.GetComponent<BotAI>().Targeting = true;
                GetComponent<botManager>().LastSelectedBot = hit_info.collider.GetComponent<BotAI>();


            }
        }
        




    } //���������
    
}

