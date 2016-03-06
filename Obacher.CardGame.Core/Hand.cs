using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Obacher.CardGame.Core
{
    public sealed class Hand : IEnumerable<Card>
    {
        private readonly IEnumerable<Card> _cards;

        public Hand(params Card[] cards)
        {
            if (!cards.Any())
                throw new ArgumentOutOfRangeException(nameof(cards), "Hand must contain at least one card");

            _cards = cards;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}