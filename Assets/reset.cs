using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    Transform player;

    private void Start() {
        player = mainPlayer.current.transform;
    }

    private void Update() {
        if(player.position.y < -10)
        {
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            SceneManager.LoadScene(0);
        }
    }
}
