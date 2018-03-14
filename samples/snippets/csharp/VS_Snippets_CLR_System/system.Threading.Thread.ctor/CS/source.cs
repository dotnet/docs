// <Snippet1>
using System;
using System.Threading;

class Test
{
    static void Main() 
    {
        Thread newThread = 
            new Thread(new ThreadStart(Work.DoWork));
        newThread.Start();
    }
}

class Work 
{
    Work() {}

    public static void DoWork() {}
}
// </Snippet1>