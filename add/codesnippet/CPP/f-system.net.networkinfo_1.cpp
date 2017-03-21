PhysicalAddress^ StrictParseAddress( String^ address )
{
   PhysicalAddress^ newAddress = PhysicalAddress::Parse( address );
   if ( PhysicalAddress::None->Equals( newAddress ) )
      return nullptr;

   return newAddress;
}

