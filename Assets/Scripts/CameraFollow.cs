using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.2f;

    public Vector3 offset;

    #region Unity methods

    private void LateUpdate()
    {            
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 2f);

        //transform.LookAt(target);
    }


    #endregion
}
