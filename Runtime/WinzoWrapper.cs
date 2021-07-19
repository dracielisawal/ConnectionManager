using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace WinzoConnectionManager
{
    public class WinzoWrapper : MonoBehaviourPunCallbacks
    {
        public delegate void OnConnectionEshtablished();
        public static event OnConnectionEshtablished OnconnectionEshtablished;

        public delegate void OnRoomEntered();
        public static event OnRoomEntered OnroomEntered;
        public enum ReconnectionStates
        {
            InRoom,
            Disconnected,
            Rejoining,
            Rejoined
        }
        ReconnectionStates MyReconnectionState;

        public override void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public override void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public ReconnectionStates GetReconnectionStatus()
        {
            return MyReconnectionState;
        }
        public void ConnectToWinzo()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        

        public void CreateWinzoRoom(string roomname, RoomOptions roomOptions, TypedLobby lobby)
        {

            PhotonNetwork.CreateRoom(roomname, roomOptions, lobby);

        }

        public void JoinRandomWinzoRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            OnroomEntered(); //event
        }
        public override void OnConnectedToMaster()
        {
            OnconnectionEshtablished(); // classes can subscribe/unsubscribe to this.

        }

        public void DisconnectFromWinzo()
        {
            PhotonNetwork.Disconnect();
        }

    }
}