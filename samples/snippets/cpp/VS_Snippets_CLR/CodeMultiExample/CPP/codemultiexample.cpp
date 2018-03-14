

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
public ref class CodeMultiExample
{
public:
   CodeMultiExample(){}

   void CodeEventReferenceExample()
   {
      
      //<Snippet2>
      // Represents a reference to an event.
      CodeEventReferenceExpression^ eventRef1 = gcnew CodeEventReferenceExpression( gcnew CodeThisReferenceExpression,"TestEvent" );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this.TestEvent
      //</Snippet2>
   }

   void CodeIndexerExample()
   {
      
      //<Snippet3>
      array<CodePrimitiveExpression^>^temp1 = {gcnew CodePrimitiveExpression( 1 )};
      System::CodeDom::CodeIndexerExpression^ indexerExpression = gcnew CodeIndexerExpression( gcnew CodeThisReferenceExpression,temp1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this[1];
      //</Snippet3>
   }

   void CodeDirectionExample()
   {
      
      //<Snippet4>
      // Declares a parameter passed by reference using a CodeDirectionExpression.
      array<CodeDirectionExpression^>^param1 = {gcnew CodeDirectionExpression( FieldDirection::Ref,gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"TestParameter" ) )};
      
      // Invokes a method on this named TestMethod using the direction expression as a parameter.
      CodeMethodInvokeExpression^ methodInvoke1 = gcnew CodeMethodInvokeExpression( gcnew CodeThisReferenceExpression,"TestMethod",param1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this.TestMethod(ref TestParameter);
      //</Snippet4>
   }

   void CreateExpressionExample()
   {
      
      //<Snippet5>
      array<CodeExpression^>^temp0 = gcnew array<CodeExpression^>(0);
      CodeObjectCreateExpression^ objectCreate1 = gcnew CodeObjectCreateExpression( "System.DateTime",temp0 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        new System.DateTime();
      //</Snippet5>
   }

};

//</Snippet1>
