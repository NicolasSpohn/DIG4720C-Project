using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Point_Text : MonoBehaviour
{

    void Start(){
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")*0);
    }

    public string textName;

    void Update(){
        GetComponent<Text>().text = PlayerPrefs.GetInt(textName) + "";
    }
}