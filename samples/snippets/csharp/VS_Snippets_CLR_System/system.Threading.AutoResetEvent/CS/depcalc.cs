//<snippet2>
using System;
using System.Threading;

class TermInfo
{
    public int[] terms;
    public int order;
    public int baseValue;
    public AutoResetEvent trigger;
}

class DepCalc
{
    private const int numTerms = 3;

    public static void Main()
    {
        AutoResetEvent trigger = new AutoResetEvent(false);
        TermInfo tinfo = new TermInfo();
        Thread termThread;
        int[] terms = new int[numTerms];
        int result = 0;

        tinfo.terms = terms;
        tinfo.trigger = trigger;

        for (int i = 0; i < numTerms; i++)
        {
            tinfo.order = i;
            //Create and start the term calc thread.
            termThread = new Thread(TermThreadProc);
            termThread.Start(tinfo);
            // simulate a number crunching delay
            Thread.Sleep(1000);
            tinfo.baseValue = DateTime.Now.Millisecond;
            trigger.Set();
            termThread.Join();
            result += terms[i];
        }

        Console.WriteLine("Result = {0}", result);
    }

    private static void TermThreadProc(object data)
    {
        TermInfo tinfo = (TermInfo)data;

        Console.WriteLine("Term[{0}] is starting...", tinfo.order);
        // set the precalculation
        int preValue = DateTime.Now.Millisecond + tinfo.order;

        // wait for base value to be ready
        tinfo.trigger.WaitOne();
        Random rnd = new Random(tinfo.baseValue);

        tinfo.terms[tinfo.order] = preValue * rnd.Next(10000);
        Console.WriteLine("Term[{0}] has finished with a value of: {1}",
            tinfo.order, tinfo.terms[tinfo.order]);
    }
}
//</snippet2>
