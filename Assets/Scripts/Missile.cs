using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{
    private Text scoreText;
    public float speed = 10.0f;
    private float topBound = 5;
    private static int scores;
   

    // Start is called before the first frame update
    void Start()
    {
        scoreText = (Text)GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        scoreText.text = "Score: " + scores;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }


    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        scores += 5;
        Debug.Log(scores);
        scoreText.text = "Score: " + scores;
    }



    }
