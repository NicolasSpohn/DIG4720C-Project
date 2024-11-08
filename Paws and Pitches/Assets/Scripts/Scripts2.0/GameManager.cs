using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    //int multiplier = 1;
    //int streak = 0;


    public GameOverScreen GameOverScreen;
    public AudioClip audBad;

    void Start()
    {
        PlayerPrefs.SetInt("Score",0);
    }

    public void Win()
    {
        GameOverScreen.Setup(PlayerPrefs.GetInt("Score"));
    }

    void Update(){

    }

    void OnTriggerEnter2D(Collider2D col){
        Destroy(col.gameObject);
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audBad);

    }

    // public int GetScore(){
    //    return 100
    // }
}