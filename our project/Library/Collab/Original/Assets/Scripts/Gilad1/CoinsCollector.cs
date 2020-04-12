using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    public int worth;
    private AudioSource coinCollectAudio;
    public GameObject floatingText;

    void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Player") 
        {
            collision.GetComponent<InformationCenter>().score += worth;
            Debug.Log(collision.GetComponent<InformationCenter>().score);
            if(floatingText != null)
            {
                ShowFloatingText();
            }
            //coinCollectAudio = GetComponent<AudioSource>();
            //coinCollectAudio.Play();
            if(PlayerPrefs.GetInt("volume") == 0)
            {
                FindObjectOfType<AudioManager>().Play("CoinsCollect");
            }
            Destroy(gameObject);
            
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(floatingText, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        go.GetComponent<TextMesh>().text = "+" + worth.ToString();
    }
}
