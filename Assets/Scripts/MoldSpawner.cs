using System.Collections.Generic;
using UnityEngine;

public class MoldSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _molds = null;

    int _moldIndex = 0;

    public int moldIndex { get { return _moldIndex; } }
    public int molds { get { return _molds.Count; } }

    private void Start() {
        SpawnMold();
    }
    
    public void SpawnMold() 
    {
        if (_moldIndex <= _molds.Count - 1)
        {
            Instantiate(_molds[_moldIndex], transform.position, Quaternion.identity);
            _moldIndex++;
        }
        else
        {
            StartCoroutine(FindObjectOfType<LevelTracker>().LoadNextScene());
        }
    }
}
