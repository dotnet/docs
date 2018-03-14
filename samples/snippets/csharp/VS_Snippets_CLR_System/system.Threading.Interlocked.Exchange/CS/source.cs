// <Snippet1>
using System;
using System.Threading;

class AtomicTest
{
    static void Main()
    {
        AtomicExchange atomicExchange = new AtomicExchange();
        Thread firstThread = 
            new Thread(new ThreadStart(atomicExchange.Switch));
        firstThread.Start();
    }
}

class AtomicExchange
{
    class SomeType{}

    // To use Interlocked.Exchange, someType1 
    // must be declared as type Object.
    object   someType1;
    SomeType someType2;

    public AtomicExchange() 
    {
        someType1 = new SomeType();
        someType2 = new SomeType();
    }

    public void Switch()
    {
        someType2 = (SomeType)Interlocked.Exchange(
            ref someType1, (object)someType2);
    }
}
// </Snippet1>