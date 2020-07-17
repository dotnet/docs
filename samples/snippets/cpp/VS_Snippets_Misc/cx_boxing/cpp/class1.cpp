// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace cx_boxing;
using namespace Platform;

Class1::Class1()
{
    //<snippet01>
        Object^ obj = 5; //scalar value is implicitly boxed
        int i = safe_cast<int>(obj); //unboxed with explicit cast. 
    //</snippet01>
}
