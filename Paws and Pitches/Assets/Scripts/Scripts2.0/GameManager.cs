using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

    //int multiplier = 1;
    //int streak = 0;

    public AudioClip audBad;
    
    void Start(){

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