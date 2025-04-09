using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float value;
    public AudioSource eheh;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            eheh.Play();
            transform.position = Vector3.one * 9999f;
            Destroy(gameObject, eheh.clip.length);
            
        }
    }

}