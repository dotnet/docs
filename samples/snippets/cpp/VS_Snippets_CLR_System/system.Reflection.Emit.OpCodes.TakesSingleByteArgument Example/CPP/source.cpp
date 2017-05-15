
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// <Snippet1>
int main()
{
   
   // We need a blank OpCode Object for reference when calling FieldInfo::GetValue().
   OpCode blankOpCode;
   Type^ myOpCodesType = Type::GetType( "System.Reflection.Emit.OpCodes" );
   array<FieldInfo^>^listOfOpCodes = myOpCodesType->GetFields();
   Console::WriteLine( "Which OpCodes take single-Byte arguments?" );
   Console::WriteLine( "-----------------------------------------" );
   
   // Now, let's reflect on each FieldInfo and create an instance of the OpCode it represents.
   System::Collections::IEnumerator^ myEnum = listOfOpCodes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FieldInfo^ opCodeFI = safe_cast<FieldInfo^>(myEnum->Current);
      Object^ theOpCode = opCodeFI->GetValue( blankOpCode );
      Console::WriteLine( " {0}: {1}", opCodeFI->Name, OpCodes::TakesSingleByteArgument(  *dynamic_cast<OpCode^>(theOpCode) ) );
   }
}

// </Snippet1>
