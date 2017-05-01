#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Security::Cryptography;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   void Method()
   {
      // <Snippet1>
      array<Byte>^ random = gcnew array<Byte>(100);
      
      //RNGCryptoServiceProvider is an implementation of a random number generator.
      RNGCryptoServiceProvider^ rng = gcnew RNGCryptoServiceProvider;
      rng->GetBytes( random ); // The array is now filled with cryptographically strong random bytes.
      // </Snippet1>
   }
};
