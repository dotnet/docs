

// <Snippet1>
// Beginning of the HighSchool.dll 
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

      // Use extra types to use this field.
      array<Object^>^Info;
   };

   public ref class Address
   {
   public:
      String^ City;
   };

   public ref class Phone
   {
   public:
      String^ Number;
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

         // Create array of extra types.
         array<Type^>^extraTypes = gcnew array<Type^>(2);
         extraTypes[ 0 ] = Address::typeid;
         extraTypes[ 1 ] = Phone::typeid;

         // Create an XmlRootAttribute.
         XmlRootAttribute^ root = gcnew XmlRootAttribute( "Graduates" );

         /* Create the XmlSerializer with the 
               XmlAttributeOverrides object. */
         XmlSerializer^ mySerializer = gcnew XmlSerializer( HighSchool::MyClass::typeid,attrOverrides,extraTypes,root,"http://www.microsoft.com" );
         MyClass ^ myClass = gcnew MyClass;
         Graduate^ g1 = gcnew Graduate;
         g1->Name = "Jacki";
         g1->ID = 1;
         g1->University = "Alma";
         Graduate^ g2 = gcnew Graduate;
         g2->Name = "Megan";
         g2->ID = 2;
         g2->University = "CM";
         array<Student^>^myArray = {g1,g2};
         myClass->Students = myArray;

         // Create extra information.
         Address^ a1 = gcnew Address;
         a1->City = "Ionia";
         Address^ a2 = gcnew Address;
         a2->City = "Stamford";
         Phone^ p1 = gcnew Phone;
         p1->Number = "555-0101";
         Phone^ p2 = gcnew Phone;
         p2->Number = "555-0100";
         array<Object^>^o1 = {a1,p1};
         array<Object^>^o2 = {a2,p2};
         g1->Info = o1;
         g2->Info = o2;
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
         array<Type^>^extraTypes = gcnew array<Type^>(2);
         extraTypes[ 0 ] = Address::typeid;
         extraTypes[ 1 ] = Phone::typeid;
         XmlRootAttribute^ root = gcnew XmlRootAttribute( "Graduates" );
         XmlSerializer^ readSerializer = gcnew XmlSerializer( HighSchool::MyClass::typeid,attrOverrides,extraTypes,root,"http://www.microsoft.com" );

         // A FileStream object is required to read the file. 
         FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
         MyClass ^ myClass;
         myClass = dynamic_cast<MyClass^>(readSerializer->Deserialize( fs ));
         
         /* Here is the difference between reading and writing an 
               XML document: You must declare an object of the derived 
               type (Graduate) and cast the Student instance to it.*/
         Graduate^ g;
         Address^ a;
         Phone^ p;
         System::Collections::IEnumerator^ myEnum = myClass->Students->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Graduate^ grad = safe_cast<Graduate^>(myEnum->Current);
            g = dynamic_cast<Graduate^>(grad);
            Console::Write( "{0}\t", g->Name );
            Console::Write( "{0}\t", g->ID );
            Console::Write( "{0}\n", g->University );
            a = dynamic_cast<Address^>(g->Info[ 0 ]);
            Console::WriteLine( a->City );
            p = dynamic_cast<Phone^>(g->Info[ 1 ]);
            Console::WriteLine( p->Number );
         }
      }
   };
}

int main()
{
   College::Run::main();
}
// </Snippet1>
