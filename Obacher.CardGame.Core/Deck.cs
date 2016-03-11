using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Obacher.CardGame.Core
{
    public class Deck : IDeck
    {
        private int _deckNumber;
        private Card[] _deck;

        public Deck()
        {
            Initialize();
        }

        private void Initialize()
        {
            int cardCount = 0;
            _deck = new Card[52];

            foreach (RankType rank in Enum.GetValues(typeof(RankType)))
                foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
                    _deck[cardCount++] = new Card(rank, suit);

            _deckNumber = 0;
        }

        public void Shuffle()
        {
            _deck.Shuffle();
        }

        public void Reset()
        {
            _deckNumber = 0;
        }

        public Card DealCard()
        {
            return Deal(1).FirstOrDefault();
        }

        public IEnumerable<Card> Deal(int number = 0)
        {
            number = number == 0 ? _deck.Length : Math.Min(number, _deck.Length);

            for (int i = 0; i < number; i++)
                if (_deckNumber < _deck.Length)
                    yield return _deck[_deckNumber++];
        }

        #region Setup numericValue

        /// <summary>
        /// Sets the face cards to the specified value and sets the Ace to specified value + 1, unless the Ace has already been set.
        /// </summary>
        /// <param name="value">Value in which to set the face cards</param>
        /// <returns>Instance of </returns>
        public IDeck SetFaceCardValues(int value = 10)
        {
            SetValue(RankType.Jack, value);
            SetValue(RankType.Queen, value);
            SetValue(RankType.King, value);
            SetValue(RankType.Ace, value + 1, false);
            return this;
        }

        public IDeck SetTwoValue(int numericValue)
        {
            SetValue(RankType.Two, numericValue);
            return this;
        }
        public IDeck SetThreeValue(int numericValue)
        {
            SetValue(RankType.Three, numericValue);
            return this;
        }
        public IDeck SetFourValue(int numericValue)
        {
            SetValue(RankType.Four, numericValue);
            return this;
        }
        public IDeck SetFiveValue(int numericValue)
        {
            SetValue(RankType.Five, numericValue);
            return this;
        }
        public IDeck SetSixValue(int numericValue)
        {
            SetValue(RankType.Six, numericValue);
            return this;
        }
        public IDeck SetSevenValue(int numericValue)
        {
            SetValue(RankType.Seven, numericValue);
            return this;
        }
        public IDeck SetEightValue(int numericValue)
        {
            SetValue(RankType.Eight, numericValue);
            return this;
        }
        public IDeck SetNineValue(int numericValue)
        {
            SetValue(RankType.Nine, numericValue);
            return this;
        }
        public IDeck SetTenValue(int numericValue)
        {
            SetValue(RankType.Ten, numericValue);
            return this;
        }
        public IDeck SetJackValue(int numericValue)
        {
            SetValue(RankType.Jack, numericValue);
            return this;
        }
        public IDeck SetQueenValue(int numericValue)
        {
            SetValue(RankType.Queen, numericValue);
            return this;
        }
        public IDeck SetKingValue(int numericValue)
        {
            SetValue(RankType.King, numericValue);
            return this;
        }
        public IDeck SetAceValue(int numericValue)
        {
            SetValue(RankType.Ace, numericValue);
            return this;
        }

        public IDeck SetValue(RankType rankType, int value, bool force = true)
        {
            for (int i = 0; i < _deck.Length; i++)
                if (_deck[i].Rank == rankType && (force || _deck[i].Value <= 0))
                    _deck[i].Value = value;

            return this;
        }

        #endregion
    }

    internal static class InternalShuffle
    {
        static class ThreadSafeRandom
        {
            [ThreadStatic]
            private static Random _local;

            public static Random ThisThreadsRandom => _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}