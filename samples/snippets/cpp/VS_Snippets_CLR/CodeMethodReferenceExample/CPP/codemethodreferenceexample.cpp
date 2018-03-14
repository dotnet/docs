

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
public ref class CodeMethodReferenceExample
{
public:
   CodeMethodReferenceExample()
   {
      
      //<Snippet2>
      // Declares a type to contain the example code.
      CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "Type1" );
      
      // Declares a method.
      CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
      method1->Name = "TestMethod";
      type1->Members->Add( method1 );
      
      // Declares a type constructor that calls a method.
      CodeConstructor^ constructor1 = gcnew CodeConstructor;
      constructor1->Attributes = MemberAttributes::Public;
      type1->Members->Add( constructor1 );
      
      // Invokes the TestMethod method of the current type object.
      CodeMethodReferenceExpression^ methodRef1 = gcnew CodeMethodReferenceExpression( gcnew CodeThisReferenceExpression,"TestMethod" );
      array<CodeParameterDeclarationExpression^>^temp0;
      CodeMethodInvokeExpression^ invoke1 = gcnew CodeMethodInvokeExpression( methodRef1,temp0 );
      constructor1->Statements->Add( invoke1 );
      
      //</Snippet2>
   }

   void InvokeExample()
   {
      
      //<Snippet3>
      // Invokes the TestMethod method of the current type object.
      CodeMethodReferenceExpression^ methodRef1 = gcnew CodeMethodReferenceExpression( gcnew CodeThisReferenceExpression,"TestMethod" );
      array<CodeParameterDeclarationExpression^>^temp1;
      CodeMethodInvokeExpression^ invoke1 = gcnew CodeMethodInvokeExpression( methodRef1,temp1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this.TestMethod();
      //</Snippet3>
   }

};

//</Snippet1>
