using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LoseTime;
    public Material[] Skyboxes;
    public GameObject FinishCube;
    public static GameManager Instance;
    public bool Win;
    private float WinTime = 2f;
    public GameObject EndLevelUI; 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(Instance); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, Skyboxes.Length - 1);
        RenderSettings.skybox = Skyboxes[x]; 
    }

    // Update is called once per frame
    void Update()
    {

        LoseGame();
        WinGame();
    }
    private void LoseGame()
    {
        if (Player.Instance.Shock)
        {
            LoseTime -= Time.deltaTime;
        }
        Reload(); 
    }
    private void Reload()
    {
        if (LoseTime < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void WinGame()
    {
        if(Player.Instance.gameObject.transform.position.x >= FinishCube.transform.position.x)
        {
            Debug.Log(1);
            Player.Instance.WinGame();
            Win = true;
            EndLevelUI.SetActive(true); 
        }
    }
    private void ChangeLevel()
    {
        
        if (Win)
        {
            string TmpScene = SceneManager.GetActiveScene().name;
            double NextLevel = char.GetNumericValue(TmpScene[TmpScene.Length-1]);
            NextLevel = NextLevel + 1;
            if(NextLevel <= 3)
            {
                    SceneManager.LoadScene("Level" + NextLevel.ToString());
            } 
        }
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    public void OnNextLevelButton()
    {
         ChangeLevel(); 
    }
}
