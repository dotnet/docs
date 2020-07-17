/*
This program demonstrates 'NetworkToHostOrder(short)', 'NetworkToHostOrder(int)' and
'NetworkToHostOrder(long)' methods of 'IPAddress' class.
It takes a String* from commandline for each of above cases and convert it to the corresponding
primitive type(i.e. short, int, long) value. Alternatively it uses default values for each cases.
Then these values are converted from  network Byte order to host Byte order by  calling the
overloaded 'NetworkToHostOrder' methods of 'IPAddress' class.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void NetworkToHostOrder_Short( short networkByte )
{
   short hostByte;
   // Converts a short value from network Byte order to host Byte order.
   hostByte = IPAddress::NetworkToHostOrder( networkByte );
   Console::WriteLine( "Network Byte order to Host Byte order of {0} is {1}", networkByte, hostByte );
}
// </Snippet1>

// <Snippet2>
void NetworkToHostOrder_Integer( int networkByte )
{
   int hostByte;
   // Converts an integer value from network Byte order to host Byte order.
   hostByte = IPAddress::NetworkToHostOrder( networkByte );
   Console::WriteLine( "Network Byte order to Host Byte order of {0} is {1}", networkByte, hostByte );
}
// </Snippet2>

// <Snippet3>
void NetworkToHostOrder_Long( __int64 networkByte )
{
   __int64 hostByte;
   // Converts a long value from network Byte order to host Byte order.
   hostByte = IPAddress::NetworkToHostOrder( networkByte );
   Console::WriteLine( "Network Byte order to Host Byte order of {0} is {1}", networkByte, hostByte );
}
// </Snippet3>

int main()
{
   try
   {
      short networkByteShort = 4365;
      int networkByteInt = 286064640;
      __int64 networkByteLong = 1228638273342013440I64;
      String^ networkByteString = "";

      Console::Write( "'Program converts Network Byte order to Host Byte order for short, int and long values'" );
      Console::Write( "\nEnter a short value for Convertion(press Enter for default, default is '4365') : " );
      networkByteString = Console::ReadLine();
      if ( networkByteString->Length > 0 )
            networkByteShort = Convert::ToInt16( networkByteString );
      NetworkToHostOrder_Short( networkByteShort );

      networkByteString = "";
      Console::Write( "\nEnter an Integer value for Convertion(press Enter for default, default is '286064640') : " );
      networkByteString = Console::ReadLine();
      if ( networkByteString->Length > 0 )
            networkByteInt = Convert::ToInt32( networkByteString );
      NetworkToHostOrder_Integer( networkByteInt );

      networkByteString = "";
      Console::Write( "\nEnter a long value for Convertion(press Enter for default, default is '1228638273342013440') : " );
      networkByteString = Console::ReadLine();
      if ( networkByteString->Length > 0 )
            networkByteLong = Convert::ToInt64( networkByteString );
      NetworkToHostOrder_Long( networkByteLong );
   }
   catch ( FormatException^ e ) 
   {
      Console::WriteLine( "FormatException caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
