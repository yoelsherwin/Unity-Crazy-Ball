using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private bool onGround;
    private Rigidbody rb;
    public GameObject joysticks;
    public Joystick joystick;
    public JoyButton joyButton;
    protected bool jump;
    private Vector3 movement;

    void Awake()
    {
        #if UNITY_ANDROID
            PlayerPrefs.SetInt("android", 0);
        #else
            PlayerPrefs.SetInt("android", 1);
        #endif
    }
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        onGround = false;
        if(PlayerPrefs.GetInt("android") == 0)
        {
            joysticks.SetActive(true);
            //joystick = joysticks.gameObject.transform.Find("Fixed Joystick");
            //joyButton = joysticks.gameObject.transform.Find("Fixed_joyButton");
        }
    }

    void FixedUpdate ()
    {
        if(PlayerPrefs.GetInt("android") == 1)
        {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

            rb.AddForce (movement * speed);

            if(Input.GetKeyDown(KeyCode.Space))
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
            if(PlayerPrefs.GetInt("multiplayer") == 0)
            {
                movement = new Vector3 (-1 * joystick.Horizontal, 0.0f, -1 * joystick.Vertical);
            }
            else
            {
                movement = new Vector3 (joystick.Horizontal, 0.0f, joystick.Vertical);
            }

            rb.AddForce (movement * speed);
            
            if(joyButton.Pressed)
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