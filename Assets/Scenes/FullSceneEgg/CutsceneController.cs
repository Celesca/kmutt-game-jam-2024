using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // Adjust the duration of the fade-in

    private VideoPlayer videoplayer;
    private Image fadeImage;

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
        CreateFadeImage(); // Create fade image

        // Play the video when the fade-in is complete
        StartCoroutine(PlayVideoAfterFadeIn());
    }

    private IEnumerator PlayVideoAfterFadeIn()
    {
        yield return StartCoroutine(FadeIn());

        // Start playing the video after fade-in is complete
        videoplayer.Play();
        videoplayer.loopPointReached += OnVideoEnd;
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color originalColor = fadeImage.color;

        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeInDuration);
            fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    private void CreateFadeImage()
    {
        GameObject canvasObject = new GameObject("FadeCanvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObject.AddComponent<CanvasScaler>();
        canvasObject.AddComponent<GraphicRaycaster>();

        GameObject imageObject = new GameObject("FadeImage");
        fadeImage = imageObject.AddComponent<Image>();
        fadeImage.rectTransform.SetParent(canvasObject.transform, false);
        fadeImage.color = Color.black; // Adjust the color if needed
        fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        Debug.Log("Load Next Scene");
        yield return new WaitForSeconds(1);
        Debug.Log("Load Next Scene");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}