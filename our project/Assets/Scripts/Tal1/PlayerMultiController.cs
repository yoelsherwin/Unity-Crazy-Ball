using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMultiController : MonoBehaviour {

    public float speed;
    private bool onGround;
    private Rigidbody rb;
    public GameObject joysticks2;
    public Joystick joystick2;
    public JoyButton joyButton2;
    protected bool jump;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        onGround = false;
        if(PlayerPrefs.GetInt("android") == 0)
        {
            joysticks2.SetActive(true);
            //joystick = joysticks.gameObject.transform.Find("Fixed Joystick");
            //joyButton = joysticks.gameObject.transform.Find("Fixed_joyButton");
        }
    }

    void FixedUpdate ()
    {
        if(PlayerPrefs.GetInt("android") == 1)
        {
            float moveHorizontal = Input.GetAxis ("Horizontal2");
            float moveVertical = Input.GetAxis ("Vertical2");
            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            rb.AddForce (movement * speed);
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Jump");
                if(onGround == true)
                {
                    onGround = false;
                    rb.AddForce(new Vector3(0,speed,0), ForceMode.Impulse);
                }
            }
        }
        else
        {
            Vector3 movement = new Vector3 (joystick2.Horizontal, 0.0f, joystick2.Vertical);

            rb.AddForce (movement * speed);
            
            if(joyButton2.Pressed)
            {
                if(onGround == true)
                {
                    onGround = false;
                    rb.velocity += Vector3.up * speed;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "Ground" || tag == "Elevator")
        {
            onGround = true;
        }
    }
}