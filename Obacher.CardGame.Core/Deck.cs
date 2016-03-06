using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Obacher.CardGame.Core
{
    public class Deck
    {
        private int _deckNumber;
        private Card[] _deck;

        public Deck()
        {
            Initialize();
        }

        public void Shuffle()
        {
            _deck.Shuffle();
        }

        public IEnumerable<Card> Deal(int number)
        {
            for (int i = 0; i < number; i++)
                yield return _deck[_deckNumber++];
        }

        private void Initialize()
        {
            int cardCount = 0;
            _deck = new Card[52];

            foreach (CardValueType cardValue in Enum.GetValues(typeof(CardValueType)))
                foreach (SuitType suitType in Enum.GetValues(typeof(SuitType)))
                    _deck[cardCount++] = new Card(cardValue, suitType);

            _deckNumber = 0;
        }
    }

    internal static class InternalShuffle
    {
        static class ThreadSafeRandom
        {
            [ThreadStatic]
            private static Random _local;

            public static Random ThisThreadsRandom
            {
                get { return _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
            }
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