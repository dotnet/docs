

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::Reflection;

namespace CodeDomSamples
{
   public ref class CodeConstructorExample
   {
   public:
      CodeConstructorExample()
      {
         
         //<Snippet2>
         // This example declares two types, one of which inherits from another,
         // and creates a set of different styles of constructors using CodeConstructor.
         // Creates a new CodeCompileUnit to contain the program graph.
         CodeCompileUnit^ CompileUnit = gcnew CodeCompileUnit;
         
         // Declares a new namespace object and names it.
         CodeNamespace^ Samples = gcnew CodeNamespace( "Samples" );
         
         // Adds the namespace object to the compile unit.
         CompileUnit->Namespaces->Add( Samples );
         
         // Adds a new namespace import for the System namespace.
         Samples->Imports->Add( gcnew CodeNamespaceImport( "System" ) );
         
         // Declares a new type and names it.
         CodeTypeDeclaration^ BaseType = gcnew CodeTypeDeclaration( "BaseType" );
         
         // Adds the new type to the namespace object's type collection.
         Samples->Types->Add( BaseType );
         
         // Declares a default constructor that takes no arguments.
         CodeConstructor^ defaultConstructor = gcnew CodeConstructor;
         defaultConstructor->Attributes = MemberAttributes::Public;
         
         // Adds the constructor to the Members collection of the BaseType.
         BaseType->Members->Add( defaultConstructor );
         
         // Declares a constructor that takes a string argument.
         CodeConstructor^ stringConstructor = gcnew CodeConstructor;
         stringConstructor->Attributes = MemberAttributes::Public;
         
         // Declares a parameter of type string named "TestStringParameter".
         stringConstructor->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.String","TestStringParameter" ) );
         
         // Adds the constructor to the Members collection of the BaseType.
         BaseType->Members->Add( stringConstructor );
         
         // Declares a type that derives from BaseType and names it.
         CodeTypeDeclaration^ DerivedType = gcnew CodeTypeDeclaration( "DerivedType" );
         
         // The DerivedType class inherits from the BaseType class.
         DerivedType->BaseTypes->Add( gcnew CodeTypeReference( "BaseType" ) );
         
         // Adds the new type to the namespace object's type collection.
         Samples->Types->Add( DerivedType );
         
         // Declare a constructor that takes a string argument and calls the base class constructor with it.
         CodeConstructor^ baseStringConstructor = gcnew CodeConstructor;
         baseStringConstructor->Attributes = MemberAttributes::Public;
         
         // Declares a parameter of type string named "TestStringParameter".    
         baseStringConstructor->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.String","TestStringParameter" ) );
         
         // Calls a base class constructor with the TestStringParameter parameter.
         baseStringConstructor->BaseConstructorArgs->Add( gcnew CodeVariableReferenceExpression( "TestStringParameter" ) );
         
         // Adds the constructor to the Members collection of the DerivedType.
         DerivedType->Members->Add( baseStringConstructor );
         
         // Declares a constructor overload that calls another constructor for the type with a predefined argument.
         CodeConstructor^ overloadConstructor = gcnew CodeConstructor;
         overloadConstructor->Attributes = MemberAttributes::Public;
         
         // Sets the argument to pass to a base constructor method.
         overloadConstructor->ChainedConstructorArgs->Add( gcnew CodePrimitiveExpression( "Test" ) );
         
         // Adds the constructor to the Members collection of the DerivedType.
         DerivedType->Members->Add( overloadConstructor );
         
         // Declares a constructor overload that calls the default constructor for the type.
         CodeConstructor^ overloadConstructor2 = gcnew CodeConstructor;
         overloadConstructor2->Attributes = MemberAttributes::Public;
         overloadConstructor2->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.Int32","TestIntParameter" ) );
         
         // Sets the argument to pass to a base constructor method.
         overloadConstructor2->ChainedConstructorArgs->Add( gcnew CodeSnippetExpression( "" ) );
         
         // Adds the constructor to the Members collection of the DerivedType.
         DerivedType->Members->Add( overloadConstructor2 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // public class BaseType {
         //     
         //     public BaseType() {
         //     }
         //        
         //     public BaseType(string TestStringParameter) {
         //     }
         // }
         //    
         // public class DerivedType : BaseType {
         //        
         //     public DerivedType(string TestStringParameter) : 
         //             base(TestStringParameter) {
         //     }
         //        
         //     public DerivedType() : 
         //             this("Test") {
         //     }
         //
         //     public DerivedType(int TestIntParameter) : 
         //                this() {
         //     }
         // }
         //</Snippet2>
      }

   };

}

//</Snippet1>
