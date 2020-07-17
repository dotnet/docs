#using <System.dll>
#pragma region^ Using directives

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;

#pragma endregion

int main()
{
    // <snippet1>
    UriBuilder^ baseUri = gcnew UriBuilder 
        ("http://www.contoso.com/default.aspx?Param1=7890");
    String^ queryToAppend = "param2=1234";
    if (baseUri->Query != nullptr && baseUri->Query->Length > 1)
    {
        baseUri->Query = baseUri->Query->Substring(1)+ "&" + queryToAppend;
    }

    else
    {
        baseUri->Query = queryToAppend;
    }
    // </snippet1>
}
