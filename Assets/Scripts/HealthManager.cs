using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public Text healthText; // Add this line for the Text component
    public Image healthBar;
    public float healthAmount = 100f;
    public float maxHealthBar = 100f;
    public bool stopHealth = false;

    // Update is called once per frame
    void Update()
    {

        int itemCount = PlayerPrefs.GetInt("ItemCount");

        // Auto health decreasing
        if (!stopHealth)
        {
            TakeDamage(0.01f);
        }

        if (healthAmount <= 0 || itemCount >= 4)
        {
            StartCoroutine(TimeOutResult(2.0f));
        }

    }

    public void ReceiveObjectName(string objectName)
    {
        Debug.Log("Health Received object name: " + objectName);

        if (objectName.Length > 0)
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

    private IEnumerator TimeOutResult(float delay)
    {
        healthText.text = "MAMA!!! \r\nTHERE IS AN EGG\r\nRUN AWAY!!!";
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
