#using <System.Windows.Forms.dll>
//<Snippet1>
using namespace System;
using namespace System::Globalization;
using namespace System::Reflection;
using namespace System::Resources;
using namespace System::Windows::Forms;

[assembly: NeutralResourcesLanguageAttribute("en-US")];
namespace GlobalizationLibrary
{
    public ref class DoNotPassLiterals
    {
        ResourceManager^ stringManager;

    public:
        DoNotPassLiterals()
        {
            stringManager = 
                gcnew ResourceManager("en-US", Assembly::GetExecutingAssembly());
        }

        void TimeMethod(int hour, int minute)
        {
            if(hour < 0 || hour > 23)
            {
                MessageBox::Show(
                    "The valid range is 0 - 23."); //CA1303 fires because the parameter for method Show is Text
            }

            if(minute < 0 || minute > 59)
            {
                MessageBox::Show(
                    stringManager->GetString("minuteOutOfRangeMessage", CultureInfo::CurrentUICulture));
            }
        }
    };
}
//</Snippet1>
