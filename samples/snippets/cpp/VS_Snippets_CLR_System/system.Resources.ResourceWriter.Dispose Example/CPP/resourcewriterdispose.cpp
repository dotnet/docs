
// <snippet1>
using namespace System;
using namespace System::Resources;
using namespace System::IO;
int main()
{
   // Create a file stream to encapsulate items.resources.
   FileStream^ fs = gcnew FileStream( "items.resources",FileMode::OpenOrCreate,FileAccess::Write );

   // Open a resource writer to write from the stream.
   IResourceWriter^ writer = gcnew ResourceWriter( fs );

   // Add resources to the resource writer.
   writer->AddResource( "String 1", "First String" );
   writer->AddResource( "String 2", "Second String" );
   writer->AddResource( "String 3", "Third String" );

   // Write the resources to the stream,
   // and clean up all resources associated with the writer.
   // Calling Dispose is equivalent to calling Close.
   writer->~IResourceWriter();
}
// </snippet1>
