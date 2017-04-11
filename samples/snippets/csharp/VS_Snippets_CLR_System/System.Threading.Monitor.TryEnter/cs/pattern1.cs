using System;
using System.Threading;

public class MonitorExamples
{
   // TryEnter(Object)
   public static void Overload1()
   {
      // <Snippet1>
      var lockObj = new Object();
      
      if (Monitor.TryEnter(lockObj)) {
         try {
            // The critical section.
         }
         finally {
            // Ensure that the lock is released.
            Monitor.Exit(lockObj);
         }
      }
      else {
         // The lock was not axquired.
      }
      // </Snippet1>   
   }
   
   // TryEnter(Object, Boolean)
   public static void Overload2()
   {
      // <Snippet2>
      var lockObj = new Object();
      bool lockTaken = false;
      
      try {
         Monitor.TryEnter(lockObj, ref lockTaken); 
         if (lockTaken) {
            // The critical section.
         }
         else {
            // The lock was not acquired.
         }
      }
      finally {
         // Ensure that the lock is released.
         if (lockTaken) {
            Monitor.Exit(lockObj);
         }
      }
      // </Snippet2>   
   }   

   // TryEnter(Object, Int32)
   public static void Overload3()
   {
      // <Snippet3>
      var lockObj = new Object();
      int timeout = 500;
      
      if (Monitor.TryEnter(lockObj, timeout)) {
         try {
            // The critical section.
         }
         finally {
            // Ensure that the lock is released.
            Monitor.Exit(lockObj);
         }
      }
      else {
         // The lock was not acquired.
      }
      // </Snippet3>   
   }
   
   // TryEnter(Object, Int32, Boolean)
   public static void Overload4()
   {
      // <Snippet4>
      var lockObj = new Object();
      int timeout = 500;
      bool lockTaken = false;
      
      try {
         Monitor.TryEnter(lockObj, timeout, ref lockTaken);
         if (lockTaken) {
            // The critical section.
         }
         else {
            // The lock was not acquired.
         }
      }
      finally {
         // Ensure that the lock is released.
         if (lockTaken) {
            Monitor.Exit(lockObj);
         }   
      }
      // </Snippet4>   
   }
   
   // TryEnter(Object, TimeSpan)
   public static void Overload5()
   {
      // <Snippet5>
      var lockObj = new Object();
      var timeout = TimeSpan.FromMilliseconds(500);
      
      if (Monitor.TryEnter(lockObj, timeout)) {
         try {
            // The critical section.
         }
         finally {
            // Ensure that the lock is released.
            Monitor.Exit(lockObj);
         }
      }
      else {
         // The lock was not acquired.
      }
      // </Snippet5>   
   }
   
   // TryEnter(Object, TimeSpan, Boolean)
   public static void Overload6()
   {
      // <Snippet6>
      var lockObj = new Object();
      var timeout = TimeSpan.FromMilliseconds(500);
      bool lockTaken = false;
      
      try {
         Monitor.TryEnter(lockObj, timeout, ref lockTaken);
         if (lockTaken) {
            // The critical section.
         }
         else {
            // The lock was not acquired.
         }
      }
      finally {
         // Ensure that the lock is released.
         if (lockTaken) {
            Monitor.Exit(lockObj);
         }
      }
      // </Snippet6>   
   }
}
