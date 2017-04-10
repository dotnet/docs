//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Threading;
using namespace System::Collections::Generic;
using namespace System::Text;

generic <typename T> public ref class SafeQueue
{
private:
   //<Snippet3>
   //<Snippet2>
   // A queue that is protected by Monitor.
   Queue<T>^ m_inputQueue;
   //</Snippet2>

public:
   SafeQueue()
   {
      m_inputQueue = gcnew Queue<T>();
   };

   // Lock the queue and add an element.
   void Enqueue(T qValue)
   {
      // Request the lock, and block until it is obtained.
      Monitor::Enter(m_inputQueue);
      try
      {
         // When the lock is obtained, add an element.
         m_inputQueue->Enqueue(qValue);
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor::Exit(m_inputQueue);
      }
   };
   //</Snippet3>

   //<Snippet4>
   // Try to add an element to the queue: Add the element to the queue 
   // only if the lock is immediately available.
   bool TryEnqueue(T qValue)
   {
      // Request the lock.
      if (Monitor::TryEnter(m_inputQueue))
      {
         try
         {
            m_inputQueue->Enqueue(qValue);
         }
         finally
         {
            // Ensure that the lock is released.
            Monitor::Exit(m_inputQueue);
         }
         return true;
      }
      else
      {
         return false;
      }
   };
   //</Snippet4>

   //<Snippet5>
   // Try to add an element to the queue: Add the element to the queue 
   // only if the lock becomes available during the specified time
   // interval.
   bool TryEnqueue(T qValue, int waitTime)
   {
      // Request the lock.
      if (Monitor::TryEnter(m_inputQueue, waitTime))
      {
         try
         {
            m_inputQueue->Enqueue(qValue);
         }
         finally
         {
            // Ensure that the lock is released.
            Monitor::Exit(m_inputQueue);
         }
         return true;
      }
      else
      {
         return false;
      }
   };
   //</Snippet5>

   // Lock the queue and dequeue an element.
   T Dequeue()
   {
      T retval;

      // Request the lock, and block until it is obtained.
      Monitor::Enter(m_inputQueue);
      try
      {
         // When the lock is obtained, dequeue an element.
         retval = m_inputQueue->Dequeue();
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor::Exit(m_inputQueue);
      }

      return retval;
   };

   // Delete all elements that equal the given object.
   int Remove(T qValue)
   {
      int removedCt = 0;

      // Wait until the lock is available and lock the queue.
      Monitor::Enter(m_inputQueue);
      try
      {
         int counter = m_inputQueue->Count;
         while (counter > 0)
            // Check each element.
         {
            T elem = m_inputQueue->Dequeue();
            if (!elem->Equals(qValue))
            {
               m_inputQueue->Enqueue(elem);
            }
            else
            {
               // Keep a count of items removed.
               removedCt += 1;
            }
            counter = counter - 1;
         }
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor::Exit(m_inputQueue);
      }

      return removedCt;
   };

   // Print all queue elements.
   String^ PrintAllElements()
   {
      StringBuilder^ output = gcnew StringBuilder();

      // Lock the queue.
      Monitor::Enter(m_inputQueue);
      try
      {
         for each ( T elem in m_inputQueue )
         {
            // Print the next element.
            output->AppendLine(elem->ToString());
         }
      }
      finally
      {
         // Ensure that the lock is released.
         Monitor::Exit(m_inputQueue);
      }

      return output->ToString();
   };
};

public ref class Example
{
private:
   static SafeQueue<int>^ q = gcnew SafeQueue<int>();
   static int threadsRunning = 0;
   static array<array<int>^>^ results = gcnew array<array<int>^>(3);

   static void ThreadProc(Object^ state)
   {
      DateTime finish = DateTime::Now.AddSeconds(10);
      Random^ rand = gcnew Random();
      array<int>^ result = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      int threadNum = (int) state;

      while (DateTime::Now < finish)

      {
         int what = rand->Next(250);
         int how = rand->Next(100);

         if (how < 16)
         {
            q->Enqueue(what);
            result[(int)ThreadResultIndex::EnqueueCt] += 1;
         }
         else if (how < 32)
         {
            if (q->TryEnqueue(what))
            {
               result[(int)ThreadResultIndex::TryEnqueueSucceedCt] += 1;
            }
            else
            {
               result[(int)ThreadResultIndex::TryEnqueueFailCt] += 1;
            }
         }
         else if (how < 48)
         {
            // Even a very small wait significantly increases the success 
            // rate of the conditional enqueue operation.
            if (q->TryEnqueue(what, 10))
            {
               result[(int)ThreadResultIndex::TryEnqueueWaitSucceedCt] += 1;
            }
            else
            {
               result[(int)ThreadResultIndex::TryEnqueueWaitFailCt] += 1;
            }
         }
         else if (how < 96)
         {
            result[(int)ThreadResultIndex::DequeueCt] += 1;
            try
            {
               q->Dequeue();
            }
            catch (Exception^ ex)
            {
               result[(int)ThreadResultIndex::DequeueExCt] += 1;
            }
         }
         else
         {
            result[(int)ThreadResultIndex::RemoveCt] += 1;
            result[(int)ThreadResultIndex::RemovedCt] += q->Remove(what);
         }         
      }

      results[threadNum] = result;

      if (0 == Interlocked::Decrement(threadsRunning))      
      {
         StringBuilder^ sb = gcnew StringBuilder(
            "                               Thread 1 Thread 2 Thread 3    Total\n");

         for (int row = 0; row < 9; row++)
         {
            int total = 0;
            sb->Append(titles[row]);

            for(int col = 0; col < 3; col++)
            {
               sb->Append(String::Format("{0,9}", results[col][row]));
               total += results[col][row];
            }

            sb->AppendLine(String::Format("{0,9}", total));
         }

         Console::WriteLine(sb->ToString());
      }
   };

   static array<String^>^ titles = {
      "Enqueue                       ", 
      "TryEnqueue succeeded          ", 
      "TryEnqueue failed             ", 
      "TryEnqueue(T, wait) succeeded ", 
      "TryEnqueue(T, wait) failed    ", 
      "Dequeue attempts              ", 
      "Dequeue exceptions            ", 
      "Remove operations             ", 
      "Queue elements removed        "};

   enum class ThreadResultIndex
   {
      EnqueueCt, 
      TryEnqueueSucceedCt, 
      TryEnqueueFailCt, 
      TryEnqueueWaitSucceedCt, 
      TryEnqueueWaitFailCt, 
      DequeueCt, 
      DequeueExCt, 
      RemoveCt, 
      RemovedCt
   };

public:
   static void Demo()
   {
      Console::WriteLine("Working...");

      for(int i = 0; i < 3; i++)
      {
         Thread^ t = gcnew Thread(gcnew ParameterizedThreadStart(Example::ThreadProc));
         t->Start(i);
         Interlocked::Increment(threadsRunning);
      }
   };
};

void main()
{
   Example::Demo();
}


/* This example produces output similar to the following:

Working...
                               Thread 1 Thread 2 Thread 3    Total
Enqueue                          274718   513514   337895  1126127
TryEnqueue succeeded             274502   513516   337480  1125498
TryEnqueue failed                   119      235      141      495
TryEnqueue(T, wait) succeeded    274552   513116   338532  1126200
TryEnqueue(T, wait) failed            0        1        0        1
Dequeue attempts                 824038  1541866  1015006  3380910
Dequeue exceptions                12828    23416    14799    51043
Remove operations                 68746   128218    84306   281270
Queue elements removed            11464    22024    14470    47958
Queue elements removed            2921     4690     2982    10593
 */
//</snippet1>



