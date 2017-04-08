

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::XPath;

// <Snippet1>
public ref class Sample
{
public:
   static void Evaluate( XPathExpression^ expr, XPathNavigator^ nav )
   {
      XPathNodeIterator^ i = nav->Select(expr);
      switch ( expr->ReturnType )
      {
         case XPathResultType::Number:
            Console::WriteLine( nav->Evaluate( expr ) );
            break;

         case XPathResultType::NodeSet:
            while ( i->MoveNext() )
                        Console::WriteLine( i->Current );
            break;

         case XPathResultType::Boolean:
            if ( *safe_cast<bool^>(nav->Evaluate( expr )) )
                        Console::WriteLine( "True!" );
            break;

         case XPathResultType::String:
            Console::WriteLine( nav->Evaluate( expr ) );
            break;
      }
   }

};

int main()
{
   XPathDocument^ doc = gcnew XPathDocument( "contosoBooks.xml" );
   XPathNavigator^ nav = doc->CreateNavigator();
   XPathExpression^ expr1 = nav->Compile( ".//price/text()*10" ); // Returns a number.

   XPathExpression^ expr2 = nav->Compile( "bookstore/book/price" ); // Returns a nodeset.

   Sample^ MySample = gcnew Sample;
   MySample->Evaluate( expr1, nav );
   MySample->Evaluate( expr2, nav );
}

// </Snippet1>
