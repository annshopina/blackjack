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
		public int[] array1 = new int[15];
		public int[] array2 = new int[15];
        public int cardnum = 0;
        public int usercardnum = 0;
        public int compcardnum = 0;
        public int sumcomp = 0;
        public int sumuser = 0;
        public static void Main(string[] args)
        {
            MainClass Game = new MainClass();
            Game.Init();
            bool player = Game.FirstPlayer();
            Game.GetCard(false);
            Game.GetCard(false);
            Game.GetCard(true);
            Game.GetCard(true);
            while (Game.Result())
            {
                if (player == false)
                {
                    if (Game.sumcomp < 21 || Game.sumcomp/2 != 11)
                    {
                        Game.GetCard(false);
                        player = true;
                    }
                }

                Console.WriteLine("Your result "  +  Game.sumuser);
                Console.WriteLine("One more card? 1- Yes, 2 - No");
                int input2 = int.Parse(Console.ReadLine());
                if (input2 == 1)
                {
                    Game.GetCard(true);
                    Game.GetCard(false);
                }
                else
                {
                    Console.WriteLine("Your score " + Game.sumuser);
                    Console.WriteLine("Computer score " + Game.sumcomp);
                    break;
                }
            }
           
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
				int temp;
				temp = rand.Next(35);
				int temp1;
				temp1 = rand.Next(35);
                Card buff = this.deck.Cards[temp];
                this.deck.Cards[temp] = this.deck.Cards[temp1];
                this.deck.Cards[temp1] = buff;
            }

        }
        public void Init()
        {
            this.deck = new Deck();             this.deck.Cards = new Card[36];             int cardnumber = 0;             //2,3,4,6,7,8,9,10,11           for (int i = 2; i <= 11; i++)
          {             if (i == 5)             {                 continue;             }              foreach (var value in Enum.GetValues(typeof(SuitType)))             {                 this.deck.Cards[cardnumber] = new Card();                 this.deck.Cards[cardnumber].Value = i;                 this.deck.Cards[cardnumber].Suit = (SuitType)value;               //  Console.WriteLine(deck.Cards[cardnum].Value);                 cardnumber++;             }
          }

            this.Shuffle();
        }

        public  bool FirstPlayer()
        {
            Console.WriteLine("Who plays firs - you or computer? If you type 1 else 0. Please, type.");
            string input1 = Console.ReadLine();
			int a = int.Parse(input1);
            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
  }

        public void Calculation()
        {
            sumcomp = 0;
            sumuser = 0;
			for (int i = 0; i < this.compcardnum; i++)
			{
				int j = this.array1[i];
				sumcomp = sumcomp + this.deck.Cards[j].Value;
			}

			
			for (int i = 0; i < this.usercardnum; i++)
			{
				int j = this.array2[i];
				sumuser = sumuser + this.deck.Cards[j].Value;
			}
        }
        public void GetCard(bool a)
        {
            if (a == false)
            {
                this.array1[this.compcardnum] = this.cardnum;
                this.compcardnum++;
                this.cardnum++;
            }

            else
            {
                this.array2[this.usercardnum] = this.cardnum;
                this.usercardnum++;
                this.cardnum++;
            }
        }
        public bool Result()
        {
            this.Calculation();
            if ((sumuser >=21 || sumuser/2==11) ||(sumcomp >= 21 || sumcomp / 2 == 11))
            {
                Console.WriteLine("Game over");
				Console.WriteLine("Your score " + this.sumuser);
                Console.WriteLine("Computer score " + this.sumcomp);
                return false;
            }
            return true;
        }
    }
}

