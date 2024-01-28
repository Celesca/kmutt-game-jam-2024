using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{

    private Health healthScript;
    Transform tr;
    private Text scoreboard;
    private AudioSource audioSource; // Add this line for AudioSource

    private void Start()
    {

        tr = GetComponent<Transform>();
        scoreboard = GameObject.Find("scoreboard").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>(); // Add this line to get AudioSource component
        audioSource.volume = 1.0f;
        audioSource.spatialBlend = 0.0f;

        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("scoreboard", PlayerPrefs.GetInt("scoreboard") - 5);
            healthScript.health -= 1;


            scoreboard.text = "Score : " + PlayerPrefs.GetInt("scoreboard").ToString();
            audioSource.Play();
            Destroy(this.gameObject);
        }
    }

    private void PlayExplosionSound()
    {
        Debug.Log("Play explosion sound");
        audioSource.Play(); // Play the explosion sound
    }
}