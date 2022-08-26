using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackMechanic : Singleton<StackMechanic>
{
    public List<GameObject> wheels = new List<GameObject>();
    public float movementDelay = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        else
        {
            MoveOrigin();
        }

    }

    public void StackWheel(GameObject other, int index)
    {
        int temp = index;
        wheels.Add(other);

        other.transform.position = new Vector3(
                wheels[temp].transform.position.x,
                wheels[temp].transform.position.y,
                wheels[temp].transform.position.z - 0.15f);

        Debug.Log(index);
        
    }

    private void MoveListElements()
    {
        for (int i = 1; i < wheels.Count; i++)
        {
            if (wheels[i] != null)
            {
                wheels[i].transform.position = new Vector3(
                    Mathf.Lerp(wheels[i].transform.position.x, wheels[i - 1].transform.position.x, Time.deltaTime * 20f),
                    Mathf.Lerp(wheels[i].transform.position.y, wheels[i - 1].transform.position.y, Time.deltaTime * 20f),
                    wheels[i - 1].transform.position.z - 0.15f);
            }
            
            
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < wheels.Count; i++)
        {
            if (wheels[i] != null)
            {
                wheels[i].transform.position = new Vector3(
                    Mathf.Lerp(wheels[i].transform.position.x, wheels[0].transform.position.x, Time.deltaTime * 20f),
                    wheels[i].transform.position.y,
                    wheels[i - 1].transform.position.z - 0.15f);
            }
        }
    }
}
