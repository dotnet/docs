        // Build a Hello World program graph using 
        // System::CodeDom types.
        static CodeCompileUnit^ BuildHelloWorldGraph()
        {
            // Create a new CodeCompileUnit to contain 
            // the program graph.
            CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit;

            // Declare a new namespace called Samples.
            CodeNamespace^ samples = gcnew CodeNamespace( "Samples" );

            // Add the new namespace to the compile unit.
            compileUnit->Namespaces->Add( samples );

            // Add the new namespace import for the System namespace.
            samples->Imports->Add( gcnew CodeNamespaceImport( "System" ) );

            // Declare a new type called Class1.
            CodeTypeDeclaration^ class1 = gcnew CodeTypeDeclaration( "Class1" );

            // Add the new type to the namespace's type collection.
            samples->Types->Add( class1 );

            // Declare a new code entry point method.
            CodeEntryPointMethod^ start = gcnew CodeEntryPointMethod;

            // Create a type reference for the System::Console class.
            CodeTypeReferenceExpression^ csSystemConsoleType = gcnew CodeTypeReferenceExpression( "System.Console" );

            // Build a Console::WriteLine statement.
            CodeMethodInvokeExpression^ cs1 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine", gcnew CodePrimitiveExpression("Hello World!") );

            // Add the WriteLine call to the statement collection.
            start->Statements->Add( cs1 );

            // Build another Console::WriteLine statement.
            CodeMethodInvokeExpression^ cs2 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine", gcnew CodePrimitiveExpression( "Press the Enter key to continue." ) );

            // Add the WriteLine call to the statement collection.
            start->Statements->Add( cs2 );

            // Build a call to System::Console::ReadLine.
            CodeMethodReferenceExpression^ csReadLine = gcnew CodeMethodReferenceExpression( csSystemConsoleType, "ReadLine" );
            CodeMethodInvokeExpression^ cs3 = gcnew CodeMethodInvokeExpression( csReadLine, gcnew array<CodeExpression^>(0) );

            // Add the ReadLine statement.
            start->Statements->Add( cs3 );

            // Add the code entry point method to
            // the Members collection of the type.
            class1->Members->Add( start );
            return compileUnit;
        }