// Class1.cpp
#include "pch.h"
#include "Class1.h"
#include <algorithm>
#include <ppltasks.h>



using namespace JS_Array;


// 05 at the top because we need the includes and usings
//<snippet05>
#include <vector>
#include <collection.h>
using namespace Platform;
using namespace std;
using namespace Platform::Collections;

void ArrayConversions(const Array<int>^ arr)
{
    // Construct an Array from another Array.
    Platform::Array<int>^ newArr = ref new Platform::Array<int>(arr);

    // Construct a Vector from an Array
    auto v = ref new Platform::Collections::Vector<int>(arr); 

    // Construct a std::vector. Two options.
    vector<int> v1(begin(arr), end(arr));
    vector<int> v2(arr->begin(), arr->end());

    // Initialize a vector one element at a time.
    // using a range for loop. Not as efficient as using begin/end.
    vector<int> v3;
    for(int i : arr)
    {
        v3.push_back(i);
    }   
}
//</snippet05>

Class1::Class1()
{
}

void Class1::ConversionDemo(const Array<int>^ arr)
{
    ArrayConversions(arr);
}

//<snippet01>
double Class1::PassArrayForReading(const Array<double>^ arr)
{
    double sum = 0;
    for(unsigned int i = 0 ; i < arr->Length; i++)
    {
        sum += arr[i];
    }
    return sum;
}
//</snippet01>

//<snippet02>

// Return array as out parameter...
void Class1::CalleeAllocatedDemo(Array<int>^* arr)
{
    auto temp = ref new Array<int>(10);
    for(unsigned int i = 0; i < temp->Length; i++)
    {
        temp[i] = i;
    }

    *arr = temp;
}

// ...or return array as return value:
Array<int>^ Class1::CalleeAllocatedDemo2()
{
    auto temp = ref new Array<int>(10);    
    for(unsigned int i = 0; i < temp->Length; i++)
    {
        temp[i] = i;
    }

    return temp;
}
//</snippet02>

//not used
Array<int>^ Class1::CalleeAllocatedDemo3()
{
    std::vector<int> vec;    
    for(int i = 0; i < 10; i++)
    {
        vec.push_back(i);
    }

    return ref new Array<int>(10/*vec*/); //compiler error
}


//<snippet03>
void Class1::CallerAllocatedDemo(Platform::WriteOnlyArray<int>^ arr)
{
    // You can write to the elements directly.
    for(unsigned int i = 0; i < arr->Length; i++)
    {
        arr[i] = i;
    }   
}
//</snippet03>



//<snippet09>
void Class1::InvokeIterators(Platform::WriteOnlyArray<int>^ arr)
{
    int k = 0;
    // You can write to the elements directly.
    for (unsigned int i = 9; i > 0; i--)
    {
        arr->set(k++, i);
    }  
    
   std::sort(arr->begin(), arr->end());
}
//</snippet09>


using namespace Windows::Foundation::Collections;
using namespace Platform;
using namespace Platform::Collections;

Person::Person(String^ name): m_name(name) { }
void Person::AddPhoneNumber(String^ type, String^ number)
{
    m_numbers[type] = number;
}
IMapView<String^, String^>^ Person::PhoneNumbers::get()
{
    return ref new MapView<String^, String^>(m_numbers);
}


ref class  DateTracker sealed
{
public:
    property Windows::Foundation::Uri^ uri;
    // ...
};


void DoSomething()
{
    Windows::Foundation::Uri msdn("http://www.msdn.microsoft.com");
    Windows::Foundation::Uri^ devCenter = msdn.CombineUri("/windows/");	
    // ... 
}   // both variables cleaned up here.

#include <collection.h>
#include <vector>
#include <utility>
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace std;
IVector<int>^ GetInts()
{
    vector<int> vec;
    for(int i = 0; i < 10; i++)
    {
        vec.push_back(i);
    }    
    //Implicit conversion to IVector
    return ref new Vector<int>(std::move(vec));
}

//<snippet06>
Array<int>^ GetNums()
{
    int nums[] = {0,1,2,3,4};
    //Use nums internally....

    // Convert to Platform::Array and return to caller.
    return ref new Array<int>(nums, 5);
}
//</snippet06>




//Array<int>^ GetNums2()
//{
// vector<int> vec;
//    for(int i = 0; i < 10; i++)
//    {
//        vec.push_back(i);
//    }    
//    //Implicit conversion to IVector
//    return ref new Array<int>(begin(vec), end(vec));
//}
using namespace Windows::Storage;
using namespace Windows::Storage::Streams;
using namespace concurrency;

void Class1::TestDataReader()
{
    //String^ Filename = "test.data";
    //   Windows::Storage::StorageFile^ sampleFile;
    //    create_task(KnownFolders::DocumentsLibrary->GetFileAsync(Filename)).then([this](task<StorageFile^> getFileTask)
    //{
    //    try
    //    {
    //        sampleFile = getFileTask.get();
    //    }
    //    catch (Platform::Exception^)
    //    {
    //        // sample file doesn't exist so scenario one must be run first.
    //    }
    //});

    //    IInputStream^ str = 
    //   DataReader^ dataReader = ref new DataReader(sampleFile);

    //   uint8 data[1024];
    //   dataReader->ReadBytes( ArrayReference<uint8>(data, 1024) );

}


