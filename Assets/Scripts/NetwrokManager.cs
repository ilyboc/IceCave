using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetwrokManager : MonoBehaviourPunCallbacks
{
    public GameObject startButton;

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to Connect to Server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby.");
        startButton.SetActive(true);
    }

    public void InitializeRoom()
    {
        //if (PhotonNetwork.CountOfPlayers != 2) return;
        PhotonNetwork.LoadLevel(1);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Game", roomOptions, TypedLobby.Default);
    }

    public void Exit()
    {
        PhotonNetwork.Disconnect();
        Application.Quit();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room.");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A New Player Joined the Room.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
