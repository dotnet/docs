// Context-bound type with the Synchronization context attribute.
[Synchronization()]
public class SampleSynchronized : ContextBoundObject {

    // A method that does some work, and returns the square of the given number.
    public int Square(int i)  {

        Console.Write("The hash of the thread executing ");
        Console.WriteLine("SampleSynchronized.Square is: {0}", 
                             Thread.CurrentThread.GetHashCode());
        return i*i;
    }
}