using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour, IInteractable
{
    //For calling ontrigger enter one time
    private int pTouched = 0;

    [SerializeField] TrailRenderer[] trailRenderers;

    #region Unity methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            if (pTouched == 0)
            {
                pTouched = 1;
                Interact();
                StartCoroutine(MakeDirtDeactive());

            }

        }
    }



    IEnumerator MakeDirtDeactive()
    {
        yield return new WaitForSeconds(1.5f);
        pTouched = 0;
        foreach (TrailRenderer renderer in trailRenderers)
        {
            renderer.emitting = false;
        }
    }

    #endregion

    #region Public methods

    public void Interact()
    {
        for (int i = 0; i < trailRenderers.Length; i++)
        {
            if (i < StackMechanic.Instance.wheels.Count)
            {
                trailRenderers[i].emitting = true;
            }
            else
            {
                trailRenderers[i].emitting = false;
            }
        }

    }


    #endregion
}
