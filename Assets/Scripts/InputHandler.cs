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
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        string objectName = rayHit.collider.gameObject.name;

        Debug.Log(objectName);

        if (healthManager != null)
        {
            healthManager.ReceiveObjectName(objectName);
            kidHandler.ReceiveObjectName(objectName);
        }
    }   
}