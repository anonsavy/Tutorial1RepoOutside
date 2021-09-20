using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Text countText; 
    public Text winText;
    public Text livesText;

    public GameObject Player; 

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count; 
    private int lives; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText (); 
        winText.text = "";
        lives = 3;
        SetCountText ();
        winText.text = "";
        
        
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText (); 
        }
        if (other.gameObject.CompareTag("Danger"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText (); 
        }
    }

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString (); 
        if (count == 46)
        {
            winText.text = "Victory! -Samuel Vera"; 
        }

        if (count == 28)
        {
            transform.position = new Vector3(0.0f, 60.5f, 0.0f); 
        }

        livesText.text = "Life: " + lives.ToString (); 
        if (lives == 0)
        {
            winText.text = "Game Over"; 
           // Player.gameObject.SetActive(false); 
         //   else
           // Player.gameObject.SetActive(true); 
            
        }

        if (lives == 0)
        {
            Player.gameObject.SetActive(false); 
        }
        else
        {
             Player.gameObject.SetActive(true); 
        }
    }


}
