

// <Snippet1>
// Beginning of HighSchool.dll
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

namespace HighSchool
{
   public ref class Student
   {
   public:
      String^ Name;
      int ID;
   };

   public ref class MyClass
   {
   public:
      array<Student^>^Students;
   };
}

namespace College
{

using namespace HighSchool;
   public ref class Graduate: public HighSchool::Student
   {
   public:
      Graduate(){}

      // Add a new field named University.
      String^ University;
   };

   public ref class Run
   {
   public:
      static void main()
      {
         Run^ test = gcnew Run;
         test->WriteOverriddenAttributes( "College.xml" );
         test->ReadOverriddenAttributes( "College.xml" );
      }

   private:
      void WriteOverriddenAttributes( String^ filename )
      {
         // Writing the file requires a TextWriter.
         TextWriter^ myStreamWriter = gcnew StreamWriter( filename );

         // Create an XMLAttributeOverrides class.
         XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;

         // Create the XmlAttributes class.
         XmlAttributes^ attrs = gcnew XmlAttributes;

         /* Override the Student class. "Alumni" is the name
               of the overriding element in the XML output. */
         XmlElementAttribute^ attr = gcnew XmlElementAttribute( "Alumni",Graduate::typeid );

         /* Add the XmlElementAttribute to the collection of
               elements in the XmlAttributes object. */
         attrs->XmlElements->Add( attr );

         /* Add the XmlAttributes to the XmlAttributeOverrides. 
               "Students" is the name being overridden. */
         attrOverrides->Add( HighSchool::MyClass::typeid, "Students", attrs );

         // Create the XmlSerializer. 
         XmlSerializer^ mySerializer = gcnew XmlSerializer( HighSchool::MyClass::typeid,attrOverrides );
         MyClass ^ myClass = gcnew MyClass;
         Graduate^ g1 = gcnew Graduate;
         g1->Name = "Jackie";
         g1->ID = 1;
         g1->University = "Alma Mater";
         Graduate^ g2 = gcnew Graduate;
         g2->Name = "Megan";
         g2->ID = 2;
         g2->University = "CM";
         array<Student^>^myArray = {g1,g2};
         myClass->Students = myArray;
         mySerializer->Serialize( myStreamWriter, myClass );
         myStreamWriter->Close();
      }

      void ReadOverriddenAttributes( String^ filename )
      {
         /* The majority of the code here is the same as that in the
               WriteOverriddenAttributes method. Because the XML being read
               doesn't conform to the schema defined by the DLL, the
               XMLAttributesOverrides must be used to create an 
               XmlSerializer instance to read the XML document.*/
         XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;
         XmlAttributes^ attrs = gcnew XmlAttributes;
         XmlElementAttribute^ attr = gcnew XmlElementAttribute( "Alumni",Graduate::typeid );
         attrs->XmlElements->Add( attr );
         attrOverrides->Add( HighSchool::MyClass::typeid, "Students", attrs );
         XmlSerializer^ readSerializer = gcnew XmlSerializer( HighSchool::MyClass::typeid,attrOverrides );
         
         // To read the file, a FileStream object is required. 
         FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
         MyClass ^ myClass;
         myClass = dynamic_cast<MyClass^>(readSerializer->Deserialize( fs ));

         /* Here is the difference between reading and writing an 
               XML document: You must declare an object of the derived 
               type (Graduate) and cast the Student instance to it.*/
         Graduate^ g;
         System::Collections::IEnumerator^ myEnum = myClass->Students->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Graduate^ grad = safe_cast<Graduate^>(myEnum->Current);
            g = dynamic_cast<Graduate^>(grad);
            Console::Write( "{0}\t", g->Name );
            Console::Write( "{0}\t", g->ID );
            Console::Write( "{0}\n", g->University );
         }
      }
   };
}

int main()
{
   College::Run::main();
}
// </Snippet1>
