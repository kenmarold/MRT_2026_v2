using UnityEngine;

public class LightSwitchPressAnimation : MonoBehaviour
{
    [Header("Switch Movement")]
    public float pressDistance = 0.03f;

    [Tooltip("Lower = faster/snappier. Higher = slower/smoother.")]
    public float smoothTime = 0.08f;

    [Tooltip("Use Z 1 or Z -1 depending on which direction pushes the switch into the wall.")]
    public Vector3 localPressDirection = Vector3.forward;

    private Vector3 originalLocalPosition;
    private Vector3 pressedLocalPosition;
    private Vector3 targetLocalPosition;
    private Vector3 velocity;

    private void Start()
    {
        originalLocalPosition = transform.localPosition;
        localPressDirection = localPressDirection.normalized;
        pressedLocalPosition = originalLocalPosition + localPressDirection * pressDistance;
        targetLocalPosition = originalLocalPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.SmoothDamp(
            transform.localPosition,
            targetLocalPosition,
            ref velocity,
            smoothTime
        );
    }

    public void PressDown()
    {
        targetLocalPosition = pressedLocalPosition;
    }

    public void ReleaseUp()
    {
        targetLocalPosition = originalLocalPosition;
    }
}