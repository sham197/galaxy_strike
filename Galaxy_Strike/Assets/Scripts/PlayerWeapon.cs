using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 100;
    private bool _isFiring = false;
    private ParticleSystem.EmissionModule _emissionModule;
    private Vector2 _mousePosition;


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    private void OnFire(InputValue value)
    {
        _isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            _emissionModule = laser.GetComponent<ParticleSystem>().emission;
            _emissionModule.enabled = _isFiring;
        }
    }

    private void MoveCrosshair()
    {
        _mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = _mousePosition;
    }

    private void MoveTargetPoint()
    {
        var targetPointPosition = new Vector3(_mousePosition.x, _mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        foreach (var laser in lasers)
        {
            var fireDirection = targetPoint.position - this.transform.position;
            var rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}