using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_house : MonoBehaviour
{
    public GameObject SelectedBulding;//
    public GameObject SeectedBlueprintHouse;
    // Start is called before the first frame update
    void Start()//
    {

    }

    // Update is called once per frame
    void Update()//
    {


    }
    public void SelectionOfHouse(GameObject H)// waht it is
    {
        SeectedBlueprintHouse = H;// waht it is
        SelectedBulding = H.GetComponent<blueprint_house>().House_in_nutshell;
    }
    public void BuldingHouses(Vector3 bul, float bulding_rotation)//
    {
        Instantiate(SelectedBulding, bul, Quaternion.Euler(0, bulding_rotation, 0));//


    }
    public void Blueprint_house_printing()//получение значения позиции курсора + спавн черчежа
    {
        
    }
}    
