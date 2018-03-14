
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
   
   // Generate the resources, and close the writer.
   writer->Generate();
   writer->Close();
}

// </snippet1>
