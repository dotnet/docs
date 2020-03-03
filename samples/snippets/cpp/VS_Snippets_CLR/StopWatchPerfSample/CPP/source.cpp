

// System.Diagnostics.Stopwatch
//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

//<Snippet2>
void DisplayTimerProperties()
{
   // Display the timer frequency and resolution.
   if ( Stopwatch::IsHighResolution )
   {
      Console::WriteLine( "Operations timed using the system's high-resolution performance counter." );
   }
   else
   {
      Console::WriteLine( "Operations timed using the DateTime class." );
   }

   Int64 frequency = Stopwatch::Frequency;
   Console::WriteLine( "  Timer frequency in ticks per second = {0}", frequency );
   Int64 nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
   Console::WriteLine( "  Timer is accurate within {0} nanoseconds", nanosecPerTick );
}
//</Snippet2>

//<Snippet3>
void TimeOperations()
{
   Int64 nanosecPerTick = (1000L * 1000L * 1000L) / Stopwatch::Frequency;
   const long numIterations = 10000;
   
   // Define the operation title names.
   array<String^>^operationNames = {"Operation: Int32.Parse(\"0\")","Operation: Int32.TryParse(\"0\")","Operation: Int32.Parse(\"a\")","Operation: Int32.TryParse(\"a\")"};
   
   // Time four different implementations for parsing 
   // an integer from a string. 
   for ( int operation = 0; operation <= 3; operation++ )
   {
      // <Snippet5>
      // Define variables for operation statistics.
      Int64 numTicks = 0;
      Int64 numRollovers = 0;
      Int64 maxTicks = 0;
      Int64 minTicks = Int64::MaxValue;
      int indexFastest = -1;
      int indexSlowest = -1;
      Int64 milliSec = 0;
      Stopwatch ^ time10kOperations = Stopwatch::StartNew();
      
      // Run the current operation 10001 times.
      // The first execution time will be tossed
      // out, since it can skew the average time.
      for ( int i = 0; i <= numIterations; i++ )
      {
         // <Snippet4>
         Int64 ticksThisTime = 0;
         int inputNum;
         Stopwatch ^ timePerParse;
         switch ( operation )
         {
            case 0:
               
               // Parse a valid integer using
               // a try-catch statement.
               // Start a new stopwatch timer.
               timePerParse = Stopwatch::StartNew();
               try
               {
                  inputNum = Int32::Parse( "0" );
               }
               catch ( FormatException^ ) 
               {
                  inputNum = 0;
               }

               // Stop the timer, and save the
               // elapsed ticks for the operation.
               timePerParse->Stop();
               ticksThisTime = timePerParse->ElapsedTicks;
               break;

            case 1:
               
               // Parse a valid integer using
               // the TryParse statement.
               // Start a new stopwatch timer.
               timePerParse = Stopwatch::StartNew();
               if (  !Int32::TryParse( "0", inputNum ) )
               {
                  inputNum = 0;
               }
               
               // Stop the timer, and save the
               // elapsed ticks for the operation.
               timePerParse->Stop();
               ticksThisTime = timePerParse->ElapsedTicks;
               break;

            case 2:
               
               // Parse an invalid value using
               // a try-catch statement.
               // Start a new stopwatch timer.
               timePerParse = Stopwatch::StartNew();
               try
               {
                  inputNum = Int32::Parse( "a" );
               }
               catch ( FormatException^ ) 
               {
                  inputNum = 0;
               }

               // Stop the timer, and save the
               // elapsed ticks for the operation.
               timePerParse->Stop();
               ticksThisTime = timePerParse->ElapsedTicks;
               break;

            case 3:
               
               // Parse an invalid value using
               // the TryParse statement.
               // Start a new stopwatch timer.
               timePerParse = Stopwatch::StartNew();
               if (  !Int32::TryParse( "a", inputNum ) )
               {
                  inputNum = 0;
               }
               
               // Stop the timer, and save the
               // elapsed ticks for the operation.
               timePerParse->Stop();
               ticksThisTime = timePerParse->ElapsedTicks;
               break;

            default:
               break;
         }
         //</Snippet4>

         // Skip over the time for the first operation,
         // just in case it caused a one-time
         // performance hit.
         if ( i == 0 )
         {
            time10kOperations->Reset();
            time10kOperations->Start();
         }
         else
         {
            // Update operation statistics
            // for iterations 1-10001.
            if ( maxTicks < ticksThisTime )
            {
               indexSlowest = i;
               maxTicks = ticksThisTime;
            }
            if ( minTicks > ticksThisTime )
            {
               indexFastest = i;
               minTicks = ticksThisTime;
            }
            numTicks += ticksThisTime;
            if ( numTicks < ticksThisTime )
            {
               // Keep track of rollovers.
               numRollovers++;
            }
         }
      }
      
      // Display the statistics for 10000 iterations.
      time10kOperations->Stop();
      milliSec = time10kOperations->ElapsedMilliseconds;
      Console::WriteLine();
      Console::WriteLine( "{0} Summary:", operationNames[ operation ] );
      Console::WriteLine( "  Slowest time:  #{0}/{1} = {2} ticks", indexSlowest, numIterations, maxTicks );
      Console::WriteLine( "  Fastest time:  #{0}/{1} = {2} ticks", indexFastest, numIterations, minTicks );
      Console::WriteLine( "  Average time:  {0} ticks = {1} nanoseconds", numTicks / numIterations, (numTicks * nanosecPerTick) / numIterations );
      Console::WriteLine( "  Total time looping through {0} operations: {1} milliseconds", numIterations, milliSec );
      //</Snippet5>

   }
}
//</Snippet3>

int main()
{
   DisplayTimerProperties();
   Console::WriteLine();
   Console::WriteLine( "Press the Enter key to begin:" );
   Console::ReadLine();
   Console::WriteLine();
   TimeOperations();
}
//</Snippet1>
