using System.Collections.Generic;

internal static class Collections
{
    // <UpdatePriority>
    public static void UpdatePriority<TElement, TPriority>(
        this PriorityQueue<TElement, TPriority> queue,
        TElement element,
        TPriority priority
        )
    {
        // Scan the heap for entries matching the current element.
        queue.Remove(element, out _, out _);
        // Re-insert the entry with the new priority.
        queue.Enqueue(element, priority);
    }
    // </UpdatePriority>
}
