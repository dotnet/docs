// This sample demonstrates how to extend the KeyedHashAlgorithm class.
//<Snippet3>
using namespace System;
using namespace System::Security::Cryptography;

namespace Contoso
{
   public ref class ContosoKeyedHash: public KeyedHashAlgorithm
   {
   private:
      KeyedHashAlgorithm^ keyedCrypto;

   public:
      ContosoKeyedHash( array<Byte>^ rgbKey )
      {
         Init( L"System.Security.Cryptography.KeyedHashAlgorithm", rgbKey );
      }

      ContosoKeyedHash( String^ keyedHashName, array<Byte>^ rgbKey )
      {
         Init( keyedHashName, rgbKey );
      }

      void Init( String^ keyedHashName, array<Byte>^ rgbKey )
      {
         // Make sure we know which algorithm to use
         if ( rgbKey != nullptr )
         {
            KeyValue = rgbKey;
            HashSizeValue = 160;
            
            // Create a KeyedHashAlgorithm encryptor
            if ( keyedHashName == nullptr )
            {
               
               //<Snippet2>
               keyedCrypto = KeyedHashAlgorithm::Create();
               //</Snippet2>
            }
            else
            {
               //<Snippet1>
               keyedCrypto = KeyedHashAlgorithm::Create( keyedHashName );
               //</Snippet1>
            }
         }
         else
         {
            throw gcnew ArgumentNullException( L"rgbKey" );
         }
      }

      // Override abstract methods from the HashAlgorithm class.
      virtual void Initialize() override {}

      property array<Byte>^ Key 
      {
         //<Snippet22>
         virtual array<Byte>^ get() override
         {
            return dynamic_cast<array<Byte>^>(keyedCrypto->Key->Clone());
         }

         virtual void set( array<Byte>^value ) override
         {
            keyedCrypto->Key = dynamic_cast<array<Byte>^>(value->Clone());
         }
      }
      //</Snippet22>

   protected:
      virtual void HashCore( array<Byte>^ , int /*ibStart*/, int /*cbSize*/ ) override {}

      virtual array<Byte>^ HashFinal() override
      {
         return gcnew array<Byte>(0);
      }
   };
}
//</Snippet3>
