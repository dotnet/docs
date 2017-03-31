#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Policy;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   array<Byte>^dataArray;

   void Method()
   {
      // <Snippet1>
      HashAlgorithm^ sha = gcnew SHA1CryptoServiceProvider;
      array<Byte>^ result = sha->ComputeHash( dataArray );
      // </Snippet1>
   }
};
