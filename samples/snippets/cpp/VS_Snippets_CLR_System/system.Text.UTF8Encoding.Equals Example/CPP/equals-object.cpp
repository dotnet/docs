
// <Snippet1>
using namespace System;
using namespace System::Text;
void DescribeEquivalence( Boolean isEquivalent )
{
   Console::WriteLine( "{0} equivalent encoding.", (isEquivalent ? (String^)"An" : "Not an") );
}

int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   UTF8Encoding^ utf8true = gcnew UTF8Encoding( true );
   UTF8Encoding^ utf8truetrue = gcnew UTF8Encoding( true,true );
   UTF8Encoding^ utf8falsetrue = gcnew UTF8Encoding( false,true );
   DescribeEquivalence( utf8->Equals( utf8 ) );
   DescribeEquivalence( utf8->Equals( utf8true ) );
   DescribeEquivalence( utf8->Equals( utf8truetrue ) );
   DescribeEquivalence( utf8->Equals( utf8falsetrue ) );
   DescribeEquivalence( utf8true->Equals( utf8 ) );
   DescribeEquivalence( utf8true->Equals( utf8true ) );
   DescribeEquivalence( utf8true->Equals( utf8truetrue ) );
   DescribeEquivalence( utf8true->Equals( utf8falsetrue ) );
   DescribeEquivalence( utf8truetrue->Equals( utf8 ) );
   DescribeEquivalence( utf8truetrue->Equals( utf8true ) );
   DescribeEquivalence( utf8truetrue->Equals( utf8truetrue ) );
   DescribeEquivalence( utf8truetrue->Equals( utf8falsetrue ) );
   DescribeEquivalence( utf8falsetrue->Equals( utf8 ) );
   DescribeEquivalence( utf8falsetrue->Equals( utf8true ) );
   DescribeEquivalence( utf8falsetrue->Equals( utf8truetrue ) );
   DescribeEquivalence( utf8falsetrue->Equals( utf8falsetrue ) );
}

// </Snippet1>
