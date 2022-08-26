using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour, IInteractable
{
    //For calling ontrigger enter one time
    private int pTouchedtemp = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            if (pTouchedtemp == 0)
            {
                pTouchedtemp = 1;
                Interact();

            }

        }
    }


    #region Public methods
    public void Interact()
    {
        GameManager.Instance.MakeFinalWheel();
    }

    #endregion



}
