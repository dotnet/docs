// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace CX_Collections; //local project namespace
using namespace std;
#include <vector>
#include <utility> //for std::move

//<snippet01>
#include <collection.h>
#include <algorithm>
using namespace Platform;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;


void Class1::Test()
{
    Vector<int>^ vec = ref new Vector<int>();
    vec->Append(1);
    vec->Append(2);
    vec->Append(3);
    vec->Append(4);
    vec->Append(5);


    auto it = 
        std::find(begin(vec), end(vec), 3);

    int j = *it; //j = 3
    int k = *(it + 1); //or it[1]

    // Find a specified value.
    unsigned int n;         
    bool found = vec->IndexOf(4, &n); //n = 3

    // Get the value at the specified index.
    n = vec->GetAt(4); // n = 3

    // Insert an item.
    // vec = 0, 1, 2, 3, 4, 5
    vec->InsertAt(0, 0);

    // Modify an item.
    // vec = 0, 1, 2, 12, 4, 5,
    vec->SetAt(3, 12);

    // Remove an item.
    //vec = 1, 2, 12, 4, 5 
    vec->RemoveAt(0);

    // vec = 1, 2, 12, 4
    vec->RemoveAtEnd();

    // Get a read-only view into the vector.
    IVectorView<int>^ view = vec->GetView();
}
//</snippet01>

//<snippet02>
//#include <collection.h>
//#include <vector>
//#include <utility> //for std::move
//using namespace Platform::Collections;
//using namespace Windows::Foundation::Collections;
//using namespace std;
IVector<int>^ Class1::GetInts()
{
    vector<int> vec;
    for(int i = 0; i < 10; i++)
    {
        vec.push_back(i);
    }    
    // Implicit conversion to IVector
    return ref new Vector<int>(std::move(vec));
}
//</snippet02>

//<snippet04>
//#include <collection.h>
//using namespace Platform::Collections;
//using namespace Windows::Foundation::Collections;
IMapView<String^, int>^ Class1::MapTest()
{
    Map<String^, int>^ m = ref new Map<String^, int >();
    m->Insert("Mike", 0);
    m->Insert("Dave", 1);
    m->Insert("Doug", 2);
    m->Insert("Nikki", 3);
    m->Insert("Kayley", 4);
    m->Insert("Alex", 5);
    m->Insert("Spencer", 6);

   // PC::Map does not support [] operator
   int i = m->Lookup("Doug");
   
   return m->GetView();
   
}
//</snippet04>

Class1::Class1()
{
}
