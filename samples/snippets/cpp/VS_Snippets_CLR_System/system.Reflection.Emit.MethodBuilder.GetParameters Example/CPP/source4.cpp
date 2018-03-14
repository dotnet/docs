
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
class MoreMethodBuilderSnippets
{
public:
   static void ContainerMethod( ModuleBuilder^ myModBuilder )
   {
      // <Snippet1>
      TypeBuilder^ myType1 = myModBuilder->DefineType( "MyMathFunctions", TypeAttributes::Public );
      array<Type^>^temp0 = {Type::GetType( "System.Int32&" ),int::typeid};
      MethodBuilder^ myMthdBuilder = myType1->DefineMethod( "AddToRefValue", MethodAttributes::Public, void::typeid, temp0 );
      ParameterBuilder^ myParam1 = myMthdBuilder->DefineParameter( 1, ParameterAttributes::Out, "thePool" );
      ParameterBuilder^ myParam2 = myMthdBuilder->DefineParameter( 2, ParameterAttributes::In, "addMeToPool" );
      
      // Create body via ILGenerator here, and complete the type.
      array<ParameterInfo^>^myParams = myMthdBuilder->GetParameters();
      Console::WriteLine( "Method: {0}", myMthdBuilder->Name );

      for each (ParameterInfo^ myParam in myParams)
      {
         Console::WriteLine("------- Parameter: {0} {1} at pos {2}, with attribute {3}", 
            myParam->ParameterType, myParam->Name, myParam->Position,
                  myParam->Attributes.ToString());
      }
      // </Snippet1>
   }
};
