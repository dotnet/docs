// <snippet1>
using System;
using System.Threading;

public class ThreadSafe
{
    // totalValue contains a running total that can be updated
    // by multiple threads. It must be protected from unsynchronized
    // access.
    private double totalValue = 0;

    // The Total property returns the running total.
    public double Total
    {
        get { return totalValue; }
    }

    // AddToTotal safely adds a value to the running total.
    public double AddToTotal(double addend)
    {
        double initialValue, computedValue;
        do
        {
            // Save the current running total in a local variable.
            initialValue = totalValue;

            // Add the new value to the running total.
            computedValue = initialValue + addend;

            // CompareExchange compares totalValue to initialValue. If
            // they are not equal, then another thread has updated the
            // running total since this loop started. CompareExchange
            // does not update totalValue. CompareExchange returns the
            // contents of totalValue, which do not equal initialValue,
            // so the loop executes again.
        }
        while (initialValue != Interlocked.CompareExchange(
            ref totalValue, computedValue, initialValue));
        // If no other thread updated the running total, then
        // totalValue and initialValue are equal when CompareExchange
        // compares them, and computedValue is stored in totalValue.
        // CompareExchange returns the value that was in totalValue
        // before the update, which is equal to initialValue, so the
        // loop ends.

        // The function returns computedValue, not totalValue, because
        // totalValue could be changed by another thread between
        // the time the loop ends and the function returns.
        return computedValue;
    }
}
// </snippet1>
