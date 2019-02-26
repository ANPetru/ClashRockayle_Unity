using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {

    private PlayerStats playerStats;
    GameManager gm;
    public Transform[] spawnPoints;
    public GameObject cardPrefab;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void DrawInitCards(PlayerStats ps)
    {
        playerStats = ps;
        int cardsToDraw = PlayerStats.MAX_CARDS_IN_HAND;
        Card[] cards = new Card[PlayerStats.MAX_CARDS_IN_HAND];
        while (cardsToDraw > 0)
        {
            Card card = GetRandomCard();
            bool hit = false;
            foreach (Card c in cards)
            {
                if (card == c)
                {
                    hit = true;
                    break;
                }
            }
            if (!hit)
            {
                cards[cardsToDraw - 1] = card;
                cardsToDraw--;
            }
        }

        playerStats.cardsInHand = cards;
        SpawnInitCards();
    }

    private void SpawnInitCards()
    {
        for (int i = 0; i < playerStats.cardsInHand.Length; i++) 
        {
            SpawnCard(playerStats.cardsInHand[i], i);
        }
    }
    public void SpawnCard(Card cardStats, int position)
    {
        GameObject card = Instantiate(cardPrefab,spawnPoints[position].position,Quaternion.identity) as GameObject;
        card.GetComponent<CardMovement>().SetCard(cardStats);
    }

    public void DrawNewCard(Card c)
    {
        Card[] actualCards = playerStats.cardsInHand;
        int cardPos = GetCardPosition(c);
        if (cardPos == -1) return;
        bool spawn = false;
        while (!spawn)
        {
            Card card = GetRandomCard();
            spawn = true;
            foreach (Card actualCard in actualCards) 
            {
                if (actualCard == card)
                {
                    spawn = !true;
                    break;
                }
            }
            if (spawn)
            {
                SpawnCard(card, cardPos);
                playerStats.cardsInHand[cardPos] = card;


            }
        }
    }

    private int GetCardPosition(Card c)
    {
        for (int i = 0; i < playerStats.cardsInHand.Length; i++)
        {
            if (c == playerStats.cardsInHand[i])
            {
                return i;
            }
        }
        return -1;

    }

    private Card GetRandomCard()
    {
        int cardIndex = Random.Range(0, gm.allCards.Length);
        return gm.allCards[cardIndex];
    }
}
