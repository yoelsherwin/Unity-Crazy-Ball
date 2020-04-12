using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool mainCamera;

    void FixedUpdate ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostion;
        transform.LookAt(target);

        if(PlayerPrefs.GetInt("android") == 0 && mainCamera == true && PlayerPrefs.GetInt("multiplayer") == 0)
        {
            Debug.Log("rotate");
            transform.Rotate(0, 0, 180f);
        }
    }
}