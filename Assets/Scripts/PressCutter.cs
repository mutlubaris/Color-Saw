using UnityEngine;

public class PressCutter : MonoBehaviour 
{
    [SerializeField] int _riseSpeed = 15;
    [SerializeField] int _fallSpeed = 5;
    [SerializeField] int _peakHeight = 5;
    
    Vector3 _startingPos;
    Vector3 _peakPos;
    bool _falling;

    private void Start() 
    {
        _startingPos = transform.position;
        _peakPos = transform.position;
        _peakPos.y += _peakHeight;
    }    

    private void FixedUpdate() 
    {
        if (!_falling) transform.position = Vector3.MoveTowards(transform.position, _peakPos, _riseSpeed * Time.deltaTime);
        if (transform.position == _peakPos) _falling = true;

        if (_falling) transform.position = Vector3.MoveTowards(transform.position, _startingPos, _fallSpeed * Time.deltaTime);
        if (transform.position == _startingPos) _falling = false;
    }
}