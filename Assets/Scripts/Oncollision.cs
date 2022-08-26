using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tyre")
        {
            if (!StackMechanic.Instance.wheels.Contains(other.gameObject))
            {
                //other.gameObject.transform.position = transform.position + Vector3.forward * 0.15f;
                other.gameObject.AddComponent<Oncollision>();
                other.gameObject.AddComponent<WheelRotate>();

                other.gameObject.GetComponent<MeshCollider>().isTrigger = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                
                other.gameObject.tag = "Wheel";
                //StackMechanic.Instance.wheels.Add(other.gameObject);


                StackMechanic.Instance.StackWheel(other.gameObject, StackMechanic.Instance.wheels.Count - 1);
            }
        }
    }
}
