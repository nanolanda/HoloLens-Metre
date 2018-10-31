using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class HandRotate : MonoBehaviour, IManipulationHandler
{
    [Tooltip("Speed of static rotation when tapping game object.")]
    [SerializeField]
    float RotateSpeed = 25f;

    [Tooltip("Speed of interactive rotation via navigation gestures.")]
    [SerializeField]
    float RotationFactor = 20f;

    public char rotateAxis = ' ';

    Vector3 lastRotation;
    Vector3 scale;

    public void Start()
    {
        Debug.Log("Application rotation script started");

    }

    [SerializeField]
    bool rotatingEnabled = true;
    public void SetRotating(bool enabled)
    {
        rotatingEnabled = enabled;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        InputManager.Instance.PushModalInputHandler(gameObject);
        lastRotation = transform.rotation.eulerAngles;
        scale = transform.localScale;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (rotatingEnabled)
        {
            var rotation = new Vector3(eventData.CumulativeDelta.y * RotationFactor,
                eventData.CumulativeDelta.x * RotationFactor,
                eventData.CumulativeDelta.z * RotationFactor);

            Rotate(rotation);
        }
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
        lastRotation = transform.rotation.eulerAngles;
        transform.localScale = scale;
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    void Rotate(Vector3 rotation)
    {
        switch (rotateAxis)
        {
            case 'X':
                transform.rotation = Quaternion.Euler((lastRotation.x + rotation.x) * RotateSpeed, lastRotation.y,lastRotation.z);
                break;
            case 'Y':
                transform.rotation = Quaternion.Euler(lastRotation.x,( lastRotation.y - rotation.y)*RotateSpeed,lastRotation.z);
                break;
            case 'Z':
                transform.rotation = Quaternion.Euler(lastRotation.x, lastRotation.y, (lastRotation.z + rotation.z)*RotateSpeed);
                break;
            default:
                break;
        }
    }
}
