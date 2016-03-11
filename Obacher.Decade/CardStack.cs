using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obacher.CardGame.Core;

namespace Obacher.Decade
{
    public class CardStack
    {
        private readonly CircularLinkedList<Card> _stack = new CircularLinkedList<Card>();

        IList<StackNode<Card>> _possibilities = new List<StackNode<Card>>();

        public void Add(Card card)
        {
            _stack.AddLast(card);

            foreach (var possibility in _possibilities)
            {
                Check(possibility);
            }
        }

        private void Check(StackNode<Card> possibility)
        {
            Card startingCard = possibility.First;
        }

    }

    class StackNode<T>
    {
        public T First { get; private set; }
        public T Last { get; private set; }

        public StackNode(T first, T last)
        {
            First = first;
            Last = last;
        }
    }
}
