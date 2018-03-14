// <Snippet1>
using System;
using System.Threading;

class Test
{
    static void Main() 
    {
        Work threadWork = new Work();
        Thread newThread = 
            new Thread(new ThreadStart(threadWork.DoWork));
        newThread.Start();
    }
}

class Work 
{
    public Work() {}

    public void DoWork() {}
}
// </Snippet1>