using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{

    float horizontalMove = 0;
    float verticalMove = 0;
    public float runSpeedHorizontal = 3;
    public float runSpeedVertical = 3;
    public float runSpeed = 10;
    Rigidbody2D rigidbody2D;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        verticalMove = joystick.Vertical * runSpeedVertical;
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        if (General.GetTimer() > 0) 
        { 
            transform.position += new Vector3(horizontalMove,verticalMove,0)*Time.deltaTime*runSpeed;
        }
        
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Laberinto")
        {
            transform.position = new Vector3(0.3f, -3.5f, 0.0f);
        }
        else if (other.gameObject.tag == "puerta")
        {
            General.SetWin(true);
        }

    }

}
