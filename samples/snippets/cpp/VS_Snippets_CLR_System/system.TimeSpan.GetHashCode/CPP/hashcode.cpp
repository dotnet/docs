
//<Snippet1>
// Example for the TimeSpan::GetHashCode( ) method.
using namespace System;
void DisplayHashCode( TimeSpan interval )
{
   
   // Create a hash code and a string representation of 
   // the TimeSpan parameter.
   String^ timeInterval = interval.ToString();
   int hashCode = interval.GetHashCode();
   
   // Pad the end of the TimeSpan string with spaces if it 
   // does not contain milliseconds.
   int pIndex = timeInterval->IndexOf( ':' );
   pIndex = timeInterval->IndexOf( '.', pIndex );
   if ( pIndex < 0 )
      timeInterval = String::Concat( timeInterval, "        " );

   Console::WriteLine( "{0,22}   0x{1:X8}, {1}", timeInterval, hashCode );
}

int main()
{
   Console::WriteLine( "This example of TimeSpan::GetHashCode( ) generates "
   "the following \noutput, which displays "
   "the hash codes of representative TimeSpan \n"
   "objects in hexadecimal and decimal formats.\n" );
   Console::WriteLine( "{0,22}   {1,10}", "TimeSpan        ", "Hash Code" );
   Console::WriteLine( "{0,22}   {1,10}", "--------        ", "---------" );
   DisplayHashCode( TimeSpan(0) );
   DisplayHashCode( TimeSpan(1) );
   DisplayHashCode( TimeSpan(0,0,0,0,1) );
   DisplayHashCode( TimeSpan(0,0,1) );
   DisplayHashCode( TimeSpan(0,1,0) );
   DisplayHashCode( TimeSpan(1,0,0) );
   DisplayHashCode( TimeSpan(36000000001) );
   DisplayHashCode( TimeSpan(0,1,0,0,1) );
   DisplayHashCode( TimeSpan(1,0,1) );
   DisplayHashCode( TimeSpan(1,0,0,0) );
   DisplayHashCode( TimeSpan(864000000001) );
   DisplayHashCode( TimeSpan(1,0,0,0,1) );
   DisplayHashCode( TimeSpan(1,0,0,1) );
   DisplayHashCode( TimeSpan(100,0,0,0) );
   DisplayHashCode( TimeSpan(100,0,0,0,1) );
   DisplayHashCode( TimeSpan(100,0,0,1) );
}

/*
This example of TimeSpan::GetHashCode( ) generates the following
output, which displays the hash codes of representative TimeSpan
objects in hexadecimal and decimal formats.

      TimeSpan            Hash Code
      --------            ---------
      00:00:00           0x00000000, 0
      00:00:00.0000001   0x00000001, 1
      00:00:00.0010000   0x00002710, 10000
      00:00:01           0x00989680, 10000000
      00:01:00           0x23C34600, 600000000
      01:00:00           0x61C46808, 1640261640
      01:00:00.0000001   0x61C46809, 1640261641
      01:00:00.0010000   0x61C48F18, 1640271640
      01:00:01           0x625CFE88, 1650261640
    1.00:00:00           0x2A69C0C9, 711573705
    1.00:00:00.0000001   0x2A69C0C8, 711573704
    1.00:00:00.0010000   0x2A69E7D9, 711583705
    1.00:00:01           0x2B025649, 721573449
  100.00:00:00           0x914F4E94, -1857073516
  100.00:00:00.0010000   0x914F6984, -1857066620
  100.00:00:01           0x91E7D814, -1847076844
*/
//</snippet1>
