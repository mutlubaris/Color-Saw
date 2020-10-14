using UnityEngine;

public class WarningArea : MonoBehaviour
{
    void Start()
    {  
        var cube = transform.parent.GetChild(0);
        Vector3 movementVector = Vector3.zero;
        
        transform.position = cube.position;
        GetComponent<BoxCollider>().size = cube.localScale;
        
        if (cube.TryGetComponent(out OscillationCutter oscillationcutter))
        {
            movementVector = oscillationcutter.movementVector; 
            GetComponent<BoxCollider>().size += movementVector;
            GetComponent<BoxCollider>().center += movementVector / 2;
        }        
    }
}
