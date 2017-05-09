// <Snippet1>
using System;
using System.Threading;

class Example
{
    static void Main()
    {
        BackgroundTest shortTest = new BackgroundTest(10);
        Thread foregroundThread = 
            new Thread(new ThreadStart(shortTest.RunLoop));

        BackgroundTest longTest = new BackgroundTest(50);
        Thread backgroundThread = 
            new Thread(new ThreadStart(longTest.RunLoop));
        backgroundThread.IsBackground = true;

        foregroundThread.Start();
        backgroundThread.Start();
    }
}

class BackgroundTest
{
    int maxIterations;

    public BackgroundTest(int maxIterations)
    {
        this.maxIterations = maxIterations;
    }

    public void RunLoop()
    {
        for (int i = 0; i < maxIterations; i++) {
            Console.WriteLine("{0} count: {1}", 
                Thread.CurrentThread.IsBackground ? 
                   "Background Thread" : "Foreground Thread", i);
            Thread.Sleep(250);
        }
        Console.WriteLine("{0} finished counting.", 
                          Thread.CurrentThread.IsBackground ? 
                          "Background Thread" : "Foreground Thread");
    }
}
// The example displays output like the following:
//    Foreground Thread count: 0
//    Background Thread count: 0
//    Background Thread count: 1
//    Foreground Thread count: 1
//    Foreground Thread count: 2
//    Background Thread count: 2
//    Foreground Thread count: 3
//    Background Thread count: 3
//    Background Thread count: 4
//    Foreground Thread count: 4
//    Foreground Thread count: 5
//    Background Thread count: 5
//    Foreground Thread count: 6
//    Background Thread count: 6
//    Background Thread count: 7
//    Foreground Thread count: 7
//    Background Thread count: 8
//    Foreground Thread count: 8
//    Foreground Thread count: 9
//    Background Thread count: 9
//    Background Thread count: 10
//    Foreground Thread count: 10
//    Background Thread count: 11
//    Foreground Thread finished counting.
// </Snippet1>