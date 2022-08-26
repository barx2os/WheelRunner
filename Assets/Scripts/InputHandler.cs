using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Transform firstWheel;

    #region Mouse variable
    private Vector3 mouseStartPosition;
    private Vector3 mouseOffset;
    public LayerMask layerMask;
    private float mouseSensivity = 4.05f;
    #endregion

    [SerializeField] bool debug = false;


    #region Unity methods

    private void FixedUpdate()
    {
        if (firstWheel.transform.position.x <= -1.745f && firstWheel.transform.position.x >= -2.090f)
        {
            firstWheel.transform.Translate(0f, 0f, -mouseOffset.x * mouseSensivity * Time.deltaTime);       
        }

    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, layerMask))
        {
            mouseStartPosition = raycastHit.point;
        }
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, layerMask))
        {
            mouseOffset = mouseStartPosition - raycastHit.point;
            if (mouseOffset.x > 0.15f)
            {
                mouseStartPosition = raycastHit.point;
            }
        }
        else
        {
            mouseStartPosition = firstWheel.transform.position;
        }

        if (debug)
        {
            Debug.Log(mouseOffset.x);
        }
    }

    #endregion
}
