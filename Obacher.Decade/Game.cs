using System.Collections.Generic;
using System.Diagnostics;
using Obacher.CardGame.Core;

namespace Obacher.Decade
{
    public class Game
    {
        readonly CircularLinkedList<Card> _stack = new CircularLinkedList<Card>();

        public IEnumerator<Card> GetStack()
        {
            return _stack.GetEnumerator();
        }

        public int RemainingCount
        {
            [DebuggerStepThrough]
            get { return _stack.Count; }
        }

        public void Play(Card card)
        {
            _stack.AddLast(card);
            if (_stack.Count >= 3)
            {
                PlayRound(_stack.Tail.Previous.Previous);
            }
        }

        public bool IsWinner()
        {
            if (_stack.Count == 1 && _stack.Head.Value.Value.In(10, 20, 30))
                return true;

            return _stack.Count == 0;
        }


        private void PlayRound(Node<Card> startCard)
        {
            bool isDecade = true;
            while (isDecade)
            {
                var card1 = startCard;
                var card2 = startCard.Next;
                var card3 = startCard.Next.Next;
                isDecade = IsDecade(card1.Value, card2.Value, card3.Value);
                if (isDecade)
                {
                    _stack.Remove(card1.Value);
                    _stack.Remove(card2.Value);
                    _stack.Remove(card3.Value);

                    // Cards were removed, start by checking the last three cards in the stack
                    if (_stack.Count > 3)
                        PlayRound(_stack.Tail.Previous.Previous);

                    isDecade = false;
                }
                else
                {
                    if (_stack.Count > 3)
                    {
                        Node<Card> nextCard = startCard.Next;
                        if (nextCard != _stack.Head.Next)
                            PlayRound(nextCard);
                    }
                }
            }
        }

        private bool IsDecade(Card card1, Card card2, Card card3)
        {
            int sum = card1.Value + card2.Value + card3.Value;

            return sum.In(10, 20, 30);
        }
    }
}
