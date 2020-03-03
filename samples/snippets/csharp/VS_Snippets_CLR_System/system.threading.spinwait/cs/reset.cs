//<snippet01>
using System;
using System.Threading;

public class LockFreeStack<T>
{
    private volatile Node m_head;
    private class Node { public Node Next; public T Value; }
    public void Push(T item)
    {
        var spin = new SpinWait();
        Node node = new Node { Value = item }, head;
        while (true)
        {
            head = m_head;
            node.Next = head;
            if (Interlocked.CompareExchange(ref m_head, node, head) == head) break;
            spin.SpinOnce();
        }
    }
    public bool TryPop(out T result)
    {
        result = default(T);
        var spin = new SpinWait();
        Node head;
        while (true)
        {
            head = m_head;
            if (head == null) return false;
            if (Interlocked.CompareExchange(ref m_head, head.Next, head) == head)
            {
                result = head.Value;
                return true;
            }
            spin.SpinOnce();
        }
    }
}
//</snippet01>
