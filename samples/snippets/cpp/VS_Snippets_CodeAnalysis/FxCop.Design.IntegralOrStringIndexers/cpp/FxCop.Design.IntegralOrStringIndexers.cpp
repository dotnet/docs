//<Snippet1>
using namespace System;

namespace DesignLibrary
{
    public ref class Months
    {
        array<String^>^ month;

    public:
        property String^ default[int]
        {
           String^ get(int index)
           {
              return month[index];
           }
           void set(int index, String^ value)
           {
              month[index] = value;
           }
        }

        Months()
        {
            month = gcnew array<String^>(12);
            month[0] = "Jan";
            month[1] = "Feb";
            //...;
        }
    };
}
//</Snippet1>
