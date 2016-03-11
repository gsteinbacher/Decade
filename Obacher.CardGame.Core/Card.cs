using System;

namespace Obacher.CardGame.Core
{
    [Serializable]
    public struct Card : IEquatable<Card>, ICloneable
    {
        public RankType Rank { get; }
        public SuitType Suit { get; }
        public int Value { get; set; }

        /// <summary>
        /// Create an instance of a <see cref="Card"/>
        /// </summary>
        /// <param name="rank">The rank of the card</param>
        /// <param name="suit">The suit of the card</param>
        /// <param name="value">The numeric value of the card, the defaults are Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14</param>
        public Card(RankType rank, SuitType suit, int value = 0)
        {
            Rank = rank;
            Suit = suit;
            Value = value;
            if (Value <= 0)
                Value = GetDefaultValue(rank);
        }

        private static int GetDefaultValue(RankType rank)
        {
            switch (rank)
            {
                case RankType.Two:
                    return 2;
                case RankType.Three:
                    return 3;
                case RankType.Four:
                    return 4;
                case RankType.Five:
                    return 5;
                case RankType.Six:
                    return 6;
                case RankType.Seven:
                    return 7;
                case RankType.Eight:
                    return 8;
                case RankType.Nine:
                    return 9;
                case RankType.Ten:
                    return 10;
                case RankType.Jack:
                    return 11;
                case RankType.Queen:
                    return 12;
                case RankType.King:
                    return 13;
                case RankType.Ace:
                    return 14;
                default:
                    return 0;
            }
        }

        #region IClonable implementation

        public object Clone()
        {
            return new Card(Rank, Suit, Value);
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                return false;

            return Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            return Rank.GetHashCode() ^ Suit.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Rank}:{Suit}";
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Card other)
        {
            return Rank == other.Rank && Suit == other.Suit;
        }

        #endregion

        public static bool operator ==(Card one, Card two)
        {
            return one.Equals(two);
        }

        public static bool operator !=(Card one, Card two)
        {
            return !one.Equals(two);
        }
    }
}
