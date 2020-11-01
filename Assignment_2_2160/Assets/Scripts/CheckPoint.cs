using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class CheckPoint : MonoBehaviour
{
    public Material neonMat;
    public Material dullMat;
    public CheckPoint nextCheckP;
    public UIManager uiManager;
    public GameManager gameManager;
    private Material currentMat;
    
    private string timer;
    public string Timer 
    {
        get 
        {
            return timer;
        }
    }
    private bool activeCheckP;
    
    void Start()
    {
        timer = "Incomplete";
        activeCheckP = false;
    }
    
    void Update()
    {
        if (activeCheckP == true)
        {
            transform.GetComponent<MeshRenderer>().material = neonMat;
        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (activeCheckP == true)
        {
            timer = uiManager.Timer();
            nextCheckP.SetActiveCheckerP(true);
            activeCheckP = false;
        }
        if (nextCheckP == null)
        {
            gameManager.GameState(true);
        }
    }
    
    public void SetActiveCheckerP (bool setter)
    {
        activeCheckP = setter;
    }
}
