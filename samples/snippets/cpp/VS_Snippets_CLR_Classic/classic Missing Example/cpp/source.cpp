// <Snippet1>
#using "target.dll"

using namespace System;
using namespace System::Reflection;

void main()
{
    // To invoke MyMethod with the default argument value, pass 
    // Missing::Value for the optional parameter.
    MethodInfo^ mi = MissingSample::typeid->GetMethod("MyMethod");
    mi->Invoke(nullptr, gcnew array<Object^> { Missing::Value });
};    

/* This code example produces the following output:

k = 33
 */
// </Snippet1>
