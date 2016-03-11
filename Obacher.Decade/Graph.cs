using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Obacher.CardGame.Core;

namespace Obacher.Decade
{
    public class Graph
    {
        List<GraphNode> _graphs = new List<GraphNode>();

        public void Add(Card card)
        {
            foreach (GraphNode graph in _graphs)
            {
                    Play(graph, card);
            }
        }

        private void Add(GraphNode node, Card card)
        {
            GraphNode newNode = new GraphNode(card, node);
            node.Children.Add(newNode);
        }

        public void Play(List<GraphNode> graph, Card card)
        {
            GraphNode last = graph.Last();
            if (Play(last, card))
                Add(last, card);
        }

        public bool Play(GraphNode node, Card card)
        {
            int sum = card.Value + node.Value.Value + node.Parent.Value.Value;

            if (sum.In(10, 20, 30))
            {
                Play(node.Children, card);
                node.Parent = node.Parent.Parent;
                return false;
            }

            return true;
        }



        public class GraphNode
        {
            public Card Value { get; private set; }
            public GraphNode Parent { get; set; }
            public List<GraphNode> Children { get; private set; }

            public GraphNode(Card value, GraphNode parent)
            {
                Value = value;
                Parent = parent;
                Children = new List<GraphNode>();
            }
        }
    }

}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;

//namespace Obacher.Decade
//{
//    public class Graph<T> : IEnumerable<T>
//    {
//        private readonly NodeList<T> _nodeSet;

//        public Graph() : this(null) { }
//        public Graph(NodeList<T> nodeSet)
//        {
//            _nodeSet = nodeSet ?? new NodeList<T>();
//        }

//        public void AddNode(GraphNode<T> node)
//        {
//            // adds a node to the graph
//            _nodeSet.Add(node);
//        }

//        public void AddNode(T value)
//        {
//            // adds a node to the graph
//            _nodeSet.Add(new GraphNode<T>(value));
//        }

//        public void AddEdge(GraphNode<T> from, T to)
//        {
//            from.Neighbors.Add(new GraphNode<T>(to));
//        }

//        public bool Contains(T value)
//        {
//            return _nodeSet.FindByValue(value) != null;
//        }

//        public bool Remove(T value)
//        {
//            // first remove the node from the nodeset
//            GraphNode<T> nodeToRemove = (GraphNode<T>)_nodeSet.FindByValue(value);
//            if (nodeToRemove == null)
//                // node wasn't found
//                return false;

//            // otherwise, the node was found
//            _nodeSet.Remove(nodeToRemove);

//            // enumerate through each node in the nodeSet, removing edges to this node
//            foreach (var node in _nodeSet)
//            {
//                var gnode = (GraphNode<T>)node;
//                int index = gnode.Neighbors.IndexOf(nodeToRemove);
//                if (index != -1)
//                {
//                    // remove the reference to the node and associated cost
//                    gnode.Neighbors.RemoveAt(index);
//                }
//            }

//            return true;
//        }

//        public NodeList<T> Nodes => _nodeSet;

//        public int Count => _nodeSet.Count;

//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }




//    public class GraphNode<T> : Node<T>
//    {
//        public GraphNode()
//        { }
//        public GraphNode(T value) : base(value) { }
//        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

//        public new NodeList<T> Neighbors => base.Neighbors ?? (base.Neighbors = new NodeList<T>());
//    }

//    public class Node<T>
//    {
//        public T Value { get; set; }
//        protected NodeList<T> Neighbors { get; set; }

//        public Node() { }

//        public Node(T data) : this(data, null) { }

//        public Node(T data, NodeList<T> neighbors)
//        {
//            Value = data;
//            Neighbors = neighbors;
//        }

//    }

//    public class NodeList<T> : Collection<Node<T>>
//    {
//        public NodeList() { }

//        public NodeList(int initialSize)
//        {
//            // Add the specified number of items
//            for (int i = 0; i < initialSize; i++)
//                Items.Add(default(Node<T>));
//        }

//        public Node<T> FindByValue(T value)
//        {
//            // search the list for the value
//            return Items.FirstOrDefault(node => node.Value.Equals(value));
//        }
//    }

//}

