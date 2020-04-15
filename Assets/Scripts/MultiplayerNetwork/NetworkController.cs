﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{    
    // Start is called before the first frame update
    void Start() {
        if (!PhotonNetwork.IsConnected)
            // this automatically connects to the US server
            // go to Photon/PhotonUnityNetworking/Resrouces and and its in PhotonServerSettings
            // if you click Edit WhiteList, you acn see that you can edit which regions to connect to
            // if you add other regions then sometimes not all people will be in the same lobby which will cause problems
            PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
            // you could also use this to specify which region to connect to
            // but you would need to specificy the server address, the port, and the appID, which can be complicated to find so using ConnectUsingSettings will be easier
            // PhotonNetwork.ConnectToMaster(masterServerAddress, port, appID)
            // PhotonNetwork.ConnectToRegion("US");  <-- specify the region here
    }

    public override void OnConnectedToMaster() {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");

        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();

    }
}
