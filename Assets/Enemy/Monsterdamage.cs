using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterdamage : MonoBehaviour
{
    public int damage;
    public Playhealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            playerHealth.TakeDamage(damage);
        }
    }
}
