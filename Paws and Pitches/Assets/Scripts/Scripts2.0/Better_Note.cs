using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    // set angular drag and linear velocity to 0 on rigidbody before doing anything
    Rigidbody2D rb;
    public float speed;

    void Awake(){
        rb=GetComponent<Rigidbody2D>();
    }

    void Start(){
        rb.velocity=new Vector2(0,-speed);

    }

    void Update (){

    }

}