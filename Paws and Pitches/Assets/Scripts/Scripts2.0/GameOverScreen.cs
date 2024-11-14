using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public void Setup(int score)
    {
        int coins = 10;
        PlayerPrefs.SetInt("SavedScore",score);
        gameObject.SetActive(true);
        StaticData.currency += coins;
    }

}
