using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    Transform tr;
    private Text scoreboard;

    private void Start()
    {
        tr = GetComponent<Transform>();
        scoreboard = GameObject.Find("scoreboard").GetComponent<Text>();
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
            PlayerPrefs.SetInt("scoreboard", PlayerPrefs.GetInt("scoreboard") + 1);
            scoreboard.text = "Score : " + PlayerPrefs.GetInt("scoreboard").ToString();
            Destroy(this.gameObject);
        }
    }
}