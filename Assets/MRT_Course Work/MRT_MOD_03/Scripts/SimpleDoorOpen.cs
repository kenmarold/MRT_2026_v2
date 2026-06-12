using UnityEngine;

public class SimpleDoorOpen : MonoBehaviour
{
    public Transform doorObject;
    public Vector3 openOffset = new Vector3(0f, 2.5f, 0f);
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    private void Start()
    {
        if (doorObject != null)
        {
            closedPosition = doorObject.position;
            openPosition = closedPosition + openOffset;
        }
    }

    private void Update()
    {
        if (doorObject == null)
        {
            return;
        }

        Vector3 targetPosition = isOpen ? openPosition : closedPosition;
        doorObject.position = Vector3.Lerp(doorObject.position, targetPosition, Time.deltaTime * openSpeed);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}