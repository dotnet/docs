void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC, PerformanceCounter^ BPC )
{
   Random^ r = gcnew Random( DateTime::Now.Millisecond );

   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      int value = r->Next( 1, 10 );
      Console::Write( "{0} = {1}", j, value );
      PC->IncrementBy( value );
      BPC->Increment();
      if ( (j % 10) == 9 )
      {
         OutputSample( PC->NextSample() );
         samplesList->Add( PC->NextSample() );
      }
      else
            Console::WriteLine();
      System::Threading::Thread::Sleep( 50 );
   }
}