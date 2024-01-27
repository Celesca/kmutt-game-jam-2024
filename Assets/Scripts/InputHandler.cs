using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private HealthManager healthManager; // Reference to HealthManager script
    private KidHandler kidHandler; // Reference to KidHandler script

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

        if (healthManager != null)
        {
            healthManager.ReceiveObjectName(clickedObject.name);
        }

        if (kidHandler != null)
        {
            kidHandler.ReceiveObject(clickedObject);
        }
    }
}