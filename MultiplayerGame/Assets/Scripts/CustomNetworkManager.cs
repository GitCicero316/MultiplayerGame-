using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        print(message: "The player just entered the game.");
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        print(message: "The player just left the game.");
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        print(message: "Connection to the server was lost.");
    }
}
