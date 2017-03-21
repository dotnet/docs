void displayEndpointInfo( IPEndPoint^ endpoint )
{
   Console::WriteLine( "Endpoint->Address : {0}", endpoint->Address );
   Console::WriteLine( "Endpoint->AddressFamily : {0}", endpoint->AddressFamily );
   Console::WriteLine( "Endpoint->Port : {0}", endpoint->Port );
   Console::WriteLine( "Endpoint.ToString() : {0}", endpoint );
   Console::WriteLine( "Press any key to continue." );
   Console::ReadLine();
}