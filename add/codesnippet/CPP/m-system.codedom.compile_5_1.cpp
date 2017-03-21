         // Get the provider for Microsoft.VisualBasic
//         CodeDomProvider^ provider = CodeDomProvider.CreateProvider("VisualBasic");
         CodeDomProvider^ provider = CodeDomProvider::CreateProvider("VisualBasic");
         if ( provider ) // Display the Visual Basic language provider information.
         {
            Console::WriteLine( "Visual Basic provider is {0}", provider->ToString() );
            Console::WriteLine( "  Provider hash code:     {0}", provider->GetHashCode().ToString() );
            Console::WriteLine( "  Default file extension: {0}", provider->FileExtension );
         }
