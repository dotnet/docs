private:
   array<Byte>^ MD5hash( array<Byte>^data )
   {
      // This is one implementation of the abstract class MD5.
      MD5^ md5 = gcnew MD5CryptoServiceProvider;

      array<Byte>^ result = md5->ComputeHash( data );

      return result;
   }