void MyMethod( Object^ obj, Type^ type )
{
   #if defined(DEBUG)
   Debug::Assert( type != nullptr, "Type paramater is null", "Can't get object for null type" );
   #endif
}