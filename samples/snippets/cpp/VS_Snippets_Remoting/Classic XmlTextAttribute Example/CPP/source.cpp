

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml::Serialization;
using namespace System::IO;

public ref class Group1
{
public:

   // The XmlTextAttribute with type set to string informs the 
   // XmlSerializer that strings should be serialized as XML text.

   [XmlText(String::typeid)]
   [XmlElement(Int32::typeid)]
   [XmlElement(Double::typeid)]
   array<Object^>^All;
   Group1()
   {
      array<Object^>^temp = {321,"One",2,3.0,"Two"};
      All = temp;
   }
};

public enum class GroupType
{
   Small, Medium, Large
};

public ref class Group2
{
public:

   [XmlText(Type=GroupType::typeid)]
   GroupType Type;
};

public ref class Group3
{
public:

   [XmlText(Type=DateTime::typeid)]
   DateTime CreationTime;
   Group3()
   {
      CreationTime = DateTime::Now;
   }
};

public ref class Test
{
public:
   static void main()
   {
      Test^ t = gcnew Test;
      t->SerializeArray( "XmlText1.xml" );
      t->SerializeEnum( "XmlText2.xml" );
      t->SerializeDateTime( "XmlText3.xml" );
   }

private:
   void SerializeArray( String^ filename )
   {
      XmlSerializer^ ser = gcnew XmlSerializer( Group1::typeid );
      Group1^ myGroup1 = gcnew Group1;
      TextWriter^ writer = gcnew StreamWriter( filename );
      ser->Serialize( writer, myGroup1 );
      writer->Close();
   }

   void SerializeEnum( String^ filename )
   {
      XmlSerializer^ ser = gcnew XmlSerializer( Group2::typeid );
      Group2^ myGroup = gcnew Group2;
      myGroup->Type = GroupType::Medium;
      TextWriter^ writer = gcnew StreamWriter( filename );
      ser->Serialize( writer, myGroup );
      writer->Close();
   }

   void SerializeDateTime( String^ filename )
   {
      XmlSerializer^ ser = gcnew XmlSerializer( Group3::typeid );
      Group3^ myGroup = gcnew Group3;
      TextWriter^ writer = gcnew StreamWriter( filename );
      ser->Serialize( writer, myGroup );
      writer->Close();
   }
};

int main()
{
   Test::main();
}
// </Snippet1>
