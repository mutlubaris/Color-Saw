using UnityEngine;

public class MoldMovement : MonoBehaviour
{
    [SerializeField] int _xPosMax = 12;
    [SerializeField] int _xPosMin = -12;
    [SerializeField] int _zPosMax = 30;
    [SerializeField] int _zPosMin = -22;
    
    private Vector3 _landPosition;
    private Vector3[] _route;

    private int[] _speed;
    private int _verticalSpeed = 5;
    private int _horizontalSpeed = 20;
    private int _routeIndex;

    private int _extraBlocks;
    private bool _movementStarted;

    public bool shouldNotMove;
    
    private void Start()    
    {
        _landPosition = FindObjectOfType<TargetArea>().transform.position;
        
        _route = new Vector3[3];
        _route[2] = _landPosition;
        _route[2].y += 1f;
        _route[1] = _route[2];
        _route[1].y += 1f;

        _speed = new int[3];
        _speed[0] = _verticalSpeed;
        _speed[1] = _horizontalSpeed;
        _speed[2] = _verticalSpeed;
    }
    
    void Update()
    {
        if (!shouldNotMove)
        {
            if (!_movementStarted)
            {
                if (Input.GetKeyDown("w"))
                    transform.position += Vector3.forward;
                if (Input.GetKeyDown("s"))
                    transform.position -= Vector3.forward;
                if (Input.GetKeyDown("d"))
                    transform.position += Vector3.right;
                if (Input.GetKeyDown("a"))
                    transform.position -= Vector3.right;

                Vector3 moldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moldPosition.x = Mathf.Clamp(moldPosition.x, _xPosMin, _xPosMax);
                moldPosition.z = Mathf.Clamp(moldPosition.z, _zPosMin, _zPosMax);
                transform.position = moldPosition;
            }

            _extraBlocks = FindObjectsOfType<ExtraBlock>().Length;
            if (_extraBlocks == 0)
            {
                if (!_movementStarted)
                {
                    _route[0] = transform.position;
                    _route[0].y += 3f;
                    _movementStarted = true;
                    var colliders = this.GetComponentsInChildren<Collider>();
                    foreach (var collider in colliders)
                    {
                        collider.enabled = false;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, _route[_routeIndex], _speed[_routeIndex] * Time.deltaTime);
                    if (transform.position == _route[_routeIndex])
                    {
                        if (_routeIndex < 2) _routeIndex++;
                        else
                        {
                            shouldNotMove = true;
                            FindObjectOfType<MoldSpawner>().SpawnMold();
                        }
                    }
                }
            }
        }
    }
}
