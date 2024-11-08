using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public void Setup(int score)
    {
        PlayerPrefs.SetInt("SavedScore",score);
        gameObject.SetActive(true);
    }

}
