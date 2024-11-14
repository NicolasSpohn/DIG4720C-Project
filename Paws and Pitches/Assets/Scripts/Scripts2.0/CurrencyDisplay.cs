using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{

    public string textName;

    void Start()
    {
        PlayerPrefs.SetInt("Currency", StaticData.currency);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(textName) + "";
    }
}
