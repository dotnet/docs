      String^ myLog = "myNewLog";
      if ( EventLog::Exists( myLog ) )
      {
         Console::WriteLine( "Log '{0}' exists.", myLog );
      }
      else
      {
         Console::WriteLine( "Log '{0}' does not exist.", myLog );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}
