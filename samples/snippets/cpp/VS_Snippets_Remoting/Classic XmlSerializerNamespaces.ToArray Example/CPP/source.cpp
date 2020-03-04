#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Sample
{
   // <Snippet1>
private:
   void PrintNamespacePairs( XmlSerializerNamespaces^ namespaces )
   {
      array<XmlQualifiedName^>^ qualifiedNames = namespaces->ToArray();
      for ( int i = 0; i < qualifiedNames->Length; i++ )
      {
         Console::WriteLine( "{0}\t{1}",
            qualifiedNames[ i ]->Name, qualifiedNames[ i ]->Namespace );
      }
   }
   // </Snippet1>
};
