using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public Image Panel;
    private float MinRGB = 0; 
    private float MaxRGB = 255;
    private int GapImproveR = 1; 
    private int GapImproveG = 1; 
    private int GapImproveB = -1; 
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); 
    }
    public void ExitApplication()
    {
        Application.Quit(); 
    }
}
