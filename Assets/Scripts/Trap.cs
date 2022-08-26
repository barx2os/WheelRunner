using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject brokenWheel;

    //For calling ontrigger enter one time
    private int pTouched = 0;

    #region Unity methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            if (pTouched == 0)
            {
                pTouched = 1;
                Interact();
                StartCoroutine(MakeTriggerActive());

                if (StackMechanic.Instance.wheels.Count > 1)
                {
                    GameObject go = StackMechanic.Instance.wheels[StackMechanic.Instance.wheels.Count - 1];
                    StackMechanic.Instance.wheels.RemoveAt(StackMechanic.Instance.wheels.Count - 1);
                    Destroy(go);
                }
            }

        }
    }

    

    IEnumerator MakeTriggerActive()
    {
        yield return new WaitForSeconds(0.25f);
        pTouched = 0;
    }


    #endregion

    #region Public methods
    public void Interact()
    {
        
        if (StackMechanic.Instance.wheels.Count > 1)
        {
            GameObject go = Instantiate(brokenWheel, this.transform.position, transform.rotation);
            if (go.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(200f, this.transform.position, 6f);
            }

            Destroy(go, 2f);
        }
        
    }

    #endregion
}