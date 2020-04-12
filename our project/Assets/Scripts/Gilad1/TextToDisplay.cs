using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToDisplay : MonoBehaviour
{
    void Awake()
    {
        #if UNITY_ANDROID
            transform.Find("Text2").gameObject.SetActive(true);
        #else
            transform.Find("Text").gameObject.SetActive(true);
        #endif
    }
}
