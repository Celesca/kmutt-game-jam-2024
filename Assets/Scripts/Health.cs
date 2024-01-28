using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Animator anim;
    private Generator generatorScript;
    public int health;
    public int numOfHearts;
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Text gameOverText;

    public void Start()
    {
        anim = GetComponent<Animator>();
        generatorScript = GameObject.FindObjectOfType<Generator>();
        if (generatorScript == null)
        {
            Debug.LogError("Generator script not found!");
        }
    }


    public void Update()
    {
        if (health == 2)
        {
            anim.SetBool("Damage1", true);
        }
        else if (health == 1)
        {
            anim.SetBool("Damage2", true);
        }
        else if (health == 0)
        {
            anim.SetBool("Damage3", true);
        }

        if (health <= 0 && generatorScript != null)
        {
            generatorScript.StopTimer();
            //gameOverText.gameObject.SetActive(true);
        }



        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
