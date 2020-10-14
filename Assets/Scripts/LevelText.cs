using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Text>().text = "Level " + SceneManager.GetActiveScene().buildIndex;  
    }
}
