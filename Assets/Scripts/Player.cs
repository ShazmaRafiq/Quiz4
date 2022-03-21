using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 10.0f;
    private float yRange = 2.0f;
    public GameObject missilePrefab;
    public Text livesText,gameover;
    public int livescount = 1;
   

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Life :" + livescount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.down * verticalInput * Time.deltaTime * speed);



        //keep the player in bounds
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
           
        }
        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
           
        }
        if (transform.position.y <= -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
           
        }
        if (transform.position.y >= yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            
        }    

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //  Launch a missile from the player
                Instantiate(missilePrefab, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), missilePrefab.transform.rotation);

            }
            
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet")){
            Destroy(gameObject);
            Time.timeScale = 0;
            gameover.text = "Game Over";
        }

    }

}
