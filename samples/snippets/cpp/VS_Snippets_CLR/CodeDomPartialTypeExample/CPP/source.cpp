
// The following example builds a CodeDom source graph for a simple
// class that represents document properties.  The source for the 
// graph is generated, saved to a file, compiled into an executable, 
// and run.
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::IO;
using namespace System::Diagnostics;

//<Snippet2>
// Build the source graph using System.CodeDom types.
CodeCompileUnit^ DocumentPropertyGraphBase()
{
   // Create a new CodeCompileUnit for the source graph.
   CodeCompileUnit^ docPropUnit = gcnew CodeCompileUnit;

   // Declare a new namespace called DocumentSamples.
   CodeNamespace^ sampleSpace = gcnew CodeNamespace( "DocumentSamples" );

   // Add the new namespace to the compile unit.
   docPropUnit->Namespaces->Add( sampleSpace );

   // Add an import statement for the System namespace.
   sampleSpace->Imports->Add( gcnew CodeNamespaceImport( "System" ) );

   // Declare a new class called DocumentProperties.
   // <Snippet3>
   CodeTypeDeclaration^ baseClass = gcnew CodeTypeDeclaration( "DocumentProperties" );
   baseClass->IsPartial = true;
   baseClass->IsClass = true;
   baseClass->Attributes = MemberAttributes::Public;
   baseClass->BaseTypes->Add( gcnew CodeTypeReference( System::Object::typeid ) );

   // Add the DocumentProperties class to the namespace.
   sampleSpace->Types->Add( baseClass );
   // </Snippet3>

   // ------Build the DocumentProperty.Main method------
   // Declare the Main method of the class.
   CodeEntryPointMethod^ mainMethod = gcnew CodeEntryPointMethod;
   mainMethod->Comments->Add( gcnew CodeCommentStatement( " Perform a simple test of the class methods." ) );

   // Add the code entry point method to the Members
   // collection of the type.
   baseClass->Members->Add( mainMethod );
   mainMethod->Statements->Add( gcnew CodeCommentStatement( "Initialize a class instance and display it." ) );

   // <Snippet4>
   // Initialize a local DocumentProperty instance, named myDoc.
   // Use the DocumentProperty constructor to set the author, 
   // title, and date.  Set the publish date to DateTime.Now.
   CodePrimitiveExpression^ docTitlePrimitive = gcnew CodePrimitiveExpression( "Cubicle Survival Strategies" );
   CodePrimitiveExpression^ docAuthorPrimitive = gcnew CodePrimitiveExpression( "John Smith" );

   // Store the value of DateTime.Now in a local variable, to re-use
   // the same value later.
   CodeTypeReferenceExpression^ docDateClass = gcnew CodeTypeReferenceExpression( "DateTime" );
   CodePropertyReferenceExpression^ docDateNow = gcnew CodePropertyReferenceExpression( docDateClass,"Now" );
   CodeVariableDeclarationStatement^ publishNow = gcnew CodeVariableDeclarationStatement( DateTime::typeid,"publishNow",docDateNow );
   mainMethod->Statements->Add( publishNow );
   CodeVariableReferenceExpression^ publishNowRef = gcnew CodeVariableReferenceExpression( "publishNow" );
   array<CodeExpression^>^ctorParams = {docTitlePrimitive,docAuthorPrimitive,publishNowRef};
   CodeObjectCreateExpression^ initDocConstruct = gcnew CodeObjectCreateExpression( "DocumentProperties",ctorParams );
   CodeVariableDeclarationStatement^ myDocDeclare = gcnew CodeVariableDeclarationStatement( "DocumentProperties","myDoc",initDocConstruct );
   mainMethod->Statements->Add( myDocDeclare );
   // </Snippet4>

   // Create a variable reference for the myDoc instance.
   CodeVariableReferenceExpression^ myDocInstance = gcnew CodeVariableReferenceExpression( "myDoc" );

   // Create a type reference for the System.Console class.
   CodeTypeReferenceExpression^ csSystemConsoleType = gcnew CodeTypeReferenceExpression( "System.Console" );

   // Build Console.WriteLine statement.
   CodeMethodInvokeExpression^ consoleWriteLine0 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",gcnew CodePrimitiveExpression( "** Document properties test **" ) );

   // Add the WriteLine call to the statement collection.
   mainMethod->Statements->Add( consoleWriteLine0 );

   // Build Console.WriteLine("First document:").
   CodeMethodInvokeExpression^ consoleWriteLine1 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",gcnew CodePrimitiveExpression( "First document:" ) );

   // Add the WriteLine call to the statement collection.
   mainMethod->Statements->Add( consoleWriteLine1 );

   // Add a statement to display the myDoc instance properties.
   CodeMethodInvokeExpression^ myDocToString = gcnew CodeMethodInvokeExpression( myDocInstance,"ToString" );
   CodeMethodInvokeExpression^ consoleWriteLine2 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",myDocToString );
   mainMethod->Statements->Add( consoleWriteLine2 );

   // Add a statement to display the myDoc instance hashcode property.
   CodeMethodInvokeExpression^ myDocHashCode = gcnew CodeMethodInvokeExpression( myDocInstance,"GetHashCode" );
   array<CodeExpression^>^writeHashCodeParams = {gcnew CodePrimitiveExpression( "  Hash code: {0}" ),myDocHashCode};
   CodeMethodInvokeExpression^ consoleWriteLine3 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",writeHashCodeParams );
   mainMethod->Statements->Add( consoleWriteLine3 );

   // Add statements to create another instance.
   mainMethod->Statements->Add( gcnew CodeCommentStatement( "Create another instance." ) );
   CodeVariableDeclarationStatement^ myNewDocDeclare = gcnew CodeVariableDeclarationStatement( "DocumentProperties","myNewDoc",initDocConstruct );
   mainMethod->Statements->Add( myNewDocDeclare );

   // Create a variable reference for the myNewDoc instance.
   CodeVariableReferenceExpression^ myNewDocInstance = gcnew CodeVariableReferenceExpression( "myNewDoc" );

   // Build Console.WriteLine("Second document:").
   CodeMethodInvokeExpression^ consoleWriteLine5 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",gcnew CodePrimitiveExpression( "Second document:" ) );

   // Add the WriteLine call to the statement collection.
   mainMethod->Statements->Add( consoleWriteLine5 );

   // Add a statement to display the myNewDoc instance properties.
   CodeMethodInvokeExpression^ myNewDocToString = gcnew CodeMethodInvokeExpression( myNewDocInstance,"ToString" );
   CodeMethodInvokeExpression^ consoleWriteLine6 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",myNewDocToString );
   mainMethod->Statements->Add( consoleWriteLine6 );

   // Add a statement to display the myNewDoc instance hashcode property.
   CodeMethodInvokeExpression^ myNewDocHashCode = gcnew CodeMethodInvokeExpression( myNewDocInstance,"GetHashCode" );
   array<CodeExpression^>^writeNewHashCodeParams = {gcnew CodePrimitiveExpression( "  Hash code: {0}" ),myNewDocHashCode};
   CodeMethodInvokeExpression^ consoleWriteLine7 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",writeNewHashCodeParams );
   mainMethod->Statements->Add( consoleWriteLine7 );

   // <Snippet5>
   // Build a compound statement to compare the two instances.
   mainMethod->Statements->Add( gcnew CodeCommentStatement( "Compare the two instances." ) );
   CodeMethodInvokeExpression^ myDocEquals = gcnew CodeMethodInvokeExpression( myDocInstance,"Equals",myNewDocInstance );
   CodePrimitiveExpression^ equalLine = gcnew CodePrimitiveExpression( "Second document is equal to the first." );
   CodePrimitiveExpression^ notEqualLine = gcnew CodePrimitiveExpression( "Second document is not equal to the first." );
   CodeMethodInvokeExpression^ equalWriteLine = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",equalLine );
   CodeMethodInvokeExpression^ notEqualWriteLine = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",notEqualLine );
   array<CodeStatement^>^equalStatements = {gcnew CodeExpressionStatement( equalWriteLine )};
   array<CodeStatement^>^notEqualStatements = {gcnew CodeExpressionStatement( notEqualWriteLine )};
   CodeConditionStatement^ docCompare = gcnew CodeConditionStatement( myDocEquals,equalStatements,notEqualStatements );
   mainMethod->Statements->Add( docCompare );
   // </Snippet5>

   // <Snippet6>
   // Add a statement to change the myDoc.Author property:
   mainMethod->Statements->Add( gcnew CodeCommentStatement( "Change the author of the original instance." ) );
   CodePropertyReferenceExpression^ myDocAuthor = gcnew CodePropertyReferenceExpression( myDocInstance,"Author" );
   CodePrimitiveExpression^ newDocAuthor = gcnew CodePrimitiveExpression( "Jane Doe" );
   CodeAssignStatement^ myDocAuthorAssign = gcnew CodeAssignStatement( myDocAuthor,newDocAuthor );
   mainMethod->Statements->Add( myDocAuthorAssign );
   // </Snippet6>

   // Add a statement to display the modified instance.
   CodeMethodInvokeExpression^ consoleWriteLine8 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",gcnew CodePrimitiveExpression( "Modified original document:" ) );
   mainMethod->Statements->Add( consoleWriteLine8 );

   // Reuse the myDoc.ToString statement built earlier.
   mainMethod->Statements->Add( consoleWriteLine2 );

   // Reuse the comparison block built earlier.
   mainMethod->Statements->Add( gcnew CodeCommentStatement( "Compare the two instances again." ) );
   mainMethod->Statements->Add( docCompare );

   // Add a statement to prompt the user to hit a key.

   // Build another call to System.WriteLine.
   // Add string parameter to the WriteLine method.
   CodeMethodInvokeExpression^ consoleWriteLine9 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine",gcnew CodePrimitiveExpression( "Press the Enter key to continue." ) );
   mainMethod->Statements->Add( consoleWriteLine9 );

   // Build a call to System.ReadLine.
   CodeMethodInvokeExpression^ consoleReadLine = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"ReadLine" );
   mainMethod->Statements->Add( consoleReadLine );

   // Define a few common expressions for the class methods.
   CodePropertyReferenceExpression^ thisTitle = gcnew CodePropertyReferenceExpression( gcnew CodeThisReferenceExpression,"docTitle" );
   CodePropertyReferenceExpression^ thisAuthor = gcnew CodePropertyReferenceExpression( gcnew CodeThisReferenceExpression,"docAuthor" );
   CodePropertyReferenceExpression^ thisDate = gcnew CodePropertyReferenceExpression( gcnew CodeThisReferenceExpression,"docDate" );
   CodeTypeReferenceExpression^ stringType = gcnew CodeTypeReferenceExpression( String::typeid );
   CodePrimitiveExpression^ trueConst = gcnew CodePrimitiveExpression( true );
   CodePrimitiveExpression^ falseConst = gcnew CodePrimitiveExpression( false );

   // ------Build the DocumentProperty.Equals method------
   CodeMemberMethod^ baseEquals = gcnew CodeMemberMethod;
   baseEquals->Attributes = static_cast<MemberAttributes>(MemberAttributes::Public | MemberAttributes::Override | MemberAttributes::Overloaded);
   baseEquals->ReturnType = gcnew CodeTypeReference( bool::typeid );
   baseEquals->Name = "Equals";
   baseEquals->Parameters->Add( gcnew CodeParameterDeclarationExpression( Object::typeid,"obj" ) );
   baseEquals->Statements->Add( gcnew CodeCommentStatement( "Override System.Object.Equals method." ) );
   CodeVariableReferenceExpression^ objVar = gcnew CodeVariableReferenceExpression( "obj" );
   CodeCastExpression^ objCast = gcnew CodeCastExpression( "DocumentProperties",objVar );
   CodePropertyReferenceExpression^ objTitle = gcnew CodePropertyReferenceExpression( objCast,"Title" );
   CodePropertyReferenceExpression^ objAuthor = gcnew CodePropertyReferenceExpression( objCast,"Author" );
   CodePropertyReferenceExpression^ objDate = gcnew CodePropertyReferenceExpression( objCast,"PublishDate" );
   CodeMethodInvokeExpression^ objTitleEquals = gcnew CodeMethodInvokeExpression( objTitle,"Equals",thisTitle );
   CodeMethodInvokeExpression^ objAuthorEquals = gcnew CodeMethodInvokeExpression( objAuthor,"Equals",thisAuthor );
   CodeMethodInvokeExpression^ objDateEquals = gcnew CodeMethodInvokeExpression( objDate,"Equals",thisDate );
   CodeBinaryOperatorExpression^ andEquals1 = gcnew CodeBinaryOperatorExpression( objTitleEquals,CodeBinaryOperatorType::BooleanAnd,objAuthorEquals );
   CodeBinaryOperatorExpression^ andEquals2 = gcnew CodeBinaryOperatorExpression( andEquals1,CodeBinaryOperatorType::BooleanAnd,objDateEquals );
   array<CodeStatement^>^returnTrueStatements = {gcnew CodeMethodReturnStatement( trueConst )};
   array<CodeStatement^>^returnFalseStatements = {gcnew CodeMethodReturnStatement( falseConst )};
   CodeConditionStatement^ objEquals = gcnew CodeConditionStatement( andEquals2,returnTrueStatements,returnFalseStatements );
   baseEquals->Statements->Add( objEquals );
   baseClass->Members->Add( baseEquals );

   // ------Build the DocumentProperty.GetHashCode method------
   CodeMemberMethod^ baseHash = gcnew CodeMemberMethod;
   baseHash->Attributes = static_cast<MemberAttributes>(MemberAttributes::Public | MemberAttributes::Override);
   baseHash->ReturnType = gcnew CodeTypeReference( int::typeid );
   baseHash->Name = "GetHashCode";
   baseHash->Statements->Add( gcnew CodeCommentStatement( "Override System.Object.GetHashCode method." ) );
   CodeMethodInvokeExpression^ hashTitle = gcnew CodeMethodInvokeExpression( thisTitle,"GetHashCode" );
   CodeMethodInvokeExpression^ hashAuthor = gcnew CodeMethodInvokeExpression( thisAuthor,"GetHashCode" );
   CodeMethodInvokeExpression^ hashDate = gcnew CodeMethodInvokeExpression( thisDate,"GetHashCode" );
   CodeBinaryOperatorExpression^ orHash1 = gcnew CodeBinaryOperatorExpression( hashTitle,CodeBinaryOperatorType::BitwiseOr,hashAuthor );
   CodeBinaryOperatorExpression^ andHash = gcnew CodeBinaryOperatorExpression( orHash1,CodeBinaryOperatorType::BitwiseAnd,hashDate );
   baseHash->Statements->Add( gcnew CodeMethodReturnStatement( andHash ) );
   baseClass->Members->Add( baseHash );

   // ------Build the DocumentProperty.ToString method------
   CodeMemberMethod^ docToString = gcnew CodeMemberMethod;
   docToString->Attributes = static_cast<MemberAttributes>(MemberAttributes::Public | MemberAttributes::Override);
   docToString->ReturnType = gcnew CodeTypeReference( String::typeid );
   docToString->Name = "ToString";
   docToString->Statements->Add( gcnew CodeCommentStatement( "Override System.Object.ToString method." ) );
   CodeMethodInvokeExpression^ baseToString = gcnew CodeMethodInvokeExpression( gcnew CodeBaseReferenceExpression,"ToString" );
   CodePrimitiveExpression^ formatString = gcnew CodePrimitiveExpression( "{0} ({1} by {2}, {3})" );
   array<CodeExpression^>^formatParams = {formatString,baseToString,thisTitle,thisAuthor,thisDate};
   CodeMethodInvokeExpression^ stringFormat = gcnew CodeMethodInvokeExpression( stringType,"Format",formatParams );
   docToString->Statements->Add( gcnew CodeMethodReturnStatement( stringFormat ) );
   baseClass->Members->Add( docToString );
   return docPropUnit;
}
//</Snippet2>

