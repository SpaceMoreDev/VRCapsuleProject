using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public void OnPointerExit()
    {
       //do stuff
    }
    public void OnPointerEnter()
    {
        //do stuff
    }
    public void OnPointerClick(GameObject obj)
    {
        obj.transform.GetComponent<Player>().targetPosition = new Vector3(gameObject.transform.position.x, 1.8f, gameObject.transform.position.z);
        obj.transform.GetComponent<Player>().moving = true;
    }
}
