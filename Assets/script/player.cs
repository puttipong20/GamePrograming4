using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    private int score;
    public float speed;
    public Text scoreText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float move_H = Input.GetAxis("Horizontal");
        float move_V = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(move_H,0.0f,move_V);
        rb.AddForce(move*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item")) {
            other.gameObject.SetActive(false);
            score+=1;
            setScoreText();
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
    void setScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
        if (score == 4)
        {
            winText.text = "congrate ! ! !";
        }
    }
}
