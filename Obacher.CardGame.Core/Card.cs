using System;

namespace Obacher.CardGame.Core
{
    [Serializable]
    public struct Card : IEquatable<Card>, ICloneable
    {
        public CardValueType Value { get; }
        public SuitType Suit { get; }

        public Card(CardValueType value, SuitType suit)
        {
            Value = value;
            Suit = suit;
        }


        #region IClonable implementation

        public object Clone()
        {
            return new Card(Value, Suit);
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
            return Value.GetHashCode() ^ Suit.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value}:{Suit}";
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Card other)
        {
            return Value == other.Value && Suit == other.Suit;
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
