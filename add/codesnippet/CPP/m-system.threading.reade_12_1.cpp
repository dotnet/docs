// The complete code is located in the ReaderWriterLock
// class topic.
using namespace System;
using namespace System::Threading;
public ref class Test
{
public:

   // Declaring the ReaderWriterLock at the class level
   // makes it visible to all threads.
   static ReaderWriterLock^ rwl = gcnew ReaderWriterLock;

   // For this example, the shared resource protected by the
   // ReaderWriterLock is just an integer.
   static int resource = 0;
