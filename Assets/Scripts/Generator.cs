using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    float timer = 1;
    public float totalTime = 30; // Total time in seconds
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public Text timerText;
    public Text timeOutText;

    private float remainingTime;

    private void Start()
    {
        remainingTime = totalTime;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                float pos_x = Random.Range(-4.0f, 4.0f);
                InstantiateRandomPrefab(pos_x);
                timer = 0.7f;
            }
        }
        else
        {
            remainingTime = 0; // Ensure the timer doesn't go negative
            ShowTimeOutText();
        }
    }

    private void InstantiateRandomPrefab(float xPosition)
    {
        int chance = Random.Range(1, 101);

        GameObject prefabToInstantiate;

        if (chance <= 80)
        {
            int goodPrefabIndex = Random.Range(0, goodPrefabs.Length);
            prefabToInstantiate = goodPrefabs[goodPrefabIndex];
        }
        else
        {
            int badPrefabIndex = Random.Range(0, badPrefabs.Length);
            prefabToInstantiate = badPrefabs[badPrefabIndex];
        }

        Instantiate(prefabToInstantiate, new Vector3(xPosition, 6.0f, 0.1f), Quaternion.identity);
    }

    private void ShowTimeOutText()
    {
        if (timeOutText != null)
        {
            timeOutText.gameObject.SetActive(true);
            
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(remainingTime).ToString(); // Round up to the nearest second
        }
    }
}