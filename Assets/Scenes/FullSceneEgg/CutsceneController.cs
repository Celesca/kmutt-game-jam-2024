using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    private VideoPlayer videoplayer;

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();

        videoplayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene());
 
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}