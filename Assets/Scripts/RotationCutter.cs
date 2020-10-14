using UnityEngine;

public class RotationCutter : MonoBehaviour
{
    [SerializeField] Vector3 _rotationSpeed = Vector3.zero;

    private void FixedUpdate()
    {
        transform.Rotate(_rotationSpeed);
    }
}
