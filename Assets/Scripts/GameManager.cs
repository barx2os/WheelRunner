using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool gameRunning;

    public GameObject canvas;

    
    #region Unity methods
    private void Start()
    {
        
      
    }

    #endregion

    #region Public methods
    public void IncreaseWheelCount()
    {
        
    }
    public void DecreaseWheelCount()
    {
          
    }

    public void MakeFinalWheel()
    {
        if (StackMechanic.Instance.wheels.Count == 1)
        {
            return;
        }

        for (int i = 1; i < StackMechanic.Instance.wheels.Count; i++)
        {
            Destroy(StackMechanic.Instance.wheels[i]);
        }

        float finalScaleValue = Mathf.Clamp(1f, 1.6f, StackMechanic.Instance.wheels.Count);
        StackMechanic.Instance.wheels[0].transform.localScale = StackMechanic.Instance.wheels[0].transform.localScale * finalScaleValue;

    }

    public void StartGame()
    {
        canvas.SetActive(false);
        gameRunning = true;
    }

    #endregion

}
