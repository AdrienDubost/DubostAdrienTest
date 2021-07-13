using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIMANAGER : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnRetryButton()
    {
        GameManager.Instance.OnRetryButton(); 
    }
    public void OnNextLevelButton()
    {
        GameManager.Instance.OnNextLevelButton(); 
    }
    public void OnReturnHome()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
