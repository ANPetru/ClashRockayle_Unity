using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    private PlayerStats playerStats;
    GameManager gm;


    private void Awake()
    {
        gm = GameManager.GetInstance();


    }
    private void Start()
    {
        if (!isLocalPlayer) return;
        playerStats = GetComponent<PlayerStats>();
        gm.GetCardSpawner().DrawInitCards(playerStats);
    }


    public override void OnStartLocalPlayer()
    {
        gm.player = this;
    }

    void Update() {
        if (!isLocalPlayer) return;

	}


    public void SpawnRocks(Transform path, Card card, int i)
    {

        if (isLocalPlayer)
        {
            gm.GetRockSpawner().SpawnRock(path, card);
            if (isServer)
            {
                RpcSpawnEnemyRock(i, card);
            }
            else
            {
                CmdSpawnEnemyRock(i, card);

            }

        } 

    }

    [Command]
    private void CmdSpawnEnemyRock(int i, Card card)
    {
        gm.GetRockSpawner().SpawnEnemyRock(i, card);

    }

    [ClientRpc]
    private void RpcSpawnEnemyRock(int i, Card card)
    {
        if(!isServer)
        gm.GetRockSpawner().SpawnEnemyRock(i, card);

        

    }


}
