        static void GenerateCode( CodeDomProvider^ provider, CodeCompileUnit^ compileunit )
        {
            // Build the source file name with the appropriate
            // language extension.
            String^ sourceFile;
            if ( provider->FileExtension->StartsWith( "." ) )
            {
                sourceFile = String::Concat( "TestGraph", provider->FileExtension );
            }
            else
            {
                sourceFile = String::Concat( "TestGraph.", provider->FileExtension );
            }

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            IndentedTextWriter^ tw = gcnew IndentedTextWriter( gcnew StreamWriter( sourceFile,false ),"    " );

            // Generate source code using the code generator.
            provider->GenerateCodeFromCompileUnit( compileunit, tw, gcnew CodeGeneratorOptions );

            // Close the output file.
            tw->Close();
        }