void DocumentPropertyGraphExpand( interior_ptr<CodeCompileUnit^> docPropUnit )
{
   // Expand on the DocumentProperties class,
   // adding the constructor and property implementation.
   // <Snippet7>
   CodeTypeDeclaration^ baseClass = gcnew CodeTypeDeclaration( "DocumentProperties" );
   baseClass->IsPartial = true;
   baseClass->IsClass = true;
   baseClass->Attributes = MemberAttributes::Public;

   // Extend the DocumentProperties class in the unit namespace.
   ( *docPropUnit)->Namespaces[ 0 ]->Types->Add( baseClass );
   // </Snippet7>

   // ------Declare the internal class fields------
   baseClass->Members->Add( gcnew CodeMemberField( "String","docTitle" ) );
   baseClass->Members->Add( gcnew CodeMemberField( "String","docAuthor" ) );
   baseClass->Members->Add( gcnew CodeMemberField( "DateTime","docDate" ) );

   // ------Build the DocumentProperty constructor------
   CodeConstructor^ docPropCtor = gcnew CodeConstructor;
   docPropCtor->Attributes = MemberAttributes::Public;
   docPropCtor->Parameters->Add( gcnew CodeParameterDeclarationExpression( "String","title" ) );
   docPropCtor->Parameters->Add( gcnew CodeParameterDeclarationExpression( "String","author" ) );
   docPropCtor->Parameters->Add( gcnew CodeParameterDeclarationExpression( "DateTime","publishDate" ) );
   CodeFieldReferenceExpression^ myTitle = gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docTitle" );
   CodeVariableReferenceExpression^ inTitle = gcnew CodeVariableReferenceExpression( "title" );
   CodeAssignStatement^ myDocTitleAssign = gcnew CodeAssignStatement( myTitle,inTitle );
   docPropCtor->Statements->Add( myDocTitleAssign );
   CodeFieldReferenceExpression^ myAuthor = gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docAuthor" );
   CodeVariableReferenceExpression^ inAuthor = gcnew CodeVariableReferenceExpression( "author" );
   CodeAssignStatement^ myDocAuthorAssign = gcnew CodeAssignStatement( myAuthor,inAuthor );
   docPropCtor->Statements->Add( myDocAuthorAssign );
   CodeFieldReferenceExpression^ myDate = gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docDate" );
   CodeVariableReferenceExpression^ inDate = gcnew CodeVariableReferenceExpression( "publishDate" );
   CodeAssignStatement^ myDocDateAssign = gcnew CodeAssignStatement( myDate,inDate );
   docPropCtor->Statements->Add( myDocDateAssign );
   baseClass->Members->Add( docPropCtor );

   // ------Build the DocumentProperty properties------
   CodeMemberProperty^ docTitleProp = gcnew CodeMemberProperty;
   docTitleProp->HasGet = true;
   docTitleProp->HasSet = true;
   docTitleProp->Name = "Title";
   docTitleProp->Type = gcnew CodeTypeReference( "String" );
   docTitleProp->Attributes = MemberAttributes::Public;
   docTitleProp->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docTitle" ) ) );
   docTitleProp->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docTitle" ),gcnew CodePropertySetValueReferenceExpression ) );
   baseClass->Members->Add( docTitleProp );
   CodeMemberProperty^ docAuthorProp = gcnew CodeMemberProperty;
   docAuthorProp->HasGet = true;
   docAuthorProp->HasSet = true;
   docAuthorProp->Name = "Author";
   docAuthorProp->Type = gcnew CodeTypeReference( "String" );
   docAuthorProp->Attributes = MemberAttributes::Public;
   docAuthorProp->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docAuthor" ) ) );
   docAuthorProp->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docAuthor" ),gcnew CodePropertySetValueReferenceExpression ) );
   baseClass->Members->Add( docAuthorProp );
   CodeMemberProperty^ docDateProp = gcnew CodeMemberProperty;
   docDateProp->HasGet = true;
   docDateProp->HasSet = true;
   docDateProp->Name = "PublishDate";
   docDateProp->Type = gcnew CodeTypeReference( "DateTime" );
   docDateProp->Attributes = MemberAttributes::Public;
   docDateProp->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docDate" ) ) );
   docDateProp->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"docDate" ),gcnew CodePropertySetValueReferenceExpression ) );
   baseClass->Members->Add( docDateProp );
}

