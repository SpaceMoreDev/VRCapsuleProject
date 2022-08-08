using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene(0);   
    }
}
