

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

/* Three classes are included here. Each one will
be used to create three XmlSerializer objects. */
public ref class Instrument
{
public:
   String^ InstrumentName;
};

public ref class Player
{
public:
   String^ PlayerName;
};

public ref class Piece
{
public:
   String^ PieceName;
};

void GetSerializers()
{
   // Create an array of types.
   array<Type^>^types = gcnew array<Type^>(3);
   types[ 0 ] = Instrument::typeid;
   types[ 1 ] = Player::typeid;
   types[ 2 ] = Piece::typeid;

   // Create an array for XmlSerializer objects.
   array<XmlSerializer^>^serializers = gcnew array<XmlSerializer^>(3);
   serializers = XmlSerializer::FromTypes( types );

   // Create one Instrument and serialize it.
   Instrument^ i = gcnew Instrument;
   i->InstrumentName = "Piano";

   // Create a TextWriter to write with.
   TextWriter^ writer = gcnew StreamWriter( "Inst.xml" );
   serializers[ 0 ]->Serialize( writer, i );
   writer->Close();
}

int main()
{
   GetSerializers();
}
// </Snippet1>
