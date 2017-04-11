//<Snippet1>
using namespace System;
using namespace System::IO;

namespace DesignLibrary
{
   public ref class StreamUser
   {
      int anInteger;

   public:
      void ManipulateFileStream(FileStream^ stream)
      {
         while((anInteger = stream->ReadByte()) != -1)
         {
            // Do something.
         }
      }

      void ManipulateAnyStream(Stream^ anyStream)
      {
         while((anInteger = anyStream->ReadByte()) != -1)
         {
            // Do something.
         }
      }
   };
}

using namespace DesignLibrary;

static void main()
{
   StreamUser^ someStreamUser = gcnew StreamUser();
   FileStream^ testFileStream = 
      gcnew FileStream("test.dat", FileMode::OpenOrCreate);
   MemoryStream^ testMemoryStream = 
      gcnew MemoryStream(gcnew array<Byte>{});

   // Cannot be used with testMemoryStream.
   someStreamUser->ManipulateFileStream(testFileStream);

   someStreamUser->ManipulateAnyStream(testFileStream);
   someStreamUser->ManipulateAnyStream(testMemoryStream);

   testFileStream->Close();
}
//</Snippet1>