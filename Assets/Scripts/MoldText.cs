using UnityEngine;
using UnityEngine.UI;

public class MoldText : MonoBehaviour
{
    MoldSpawner _moldSpawner;

    private void Start() 
    {
        _moldSpawner = FindObjectOfType<MoldSpawner>();
    }
    
    private void Update() 
    {
        GetComponent<Text>().text = _moldSpawner.moldIndex.ToString() + " / " + _moldSpawner.molds.ToString();
    }
}
