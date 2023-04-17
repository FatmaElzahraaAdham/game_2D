using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text txt_points;
    int points = 0;
    public GameObject gameover_panel;
    public AudioClip jump;
    public AudioClip lose;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8);
            GetComponent<Animator>().Play("fly", 0, 0);

            GetComponent<AudioSource>().PlayOneShot(jump);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            Debug.Log("game over");
            Time.timeScale = 0;
            GetComponent<AudioSource>().PlayOneShot(lose);
            gameover_panel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "point_gain")
        {
            Debug.Log("+1 point");
            points++;
            txt_points.text = points.ToString();

        }
    }
}
