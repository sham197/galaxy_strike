using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 30f;
    [SerializeField] private float yClampRange = 30f;
    [SerializeField] private float controlRollFactor = 20f;
    [SerializeField] private float controlPitchFactor = 20f;
    [SerializeField] private float rotationSpeed = 10f;
    
    private Vector2 _movement;

    void Update()
    {
        UpdatePlayerPosition();
        ProcessRotation();
    }

    private void UpdatePlayerPosition()
    {
        var yOffset = _movement.y * (controlSpeed * Time.deltaTime);
        var xOffset = _movement.x * (controlSpeed * Time.deltaTime);
        
        var rawXPos = transform.localPosition.x + xOffset;
        var rawYPos = transform.localPosition.y + yOffset;
        
        var clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        var clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    
    private void ProcessRotation()
    {
        var pitch = -controlPitchFactor * _movement.y * rotationSpeed;
        var roll = -controlRollFactor * _movement.x * rotationSpeed;
        
        var targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime);
    }
    
    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}