using System;

namespace BlackJack
{
          public enum SuitType
	{
		Clubs, Spades, Hearts, Diamonds
	}

	public struct Card
	{
		public SuitType Suit;
		public int Value;
	}

	public struct Deck
	{
		public Card[] Cards;
	}

    class MainClass
    {
        public Deck deck;

        public static void Main(string[] args)
        {
            MainClass Game = new MainClass();
            Game.Init();
        }

        public void Shuffle()
        {
            
        }
        public void Init()
        {
            this.deck = new Deck();             this.deck.Cards = new Card[36];             int cardnum = 0;             //2,3,4,6,7,8,9,10,11           for (int i = 2; i <= 11; i++)
          {             if (i == 5)             {                 continue;             }              foreach (var value in Enum.GetValues(typeof(SuitType)))             {                 this.deck.Cards[cardnum] = new Card();                 this.deck.Cards[cardnum].Value = i;                 this.deck.Cards[cardnum].Suit = (SuitType)value;                 Console.WriteLine(deck.Cards[cardnum].Value);                 cardnum++;             }
          }
    }
  }
}