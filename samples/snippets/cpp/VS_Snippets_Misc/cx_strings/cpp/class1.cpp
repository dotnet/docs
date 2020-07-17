// Class1.cpp
#include "pch.h"
#include "Class1.h"
#include <string>

using namespace Strings;

//<snippet02>
using namespace Platform;
String^ str = L"hello"; 
void main(){} 
//</snippet02>


Class1::Class1()
{
    //<snippet01>
    // Initializing a String^ by using string literals
    String^ str1 = "Test"; // ok for ANSI text only. uses current code page
    String^ str2("Test");
    String^ str3 = L"Test";
    String^ str4(L"Test");


    //Initialize a String^ by using another String^
    String^ str6(str1);
    auto str7 = str2;

    // Initialize a String from wchar_t* and wstring
    wchar_t msg[] = L"Test";
    String^ str8 = ref new String(msg);
    std::wstring wstr1(L"Test");
    String^ str9 = ref new String(wstr1.c_str());
    String^ str10 = ref new String(wstr1.c_str(), wstr1.length());
    //</snippet01>


   


   

}

void Test1()
{
     //<snippet03>

    // Concatenation 
    auto str1 = "Hello" + " World";
    auto str2 = str1 + " from C++/CX!";    
    auto str3 = String::Concat(str2, " and the String class");
    
    // Comparison
    if (str1 == str2) { /* ... */ }
    if (str1->Equals(str2)) { /* ... */ }
    if (str1 != str2) { /* ... */ }
    if (str1 < str2 || str1 > str2) { /* ... */};
    int result = String::CompareOrdinal(str1, str2);
    
    if(str1 == nullptr) { /* ...*/};
    if(str1->IsEmpty()) { /* ...*/};

   // Accessing individual characters in a String^
    auto it = str1->Begin();
    char16 ch = it[0];
    //</snippet03>
}

void Test2()
{
     //<snippet04>
    // Create a String^ variable statically or dynamically from a literal string. 
    String^ str1 = "AAAAAAAA";
    
    // Use the value of str1 to create the ws1 wstring variable.
    std::wstring ws1( str1->Data() ); 
    // The value of ws1 is L"AAAAAAAA".

    // Manipulate the wstring value.
    std::wstring replacement( L"BBB" );
    ws1 = ws1.replace ( 1, 3, replacement );
    // The value of ws1 is L"ABBBAAAA".

    // Assign the modified wstring back to str1. 
    str1 = ref new String( ws1.c_str() ); 

    //</snippet04>
    
}
