using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Char : MonoBehaviour
{
    public void OnPointerExit()
    {
        //do stuff
    }
    public void OnPointerEnter()
    {
        if (transform.tag == "LookL")
        {
            Vector3 rotationToAdd = new Vector3(0, -45, 0);
            transform.parent.Rotate(rotationToAdd);
            transform.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("rot Left");
        }
        else if (transform.tag == "LookR")
        {
            Vector3 rotationToAdd = new Vector3(0, 45, 0);
            transform.parent.Rotate(rotationToAdd);
            transform.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("rot Right");

        }
    }
    public void OnPointerClick(GameObject obj)
    {
        //do stuff
    }
}
