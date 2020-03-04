
//<snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   TextReader^ tIn = Console::In;
   TextWriter^ tOut = Console::Out;
   tOut->WriteLine( "Hola Mundo!" );
   tOut->Write( "What is your name: " );
   String^ name = tIn->ReadLine();
   tOut->WriteLine( "Buenos Dias, {0}!", name );
}

//</snippet1>
