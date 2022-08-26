using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpForce : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            
           other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Force);
           Debug.Log("force applied");

   

        }
    }


}
