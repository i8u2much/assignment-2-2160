using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameStatePanel;
    public CheckPoint checkP1;
    public CheckPoint checkP2;
    public CheckPoint checkP3;
    public CheckPoint checkP4;
    public CheckPoint checkP5;
    public Text gameStateTxt;
    public Text timerTxt;
    public Text checkP1Txt;
    public Text checkP2Txt;
    public Text checkP3Txt;
    public Text checkP4Txt;
    public Text checkP5Txt;
    public Slider healthSlider;
    public string loseTxt;
    public string winTxt;
    private float timer;
    
    static private UIManager instance;
    static public UIManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                Debug.LogError("There is not UIManager.");
            }            
            return instance;
        }
    }
    
    void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameStatePanel.SetActive(false);
        checkP1.SetActiveCheckerP(true);
        healthSlider.maxValue = gameManager.healthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerTxt.text = Timer();
        healthSlider.value = gameManager.HealthRemaining;
    }
    
    public void GameState(bool win)
    {
        if (win)
        {
            gameStateTxt.text = winTxt;
        }
        else 
        {
            gameStateTxt.text = loseTxt;
        }
        checkP1Txt.text = "Checkpoint1: " + checkP1.Timer;
        checkP2Txt.text = "Checkpoint2: " + checkP2.Timer;
        checkP3Txt.text = "Checkpoint3: " + checkP3.Timer;
        checkP4Txt.text = "Checkpoint4: " + checkP4.Timer;
        checkP5Txt.text = "Checkpoint5: " + checkP5.Timer;
        gameStatePanel.SetActive(true);
    }
    
    public void Restart()
    {
        // reload this scene
        SceneManager.LoadScene(0);
        gameStatePanel.SetActive(false);
    }
    
    public string Timer()
    {
        int minute;
        int second;
        int centisecond;
        string minuteTxt;
        string secondTxt;
        string centisecondTxt;
        
        minute = (int)(timer/60);
        second = (int)(timer%60);
        centisecond = (int)(timer*100 % 100);
        minuteTxt = addZeroTimer(minute);
        secondTxt = addZeroTimer(second);
        centisecondTxt = addZeroTimer(centisecond);              
        return minuteTxt + ":" + secondTxt + ":" + centisecondTxt;
    }
    
    private string addZeroTimer(int currentTime)
    {
        if (currentTime < 10)
        {
            return "0" + currentTime;
        }
        else
        {
            return currentTime.ToString();
        }
    }
}
