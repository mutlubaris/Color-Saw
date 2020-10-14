using UnityEngine;

public class CubeUnit : MonoBehaviour
{
    [SerializeField] ParticleSystem _destructionEffect = null;
    
    Color _startingColor;
    
    private void Start() 
    {
        _startingColor = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Warning")
            ChangeColor();

        if (other.tag == "Cutter")
            DestroyBlock();
    }

    private void DestroyBlock()
    {
        var destructionEffect = Instantiate(_destructionEffect, transform.position, Quaternion.identity);
        destructionEffect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;

        if (TryGetComponent(out TargetBlock t))
        {
            FindObjectOfType<MoldMovement>().shouldNotMove = true;
            FindObjectOfType<LevelTracker>().transform.GetChild(0).gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Warning")
            RevertColor();
    }

    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = (_startingColor + Color.white) / 2;
    }

    private void RevertColor()
    {
        GetComponent<Renderer>().material.color = _startingColor;
    }
}