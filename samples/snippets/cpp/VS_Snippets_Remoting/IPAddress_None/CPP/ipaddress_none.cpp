

/*
This program demonstrates the 'None' field of 'IPAddress' class.
Provides an IP address indicating that no network interface should be used.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
int main()
{
   
   // Gets the IP address indicating that no network interface should be used
   // and converts it to a String*.
   String^ address = IPAddress::None->ToString();
   Console::WriteLine( "IP address : {0}", address );
}

// </Snippet1>
