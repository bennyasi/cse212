using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    public bool Contains(int value) =>
        _root != null && _root.Contains(value);

    /// <summary>
    /// Yields all values in the tree (in-order traversal).
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        if (_root != null)
            foreach (var value in TraverseForward(_root))
                yield return value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<int> TraverseForward(Node node)
    {
        if (node.Left != null)
        {
            foreach (var val in TraverseForward(node.Left))
                yield return val;
        }

        yield return node.Data;

        if (node.Right != null)
        {
            foreach (var val in TraverseForward(node.Right))
                yield return val;
        }
    }

    /// <summary>
    /// Iterate backward through the BST (reverse in-order).
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        if (_root != null)
            foreach (var value in TraverseBackward(_root))
                yield return value;
    }

    private IEnumerable<int> TraverseBackward(Node node)
    {
        if (node.Right != null)
        {
            foreach (var val in TraverseBackward(node.Right))
                yield return val;
        }

        yield return node.Data;

        if (node.Left != null)
        {
            foreach (var val in TraverseBackward(node.Left))
                yield return val;
        }
    }

    /// <summary>
    /// Get the height of the tree.
    /// </summary>
    public int GetHeight() =>
        _root?.GetHeight() ?? 0;

    public override string ToString() =>
        "<Bst>{" + string.Join(", ", this) + "}";
}

// Helper node class
internal class Node
{
    public int Data { get; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data)
            return Left?.Contains(value) ?? false;
        else
            return Right?.Contains(value) ?? false;
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable<int> array) =>
        "<IEnumerable>{" + string.Join(", ", array) + "}";
}
