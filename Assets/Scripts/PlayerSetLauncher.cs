using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetLauncher : MonoBehaviour
{

    public static mainPlayer Player;
    [SerializeField] private Launcher launcherScript;
    
    // Start is called before the first frame update
    private void Start() {
        
        if(mainPlayer.current != null)
        {
            mainPlayer player =  mainPlayer.current;
            player.transform.position = new Vector3(0, 2, -3.5f);
        }

        launcherScript.SpawnedPlayer += Spawned;
    }
    private void Spawned(GameObject player)
    {
        Player = player.GetComponent<mainPlayer>();
    }

    private void OnDestroy() {
        launcherScript.SpawnedPlayer -= Spawned;
    }
}
