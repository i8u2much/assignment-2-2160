using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public int healthPoint;
    public Transform startingPosition;
    private Transform lastCheckpoint;    
    static private GameManager instance;
    static public GameManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager.");
            }
            return instance;
        }
    }
    
    private int healthRemaining;
    public int HealthRemaining
    {
        get
        {
            return healthRemaining;
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
        healthRemaining = healthPoint;
        lastCheckpoint = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Checkpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
    }
    
    public void GameState(bool win)
    {
        UIManager.Instance.GameState(win);
    }
}
