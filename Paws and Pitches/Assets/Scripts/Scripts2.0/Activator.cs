using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{

    SpriteRenderer sr;
    public KeyCode key;
    bool active =false;
    GameObject note,gm;
    Color old;
    public bool createMode;
    public GameObject n;
    public AudioClip audGood;

    void Awake(){
        sr=GetComponent<SpriteRenderer>();
    }

    void Start(){
        gm=GameObject.Find("GameManager");
        old=sr.color;
    }

    void Update(){
        if(createMode){
            if(Input.GetKeyDown(key))
               Instantiate(n,transform.position,Quaternion.identity);
            
        }  

        else{

            // go back and replace this with an active touch thing
            // checking if one taps a certain area of the screen
            if (Input.touchCount > 0){
                Touch t = Input.GetTouch(0);

                Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                {
                    StartCoroutine(Pressed());
                }
            }

            if(Input.touchCount > 0 && active){
                Touch t = Input.GetTouch(0);

                Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos)){
                    Destroy(note);
                    //gm.GetComponent<GameManager>().AddStreak();
                    AddScore();
                    active=false;
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.PlayOneShot(audGood);
                }

            }
            //else if(Input.GetKeyDown(key)&&!active){
                //gm.GetComponent<GameManager>().ResetStreak();
            //}
            
        }

    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag=="WinNote")
            gm.GetComponent<GameManager>().Win();

        if (col.gameObject.tag=="Note"){

            note=col.gameObject;
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        active = false;
        //gm.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore(){
        // add script to text you want to add this to, then add "score" to the name
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);

    }

    IEnumerator Pressed(){
        sr.color=new Color(0,0,0);
        yield return new WaitForSeconds(0.2f);
        sr.color=old;

    }
}