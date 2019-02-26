using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card")]
[System.Serializable]
public class Card : ScriptableObject {

    public int manaCost;
    public int health;

    private Transform pathToSpawn;
    
}
