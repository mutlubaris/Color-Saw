using UnityEngine;

public class OscillationCutter : MonoBehaviour 
{
    [SerializeField] Vector3 _movementVector = Vector3.zero;
    [SerializeField] float _period = 2f;

    public Vector3 movementVector { get { return _movementVector; } }

    float _movementFactor;
    Vector3 _startingPos;

    private void Start() {
        _startingPos = transform.position;
    }

    private void FixedUpdate() {
        if (_period <= Mathf.Epsilon) return;
        float cycles = Time.time / _period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = _movementFactor * _movementVector;
        transform.position = _startingPos + offset;
    }
}