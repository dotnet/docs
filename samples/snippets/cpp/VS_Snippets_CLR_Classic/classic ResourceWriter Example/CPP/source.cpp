
// <Snippet1>
using namespace System;
using namespace System::Resources;
int main()
{
   
   // Creates a resource writer.
   IResourceWriter^ writer = gcnew ResourceWriter( "myResources.resources" );
   
   // Adds resources to the resource writer.
   writer->AddResource( "String 1", "First String" );
   writer->AddResource( "String 2", "Second String" );
   writer->AddResource( "String 3", "Third String" );
   
   // Writes the resources to the file or stream, and closes it.
   writer->Close();
}

// </Snippet1>
