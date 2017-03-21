         CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit;
         CodeNamespace^ namespace1 = gcnew CodeNamespace( "TestNamespace" );
         compileUnit->Namespaces->Add( namespace1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //     namespace TestNamespace {    
         //     }