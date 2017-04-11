
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      
      // Get the creation time of a well-known directory.
      DateTime dt = Directory::GetCreationTime( Environment::CurrentDirectory );
      
      // Give feedback to the user.
      if ( DateTime::Now.Subtract( dt ).TotalDays > 364 )
      {
         Console::WriteLine( "This directory is over a year old." );
      }
      else
      if ( DateTime::Now.Subtract( dt ).TotalDays > 30 )
      {
         Console::WriteLine( "This directory is over a month old." );
      }
      else
      if ( DateTime::Now.Subtract( dt ).TotalDays <= 1 )
      {
         Console::WriteLine( "This directory is less than a day old." );
      }
      else
      {
         Console::WriteLine( "This directory was created on {0}", dt );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
