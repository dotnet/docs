
using namespace System;
using namespace System::Collections::Generic;

void main()
{
// <Snippet1>
    Type^ t = List<String^>::typeid->GetMethod("ConvertAll")->GetGenericArguments()[0]->DeclaringType;
// </Snippet1>
    Console::WriteLine("Declaring type: {0:s}", t->FullName);
}

