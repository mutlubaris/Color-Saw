using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTracker : MonoBehaviour
{
    int _sceneIndex;
    int _levels;
    
    private void Start() 
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _levels = SceneManager.sceneCountInBuildSettings;
    }
    
    public IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        if (_sceneIndex != _levels - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
