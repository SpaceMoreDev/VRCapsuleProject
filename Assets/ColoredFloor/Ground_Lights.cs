using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Lights : MonoBehaviour
{
    public List<Material> colors = new List<Material>();

    public void Get_inside_children()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Count)];
        }
    }
}


