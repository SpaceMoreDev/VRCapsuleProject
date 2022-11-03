using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView prefab_Player;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("connected to server");
        PhotonNetwork.JoinRandomOrCreateRoom();    
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("joined a room successfully");
        PhotonNetwork.Instantiate(prefab_Player.name,prefab_Player.transform.position,Quaternion.identity);

    }
}
