void MyOnEntry( Object^ source, EntryWrittenEventArgs^ e )
{
   EventLogEntry^ myEventLogEntry = e->Entry;
   if ( myEventLogEntry )
   {
      Console::WriteLine( "Current message entry is: '{0}'", myEventLogEntry->Message );
   }
   else
   {
      Console::WriteLine( "The current entry is null" );
   }
}