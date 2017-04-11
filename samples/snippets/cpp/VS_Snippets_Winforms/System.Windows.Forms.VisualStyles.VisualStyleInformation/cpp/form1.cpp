//<Snippet0>
// This is a simple example for VisualStyleInformation that displays
// all of the visual style values in a ListView.

#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Reflection;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace VisualStyleInformationSample
{
    public ref class StyleInfo : public Form
    {
    private:
        ListView^ displayStyleInfo;

    public:
        StyleInfo()
        {
            this->displayStyleInfo = gcnew ListView();
            this->ClientSize = System::Drawing::Size(500, 500);
            this->Text = "VisualStyleInformation Property Values";

            displayStyleInfo->Bounds = System::Drawing::Rectangle
                (System::Drawing::Point(10, 10),System::Drawing::Size(400, 300));
            displayStyleInfo->View = View::Details;
            displayStyleInfo->FullRowSelect = true;
            displayStyleInfo->Sorting = SortOrder::Ascending;

            Type^ typeInfo = VisualStyleInformation::typeid;
            Object^ propertyValue;

            // Declare an array of static/Shared property details for the
            // VisualStyleInformation class.
            array<PropertyInfo^>^ elementProperties = typeInfo->GetProperties
                (BindingFlags::Static | BindingFlags::Public);

            String^ name;
            // Insert each property name and value into the ListView.
            for each (PropertyInfo^ property in elementProperties)
            {
                name = property->Name;
                propertyValue = property->GetValue(nullptr,
                    BindingFlags::Static, nullptr, nullptr, nullptr);
                ListViewItem^ newItem = gcnew ListViewItem(name, 0);
                newItem->SubItems->Add(propertyValue->ToString());
                displayStyleInfo->Items->Add(newItem);
            }

            // Create columns for the items and subitems.
            displayStyleInfo->Columns->Add("Property", -2,
                System::Windows::Forms::HorizontalAlignment::Left);
            displayStyleInfo->Columns->Add("Value", -2,
                System::Windows::Forms::HorizontalAlignment::Left);

            // Add the ListView to the control collection.
            this->Controls->Add(displayStyleInfo);
        }
    };
}

int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew VisualStyleInformationSample::StyleInfo());
}
//</Snippet0>