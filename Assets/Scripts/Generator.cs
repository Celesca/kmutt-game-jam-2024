using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public float timer = 1;
    public float totalTime = 30; // Total time in seconds
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public Text timerText;
    public Text timeOutText;
    public Text LoseText;

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

            Invoke("LoadNextScene", 2f);
        }

    }

    private void LoadNextScene()
    {
        // Replace "YourNextSceneName" with the name of the scene you want to load
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LoadAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(remainingTime).ToString(); // Round up to the nearest second
        }
    }

    private void ShowGameOver()
    {
        if (timeOutText != null)
        {
            LoseText.gameObject.SetActive(true);

            Invoke("LoadAgain", 2f);
        }
    }

    public void StopTimer()
    {
        remainingTime = 0;
        timer = 0;
        ShowGameOver();
    }
}