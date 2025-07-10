using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class PriorityItem
    {
        public string Value { get; }
        public int Priority { get; }

        public PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }

    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Enqueue adds item with priority to the end of the list
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    /// <summary>
    /// Dequeue removes the item with the highest priority.
    /// If multiple items have same priority, it removes the first one (FIFO).
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        int highestPriority = _queue[0].Priority;
        int indexToRemove = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > highestPriority)
            {
                highestPriority = _queue[i].Priority;
                indexToRemove = i;
            }
        }

        string result = _queue[indexToRemove].Value;
        _queue.RemoveAt(indexToRemove);
        return result;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
