// <Snippet3>
using namespace System;
using namespace System::Threading;

ref class Example
{
private:
   [ThreadStatic] static double previous = 0.0;
   [ThreadStatic] static int perThreadCtr = 0;
   [ThreadStatic] static double perThreadTotal = 0.0;  
   static CancellationTokenSource^ source;
   static CountdownEvent^ countdown;
   static Object^ randLock;
   static Object^ numericLock;
   static Random^ rand;
   double totalValue = 0.0;
   int totalCount = 0;
   
public:
   Example()
   { 
      rand = gcnew Random();
      randLock = gcnew Object();
      numericLock = gcnew Object();
      countdown = gcnew CountdownEvent(1);
      source = gcnew CancellationTokenSource();
   } 

   void Execute()
   {   
      CancellationToken^ token = source->Token;

      for (int threads = 1; threads <= 10; threads++)
      {
         Thread^ newThread = gcnew Thread(gcnew ParameterizedThreadStart(this, &Example::GetRandomNumbers));
         newThread->Name = threads.ToString();
         newThread->Start(token);
      }
      this->GetRandomNumbers(token);
      
      countdown->Signal();
      // Make sure all threads have finished.
      countdown->Wait();

      Console::WriteLine("\nTotal random numbers generated: {0:N0}", totalCount);
      Console::WriteLine("Total sum of all random numbers: {0:N2}", totalValue);
      Console::WriteLine("Random number mean: {0:N4}", totalValue/totalCount);
   }

private:
   void GetRandomNumbers(Object^ o)
   {
      CancellationToken^ token = (CancellationToken) o;
      double result = 0.0;
      countdown->AddCount(1);
         
      try { 
         for (int ctr = 0; ctr < 2000000; ctr++)
         {
            // Make sure there's no corruption of Random.
            token->ThrowIfCancellationRequested();

            Monitor::Enter(randLock);
            result = rand->NextDouble();
            Monitor::Exit(randLock);
            // Check for corruption of Random instance.
            if ((result == previous) && result == 0) {
               source->Cancel();
            }
            else {
               previous = result;
            }
            perThreadCtr++;
            perThreadTotal += result;
         }      
       
         Console::WriteLine("Thread {0} finished execution.", 
                           Thread::CurrentThread->Name);
         Console::WriteLine("Random numbers generated: {0:N0}", perThreadCtr);
         Console::WriteLine("Sum of random numbers: {0:N2}", perThreadTotal);
         Console::WriteLine("Random number mean: {0:N4}\n", perThreadTotal/perThreadCtr);

         // Update overall totals.
         Monitor::Enter(numericLock);
         totalCount += perThreadCtr;
         totalValue += perThreadTotal;  
         Monitor::Exit(numericLock);
      }
      catch (OperationCanceledException^ e) {
         Console::WriteLine("Corruption in Thread {1}", e->GetType()->Name,
                            Thread::CurrentThread->Name);
      }
      finally {
         countdown->Signal();
      }
   }
};

void main()
{
   Example^ ex = gcnew Example();
   Thread::CurrentThread->Name = "Main";
   ex->Execute();
}
// The example displays output like the following:
//       Thread 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,491.05
//       Random number mean: 0.5002
//       
//       Thread 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,329.64
//       Random number mean: 0.4997
//       
//       Thread 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,166.89
//       Random number mean: 0.5001
//       
//       Thread 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,628.37
//       Random number mean: 0.4998
//       
//       Thread Main finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,920.89
//       Random number mean: 0.5000
//       
//       Thread 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,370.45
//       Random number mean: 0.4997
//       
//       Thread 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,330.92
//       Random number mean: 0.4997
//       
//       Thread 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,172.79
//       Random number mean: 0.5001
//       
//       Thread 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,079.43
//       Random number mean: 0.5000
//       
//       Thread 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,817.91
//       Random number mean: 0.4999
//       
//       Thread 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,930.63
//       Random number mean: 0.5000
//       
//       
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 10,998,238.98
//       Random number mean: 0.4999
// </Snippet3>
