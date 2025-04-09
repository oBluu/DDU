using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public AudioSource pointeffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pointeffect.Play();
            gameObject.SetActive(false); // Deaktiver mønten i stedet for at slette den
            CoinManager.instance.IncreaseCoins(value);
        }
    }
}
