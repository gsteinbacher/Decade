using System;
using System.Collections.Generic;
using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.Decade
{
    public class Simulations
    {
        private Deck _deck;
        private Game _game;

        public List<int> CardsRemaining { get; private set; }
        public int WinningCount { get; private set; }

        public void Start(int numberOfIterations)
        {
            CardsRemaining = new List<int>();

            foreach (int i in Enumerable.Range(1, numberOfIterations))
            {
                if (i % 10000 == 0)
                    Console.Write(i + "\r");

                _deck = new Deck();
                _deck.SetFaceCardValues()
                    .SetAceValue(1);
                _deck.Shuffle();

                _game = new Game();

                foreach (var card in DealDeck())
                    _game.Play(card);

                if (_game.IsWinner())
                {
                    WinningCount++;
                }
                else
                {
                    CardsRemaining.Add(_game.RemainingCount);
                }
            }
        }

        public IEnumerable<Card> DealDeck()
        {
            _deck.Reset();
            return _deck.Deal();
        }

        public IEnumerator<Card> GetStack()
        {
            return _game.GetStack();
        }
    }
}
