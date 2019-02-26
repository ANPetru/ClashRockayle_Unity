using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RockSpawner : NetworkBehaviour {

    public Transform[] spawnPointsLocal;
    public Transform[] spawnPointsEnemy;

    public GameObject rockPrefab;

    public bool SpawnCard(Transform cardTransform, Card card)
    {
        Vector3 cardPosition = cardTransform.position;
        for (int i = 0;i<spawnPointsLocal.Length;i++)
        {
            Transform path = spawnPointsLocal[i];
            float xLeft = path.position.x - 0.5f;
            float xRight = path.position.x + 0.5f;
            if (cardPosition.x >= xLeft && cardPosition.x <= xRight)
            {
                float zUp = path.position.z + 0.5f;
                float zDown = path.position.z - 0.5f;
                if (cardPosition.z >= zDown && cardPosition.z <= zUp)
                {
                    GameManager.GetInstance().player.SpawnRocks(path,card,i);
                    return true;
                }
            }
        }
        return false;

    }

    public void SpawnRock(Transform path, Card card)
    {
        GameObject rock = Instantiate(rockPrefab, path.transform.position, Quaternion.identity) as GameObject;
        rock.transform.SetParent(transform);
        rock.GetComponent<RockMovement>().SetRockSize(card.health);
    }

    public void SpawnEnemyRock(int index, Card card)
    {
        Transform path = spawnPointsEnemy[index];
        GameObject enemyRock = Instantiate(rockPrefab, path.position, Quaternion.identity) as GameObject;
        enemyRock.transform.SetParent(transform);
        enemyRock.GetComponent<RockMovement>().SetRockSize(card.health);
        
    }
}
