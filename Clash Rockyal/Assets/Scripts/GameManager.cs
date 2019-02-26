using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public Card[] allCards;
    public RockSpawner rockSpawner;
    public CardSpawner cardSpawner;
    public PlayerController player;

    private void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        allCards = new Card[8];
        for(int i = 0; i < allCards.Length; i++)
        {
            allCards[i] = (Card)ScriptableObject.CreateInstance(typeof(Card));
            allCards[i].health = i + 1;
            allCards[i].manaCost = i + 1;
        }
    }



    public static GameManager GetInstance()
    {
        return instance;
    }

    public RockSpawner GetRockSpawner()
    {
        return rockSpawner;
    }

    public CardSpawner GetCardSpawner()
    {
        return cardSpawner;
    }
}
