// <Snippet1>
using System;
using System.Threading;
using Timers = System.Timers;

class Test
{
    static void Main()
    {
        PriorityTest priorityTest = new PriorityTest();

        Thread thread1 = new Thread(priorityTest.ThreadMethod);
        thread1.Name = "ThreadOne";
        Thread thread2 = new Thread(priorityTest.ThreadMethod);
        thread2.Name = "ThreadTwo";
        thread2.Priority = ThreadPriority.BelowNormal;
        Thread thread3 = new Thread(priorityTest.ThreadMethod);
        thread3.Name = "ThreadThree";
        thread3.Priority = ThreadPriority.AboveNormal;

        thread1.Start();
        thread2.Start();
        thread3.Start();
        // Allow counting for 10 seconds.
        Thread.Sleep(10000);
        priorityTest.LoopSwitch = false;
    }
}

class PriorityTest
{
    static bool loopSwitch;
    [ThreadStatic] static long threadCount = 0;

    public PriorityTest()
    {
        loopSwitch = true;
    }

    public bool LoopSwitch
    {
        set{ loopSwitch = value; }
    }

    public void ThreadMethod()
    {
        while(loopSwitch)
        {
            threadCount++;
        }
        Console.WriteLine("{0,-11} with {1,11} priority " +
            "has a count = {2,13}", Thread.CurrentThread.Name, 
            Thread.CurrentThread.Priority.ToString(), 
            threadCount.ToString("N0")); 
    }
}
// The example displays output like the following:
//    ThreadOne   with      Normal priority has a count =   755,897,581
//    ThreadThree with AboveNormal priority has a count =   778,099,094
//    ThreadTwo   with BelowNormal priority has a count =     7,840,984
// </Snippet1>

