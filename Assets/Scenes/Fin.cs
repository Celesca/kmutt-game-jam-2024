using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class Fin : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // Adjust the duration of the fade-out

    private VideoPlayer videoplayer;
    private Image fadeImage;

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
        fadeImage = CreateFadeImage();

        videoplayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(FadeOutAndLoadNextScene());
    }

    private IEnumerator FadeOutAndLoadNextScene()
    {
        float timer = 0f;
        Color originalColor = fadeImage.color;

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeOutDuration);
            fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // Load the next scene
        SceneManager.LoadScene(0);
    }

    private Image CreateFadeImage()
    {
        GameObject canvasObject = new GameObject("FadeCanvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObject.AddComponent<CanvasScaler>();
        canvasObject.AddComponent<GraphicRaycaster>();

        GameObject imageObject = new GameObject("FadeImage");
        Image image = imageObject.AddComponent<Image>();
        image.rectTransform.SetParent(canvasObject.transform, false);
        image.color = Color.clear; // Set the initial color to clear (fully transparent)
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

        return image;
    }
}