using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndex : MonoBehaviour
{
    public static PlayerIndex instance;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Debug.LogError("There is more than one instance of PlayerIndex in this scene");
    }

    public List<NetworkedPlayer> players = new List<NetworkedPlayer>();

    public void AddPlayer(NetworkedPlayer player)
    {
        if (!players.Contains(player))
            players.Add(player);
    }

    public void RemovePlayer(NetworkedPlayer player)
    {
        if (players.Contains(player))
            players.Remove(player);
    }
}
