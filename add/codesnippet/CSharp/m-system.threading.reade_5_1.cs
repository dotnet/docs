// The complete code is located in the ReaderWriterLock class topic.
using System;
using System.Threading;

public class Example
{
   static ReaderWriterLock rwl = new ReaderWriterLock();
   // Define the shared resource protected by the ReaderWriterLock.
   static int resource = 0;