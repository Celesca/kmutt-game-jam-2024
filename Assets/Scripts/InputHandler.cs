using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private HealthManager healthManager; // Reference to HealthManager script
    private KidHandler kidHandler; // Reference to KidHandler script
    private bool stopClick = false;

    private void Awake()
    {
        _mainCamera = Camera.main;
        healthManager = FindObjectOfType<HealthManager>();
        kidHandler = FindObjectOfType<KidHandler>(); // Find the KidHandler script in the scene
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        GameObject clickedObject = rayHit.collider.gameObject;

        if (!stopClick)
        {

            if (healthManager != null)
            {
                healthManager.ReceiveObjectName(clickedObject.name);
                StartCoroutine(preventClick(2.0f));
            }

            if (kidHandler != null)
            {
                kidHandler.ReceiveObject(clickedObject);
                StartCoroutine(preventClick(2.0f));
            }

        }
    }

    private IEnumerator preventClick(float delay)
    {
        stopClick = true;
        yield return new WaitForSeconds(delay);
        stopClick = false;
    }
}