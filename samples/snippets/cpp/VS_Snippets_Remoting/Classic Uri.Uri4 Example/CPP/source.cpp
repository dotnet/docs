

#using <System.dll>

using namespace System;
void main()
{
   // <Snippet1>
   Uri^ baseUri = gcnew Uri( "http://www.contoso.com/" );
   Uri^ myUri = gcnew Uri( baseUri,"Hello%20World.htm",false );
   // </Snippet1>
}
