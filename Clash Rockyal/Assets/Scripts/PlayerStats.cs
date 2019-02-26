using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public const int MAX_CARDS_IN_HAND = 4;
    private const int MAX_HEALTH = 20;
    private const int MAX_MANA = 10;
    private const int MANA_REGENERATION = 1;
    public int currentHealth = MAX_HEALTH;
    public int currentMana = 6;
    public Card[] cardsInHand = new Card[MAX_CARDS_IN_HAND];



}
