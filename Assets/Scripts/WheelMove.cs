using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.4f;

    //[SerializeField] Transform firstWheel;

    #region Mouse variable
    private Vector3 mouseStartPosition;
    private Vector3 mouseOffset;
    public LayerMask layerMask;
    private float mouseSensivity = 5.35f;
    #endregion

    [SerializeField] bool debug = true;


    #region Unity methods

    private void Update()
    {
        if (GameManager.Instance.gameRunning)
        {
            this.transform.position += -Vector3.forward * moveSpeed * Time.deltaTime;

        }


        if (transform.position.x > -1.745f)
        {
            transform.position = new Vector3(-1.747f, 0.1304422f, transform.position.z);
        }
        if (transform.position.x < -2.090f)
        {
            transform.position = new Vector3(-2.088f, 0.1304422f, transform.position.z);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                mouseStartPosition = raycastHit.point;

            }
        }

        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                mouseOffset = mouseStartPosition - raycastHit.point;
                float absMouseOffset = Mathf.Abs(mouseOffset.x);
                if (absMouseOffset > 0.15f)
                {
                    mouseStartPosition = raycastHit.point;
                }
            }       
        }

        if (Input.GetButtonUp("Fire1"))
        {
            mouseOffset = new Vector3(0f, 0f, 0f);
        }

        if (transform.position.x <= -1.600f && transform.position.x >= -2.102f)
        {
            transform.position = new Vector3(transform.position.x - mouseOffset.x * mouseSensivity * Time.deltaTime, transform.position.y, transform.position.z);

        }
    }

    private void FixedUpdate()
    {
        


    }

    #endregion


}
