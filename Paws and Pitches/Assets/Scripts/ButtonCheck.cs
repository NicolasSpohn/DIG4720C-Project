using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonCheck : MonoBehaviour
{
    public int points = 0;

    public TextMeshProUGUI pointText;
    public AudioClip audGood;
    public AudioClip audBad;
    public Color wantedColor;

    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ButtonPressed());
    }

    void Update()
    {
        pointText.text = points.ToString("0");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.touchCount > 0 && other.gameObject.tag == "Note") 
        {
            //Touch touch = Input.GetTouch(0);
            //Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);

            //if (touch.phase == TouchPhase.Began)
            //Instantiate(box , touchPos, Quaternion.identity);

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audGood);

            m_SpriteRenderer.color = wantedColor;

            points += 10;
        }

        else
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audBad);
        }
    }
    IEnumerator ButtonPressed()
    {
        yield return new WaitForSeconds(0.2f);
        m_SpriteRenderer.color = Color.white;
    }

}