String^ GenerateCode( CodeDomProvider^ provider, CodeCompileUnit^ compileUnit )
{
   // Build the source file name with the language
   // extension (vb, cs, js).
   String^ sourceFile = "";

   // Write the source out in the selected language if
   // the code generator supports partial type declarations.
   if ( provider->Supports( GeneratorSupport::PartialTypes ) )
   {
      if ( provider->FileExtension[ 0 ] == '.' )
      {
         sourceFile = String::Format( "DocProp{0}", provider->FileExtension );
      }
      else
      {
         sourceFile = String::Format( "DocProp.{0}", provider->FileExtension );
      }

      // Create a TextWriter to a StreamWriter to an output file.
      IndentedTextWriter^ outWriter = gcnew IndentedTextWriter( gcnew StreamWriter( sourceFile,false ),"    " );

      // Generate source code using the code generator.
      provider->GenerateCodeFromCompileUnit( compileUnit, outWriter, nullptr );

      // Close the output file.
      outWriter->Close();
   }

   return sourceFile;
}

//<Snippet1>
bool CompileCode( CodeDomProvider^ provider, String^ sourceFile, String^ exeFile )
{
   CompilerParameters^ cp = gcnew CompilerParameters;

   // Generate an executable instead of 
   // a class library.
   cp->GenerateExecutable = true;

   // Set the assembly file name to generate.
   cp->OutputAssembly = exeFile;

   // Save the assembly as a physical file.
   cp->GenerateInMemory = false;

   // Generate debug information.
   cp->IncludeDebugInformation = true;

   // Add an assembly reference.
   cp->ReferencedAssemblies->Add( "System.dll" );

   // Set the warning level at which 
   // the compiler should abort compilation
   // if a warning of this level occurs.
   cp->WarningLevel = 3;

   // Set whether to treat all warnings as errors.
   cp->TreatWarningsAsErrors = false;
   if ( provider->Supports( GeneratorSupport::EntryPointMethod ) )
   {
      // Specify the class that contains 
      // the main method of the executable.
      cp->MainClass = "DocumentSamples.DocumentProperties";
   }

   // Invoke compilation.
   CompilerResults^ cr = provider->CompileAssemblyFromFile( cp, sourceFile );
   if ( cr->Errors->Count > 0 )
   {
      // Display compilation errors.
      Console::WriteLine( "Errors building {0} into {1}", sourceFile, cr->PathToAssembly );
      IEnumerator^ myEnum = cr->Errors->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         CompilerError^ ce = safe_cast<CompilerError^>(myEnum->Current);
         Console::WriteLine( "  {0}", ce );
         Console::WriteLine();
      }
   }
   else
   {
      Console::WriteLine( "Source {0} built into {1} successfully.", sourceFile, cr->PathToAssembly );
   }

   // Return the results of compilation.
   if ( cr->Errors->Count > 0 )
   {
      return false;
   }
   else
   {
      return true;
   }
}
//</Snippet1>

