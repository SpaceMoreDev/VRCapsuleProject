using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject doors;

    public void OnPointerEnter()
    {
        //stuff
    }

    public void OnPointerExit()
    {
        //stuff
    }

    public void Goto_Scene()
    {
        var em = ps.emission;
        em.enabled = false;
        doors.SetActive(true);
    }
}
