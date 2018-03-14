#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Policy;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
private:
   array<Byte>^ MD5hash( array<Byte>^data )
   {
      // This is one implementation of the abstract class MD5.
      MD5^ md5 = gcnew MD5CryptoServiceProvider;

      array<Byte>^ result = md5->ComputeHash( data );

      return result;
   }
   // </Snippet1>
};
