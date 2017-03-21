#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void TestParse( String^ testString )
{
   try
   {
      // Parse the test string.
      SoapNormalizedString^ normalized = SoapNormalizedString::Parse(
         testString );

      // Report that the parse succeeded if no exception was thrown.
      Console::WriteLine( L"Parse succeeded on the string \"{0}\".",
         testString );
      
      // Print the string representation of the object.
      Console::WriteLine( L"The normalized value of this string is \"{0}\".",
         normalized );

      // Print the XSD type of the object.
      Console::WriteLine( L"The XSD type of the SoapNormalizedString object is {0}.",
         normalized->GetXsdType() );

      // Print the value of the SoapNormalizedString object.
      Console::WriteLine( L"The value of the SoapNormalizedString object is \"{0}\".",
         normalized->Value );
   }
   catch ( System::Runtime::Remoting::RemotingException^ e ) 
   {
      // Report the details of the exception that was thrown.
      Console::WriteLine( L"Parse failed on the string \"{0}\".",
         testString );
      Console::WriteLine( e->Message );
   }
}

int main()
{
   // Create strings to test the Parse method.
   String^ stringWithSpaces = L"one two";
   String^ stringWithSpacesAndTabs = L"one two\t";
   String^ stringWithSpacesAndLineFeed = L"one two\n";
   String^ stringWithSpacesAndCarriageReturn = L"one two\r";
   
   // Test the Parse method with each string.
   TestParse( stringWithSpaces );
   TestParse( stringWithSpacesAndTabs );
   TestParse( stringWithSpacesAndLineFeed );
   TestParse( stringWithSpacesAndCarriageReturn );
   
   // Print the XSD type string of the SoapNormalizedString class.
   Console::WriteLine( L"The XSD type of the SoapNormalizedString class is {0}.",
      SoapNormalizedString::XsdType );
}