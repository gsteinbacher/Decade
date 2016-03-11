using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Obacher.Decade.Tree
{
    public class TreeNode<T>
    {
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode<T> this[int i] => _children[i];

        public TreeNode<T> Previous { get; private set; }

        public T Value { get; }

        public ReadOnlyCollection<TreeNode<T>> Children => _children.AsReadOnly();

        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Previous = this };
            _children.Add(node);
            return node;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }

        public void Traverse(Action<T> action)
        {
            action(Value);
            foreach (var child in _children)
                child.Traverse(action);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(_children.SelectMany(x => x.Flatten()));
        }
    }
}


//using System;
//using System.Collections.Generic;

//namespace Obacher.Decade.Tree
//{
//    public class TreeList<T>
//    {
//        private readonly IList<TreeNode<T>> _tree = new List<TreeNode<T>>();
//        private readonly IEqualityComparer<T> _comparer;

//        /// <summary>
//        /// Initializes a new instance of <see cref="TreeList{T}"/>
//        /// </summary>
//        public TreeList() : this(null, EqualityComparer<T>.Default)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of <see cref="TreeList{T}"/>
//        /// </summary>
//        /// <param name="collection">Collection of objects that will be added to linked list</param>
//        public TreeList(IEnumerable<T> collection)
//            : this(collection, EqualityComparer<T>.Default)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of <see cref="TreeList{T}"/>
//        /// </summary>
//        /// <param name="comparer">Comparer used for item comparison</param>
//        /// <exception cref="ArgumentNullException">comparer is null</exception>
//        public TreeList(IEqualityComparer<T> comparer)
//            : this(null, comparer)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of <see cref="TreeList{T}"/>
//        /// </summary>
//        /// <param name="collection">Collection of objects that will be added to linked list</param>
//        /// <param name="comparer">Comparer used for item comparison</param>
//        public TreeList(IEnumerable<T> collection, IEqualityComparer<T> comparer)
//        {
//            if (comparer == null)
//                throw new ArgumentNullException(nameof(comparer));

//            _comparer = comparer;
//            if (collection != null)
//            {
//                foreach (T item in collection)
//                    AddLast(item);
//            }
//        }

//        /// <summary>
//        /// Gets Tail node. Returns NULL if no tail node found
//        /// </summary>
//        public TreeNode<T> Tail { get; private set; }

//        /// <summary>
//        /// Gets the head node. Returns NULL if no node found
//        /// </summary>
//        public TreeNode<T> Head { get; private set; }

//        /// <summary>
//        /// Gets total number of items in the list
//        /// </summary>
//        public int Count { get; private set; }


//        /// <summary>
//        /// Add a new item to the end of the list
//        /// </summary>
//        /// <param name="item">Item to be added</param>
//        public void AddLast(T item)
//        {
//            // if head is null, then this will be the first item
//            if (Head == null)
//                AddFirstItem(item);
//            else
//            {
//                var newNode = new TreeNode<T>(item);
//                Tail.Next = newNode;
//                newNode.Next = Head;
//                newNode.Previous = Tail;
//                Tail = newNode;
//                Head.Previous = Tail;
//            }
//            ++Count;
//        }

//        private void AddFirstItem(T item)
//        {
//            Head = new TreeNode<T>(item);
//            Tail = Head;
//            Head.Next = Tail;
//            Head.Previous = Tail;
//        }

//        public void AddChild(T item)
//        {
//            Tail.Children.Add(item);
//        }
//    }

//    public sealed class TreeNode<T>
//    {
//        public T Value { get; }

//        public TreeNode<T> Next { get; internal set; }
//        public TreeNode<T> Previous { get; internal set; }
//        public IList<TreeNode<T>> Children { get; internal set; }

//        /// <summary>
//        /// Initializes a new <cref>Node</cref> instance
//        /// </summary>
//        /// <param name="item">Value to be assigned</param>
//        internal TreeNode(T item)
//        {
//            Value = item;
//        }
//    }
//}
