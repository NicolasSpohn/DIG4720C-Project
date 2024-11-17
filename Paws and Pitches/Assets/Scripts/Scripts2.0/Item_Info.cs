using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Item_Info : MonoBehaviour
{

    public int Price;


    public void Buy(){
        if (StaticData.currency >= Price){
            StaticData.currency -= Price;
        }
    }



}
