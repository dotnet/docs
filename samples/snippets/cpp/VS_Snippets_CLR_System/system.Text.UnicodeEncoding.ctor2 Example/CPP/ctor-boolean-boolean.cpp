
// <Snippet1>
using namespace System;
using namespace System::Text;
void DescribeEquivalence( Boolean isEquivalent )
{
   Console::WriteLine( " {0} equivalent encoding.", (isEquivalent ? (String^)"An" : "Not an") );
}

int main()
{
   
   // Create a UnicodeEncoding without parameters.
   UnicodeEncoding^ unicode = gcnew UnicodeEncoding;
   
   // Create a UnicodeEncoding to support little-endian Byte ordering
   // and include the Unicode Byte order mark.
   UnicodeEncoding^ unicodeLittleEndianBOM = gcnew UnicodeEncoding( false,true );
   
   // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
   DescribeEquivalence( unicode->Equals( unicodeLittleEndianBOM ) );
   
   // Create a UnicodeEncoding to support little-endian Byte ordering
   // and not include the Unicode Byte order mark.
   UnicodeEncoding^ unicodeLittleEndianNoBOM = gcnew UnicodeEncoding( false,false );
   
   // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
   DescribeEquivalence( unicode->Equals( unicodeLittleEndianNoBOM ) );
   
   // Create a UnicodeEncoding to support big-endian Byte ordering
   // and include the Unicode Byte order mark.
   UnicodeEncoding^ unicodeBigEndianBOM = gcnew UnicodeEncoding( true,true );
   
   // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
   DescribeEquivalence( unicode->Equals( unicodeBigEndianBOM ) );
   
   // Create a UnicodeEncoding to support big-endian Byte ordering
   // and not include the Unicode Byte order mark.
   UnicodeEncoding^ unicodeBigEndianNoBOM = gcnew UnicodeEncoding( true,false );
   
   // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
   DescribeEquivalence( unicode->Equals( unicodeBigEndianNoBOM ) );
}

// </Snippet1>
