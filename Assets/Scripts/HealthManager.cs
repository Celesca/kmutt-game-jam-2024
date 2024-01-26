using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour { 

    public Image healthBar;
    public float healthAmount = 100f;
    public float maxHealthBar = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(20);
        }
    }

    public void ReceiveObjectName(string objectName)
    {
        Debug.Log("Received object name: " + objectName);

        if (objectName.Equals("Milk"))
        {
            Heal(20);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / maxHealthBar;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0f, maxHealthBar);

        healthBar.fillAmount = healthAmount / maxHealthBar;
    }
}
