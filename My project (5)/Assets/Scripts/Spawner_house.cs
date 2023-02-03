using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_house : MonoBehaviour // публичный класс 
{
    public GameObject SelectedBulding;//обьект дял всех скриптов 
    public GameObject SeectedBlueprintHouse;// обьект для всех скриптов
    public GameObject BluePrintHouseObject;
    public LayerMask LayerForBuldings;
    // Start is called before the first frame update
    void Start()//
    {

    }

    // Update is called once per frame
    void Update()//
    {


    }
    public void SelectionOfHouse(GameObject H)//выбор обьекта gameobject и чертежа
    {
        SeectedBlueprintHouse = H;// waht it is
        SelectedBulding = H.GetComponent<blueprint_house>().House_in_nutshell;//выбор здания из компоненты
    }
    public bool IsSpaceAvaible(Vector3 pos, float Rotation)
    {
         return !Physics.CheckBox(pos,BluePrintHouseObject.GetComponent<BoxCollider>().size/2,Quaternion.Euler(0,Rotation,0),LayerForBuldings);
    
    }
    public void BuldingHouses(Vector3 bul, float bulding_rotation)//
    {
        if (IsSpaceAvaible(bul,bulding_rotation))
        {
            Instantiate(SelectedBulding, bul, Quaternion.Euler(0, bulding_rotation, 0));
        }
    }
    public void Blueprint_house_printing(Vector3 positionofBlue, float rotationofBlue)//получение значения позиции курсора + спавн черчежа
    {
        if (BluePrintHouseObject == null)// если чертеж  в игре равен 0
        {
            BluePrintHouseObject = Instantiate(SeectedBlueprintHouse,new Vector3(1000,1000,1000),Quaternion.identity);//

        }
        if (BluePrintHouseObject != null)// если чертеж в игре не равен 0
        {
            BluePrintHouseObject.transform.position = positionofBlue;//
            BluePrintHouseObject.transform.rotation = Quaternion.Euler(0,rotationofBlue,0);//
            if (IsSpaceAvaible(positionofBlue,rotationofBlue))
            {
                BluePrintHouseObject.GetComponent<MeshRenderer>().material.color = new Color32(0,255,0,128);
            }
            else
            {
                BluePrintHouseObject.GetComponent<MeshRenderer>().material.color = new Color32(255,0,0,128);

            }
        }
    }
}    
