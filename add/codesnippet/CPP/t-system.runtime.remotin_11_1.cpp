// Context-bound type with the Synchronization context attribute.

[Synchronization]
public ref class SampleSynchronized: public ContextBoundObject
{
public:

   // A method that does some work, and returns the square of the given number.
   int Square( int i )
   {
      Console::Write( "The hash of the thread executing " );
      Console::WriteLine( "SampleSynchronized::Square is: {0}", Thread::CurrentThread->GetHashCode() );
      return i * i;
   }

};