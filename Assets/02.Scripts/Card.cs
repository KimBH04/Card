using System;
using UnityEngine;

public class Card : MonoBehaviour, IEquatable<Card>
{
    private CardShape shape;

    private int number;

    public CardShape Shape => shape;

    public int Number => number;

    private void Awake()
    {
        // name: {BackColor}_PlayingCards_{Shape}{Number}_{Minor}
        var parse = name.Split('_');
        var cardName = parse[2];
        if (cardName == "Joker")
        {
            shape = parse[3] == "00" ? CardShape.ColorJoker : CardShape.BlackJoker;
        }
        else
        {
            shape = Enum.Parse<CardShape>(cardName[..^2]);
            number = int.Parse(cardName[^2..]);
        }
    }

    public bool Equals(Card other)
    {
        if (other == null)
            return false;

        return other.shape == shape && other.number == number;
    }
}

public enum CardShape
{
    Spade   = 0b00001,
    Heart   = 0b00010,
    Club    = 0b00100,
    Diamond = 0b01000,
    Joker   = 0b10000,
    BlackJoker = 0b10101,
    ColorJoker = 0b11010,
}