[STAThread]
int main()
{
   CodeDomProvider^ provider = nullptr;
   String^ exeName = "DocProp.exe";
   Console::WriteLine( "Enter the source language for DocumentProperties class (cs, vb, etc):" );
   String^ inputLang = Console::ReadLine();
   Console::WriteLine();
   if ( CodeDomProvider::IsDefinedLanguage( inputLang ) )
   {
      provider = CodeDomProvider::CreateProvider( inputLang );
   }

   if ( provider == nullptr )
   {
      Console::WriteLine( "There is no CodeDomProvider for the input language." );
   }
   else
   {
      CodeCompileUnit^ docPropertyUnit = DocumentPropertyGraphBase();
      DocumentPropertyGraphExpand(  &docPropertyUnit );
      String^ sourceFile = GenerateCode( provider, docPropertyUnit );
      if (  !String::IsNullOrEmpty( sourceFile ) )
      {
         Console::WriteLine( "Document property class code generated." );
         if ( CompileCode( provider, sourceFile, exeName ) )
         {
            Console::WriteLine( "Starting DocProp executable." );
            Process::Start( exeName );
         }
      }
      else
      {
         Console::WriteLine( "Could not generate source file." );
         Console::WriteLine( "Target language code generator might not support partial type declarations." );
      }
   }
}

