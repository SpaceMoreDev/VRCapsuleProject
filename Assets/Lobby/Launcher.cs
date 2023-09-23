using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView prefab_Player;
    public event Action<GameObject> SpawnedPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        if(mainPlayer.current == null){
            Debug.Log("connected to server");
            PhotonNetwork.JoinRandomOrCreateRoom();    
        }
    }
    public override void OnJoinedRoom()
    {
        if(mainPlayer.current == null){
            Debug.Log("joined a room successfully");
            GameObject player = PhotonNetwork.Instantiate(prefab_Player.name,prefab_Player.transform.position,Quaternion.identity);
            SpawnedPlayer?.Invoke(player);
        }

    }
}
