//<Snippet1>
using System;
using System.Threading;

public class ThreadWork 
{
public static void DoWork()
   {
   Console.WriteLine("Working thread..."); 
   }
}

class ThreadStateTest
{
public static void Main()
   {
   ThreadStart myThreadDelegate = new ThreadStart(ThreadWork.DoWork);
   Thread myThread = new Thread(myThreadDelegate);
   myThread.Start();
   Thread.Sleep(0);
   Console.WriteLine("In main. Attempting to restart myThread.");
   try 
      {
      myThread.Start();
      }
      catch(ThreadStateException e)
      {
      Console.WriteLine("Caught: {0}", e.Message);
      }
   }
}
//</Snippet1>