using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour { 

    public Image healthBar;
    public float healthAmount = 100f;
    public float maxHealthBar = 100f;

    public bool stopHealth = false;

    // Update is called once per frame
    void Update()
    {

        // Auto health decreasing
        if (!stopHealth)
        {
            TakeDamage(0.01f);
        }

    }

    public void ReceiveObjectName(string objectName)
    {
        Debug.Log("Health Received object name: " + objectName);

        if (objectName == "Milk")
        {
            stopHealth = true;
            Heal(10);
            StartCoroutine(ResetHealth(2.0f));
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

    private IEnumerator ResetHealth(float delay)
    {
        yield return new WaitForSeconds(delay);
        stopHealth = false;
    }
}
