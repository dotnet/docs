//<Snippet1>
using namespace System;

namespace DesignLibrary
{
    public ref class ObsoleteAttributeOnMember
    {
    public:
        [ObsoleteAttribute("This property is obsolete and will " 
            "be removed in a future version. Use the FirstName " 
            "and LastName properties instead.", false)]
        property String^ Name
        {
            String^ get()
            {
               return "Name";
            }
        }

        property String^ FirstName
        {
            String^ get()
            {
               return "FirstName";
            }
        }

        property String^ LastName
        {
            String^ get()
            {
               return "LastName";
            }
        }
    };
}
//</Snippet1>
