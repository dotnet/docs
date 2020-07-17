#pragma region Using directives

#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

#pragma endregion

namespace ListViewFindItemWithTextHowTo
{
    public ref class Form1 : public Form
    {
    public:
        Form1()
        {
            
            InitializeComponent();

            //InitializeTextSearchListView();
            InitializeLocationSearchListView();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
    private:
        System::ComponentModel::IContainer^ components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    protected:
        ~Form1()
        {
            if (components != nullptr)
            {
                delete components;
            }
        }

#pragma region^ Windows Form^ Designer generated^ code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private:
        void InitializeComponent()
        {
            //
            // Form1
            //
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(292, 266);
            this->Name = "Form1";
            this->Text = "Form1";

        }

#pragma endregion

        //<snippet1>
    private:
        ListView^ textListView;
        TextBox^ searchBox;

    private:
        void InitializeTextSearchListView()
        {
            textListView = gcnew ListView();
            searchBox = gcnew TextBox();
            searchBox->Location = Point(150, 20);
            textListView->Scrollable = true;
            textListView->Width = 100;

            // Set the View to list to use the FindItemWithText method.
            textListView->View = View::List;

            // Populate the ListViewWithItems
            textListView->Items->AddRange(gcnew array<ListViewItem^>{
                gcnew ListViewItem("Amy Alberts"),
                gcnew ListViewItem("Amy Recker"),
                gcnew ListViewItem("Erin Hagens"),
                gcnew ListViewItem("Barry Johnson"),
                gcnew ListViewItem("Jay Hamlin"),
                gcnew ListViewItem("Brian Valentine"),
                gcnew ListViewItem("Brian Welker"),
                gcnew ListViewItem("Daniel Weisman") });

            // Handle the TextChanged to get the text for our search.
            searchBox->TextChanged += gcnew EventHandler(this, 
                &Form1::searchBox_TextChanged);

            // Add the controls to the form.
            this->Controls->Add(textListView);
            this->Controls->Add(searchBox);
        }

        //<snippet11>
    private:
        void searchBox_TextChanged(Object^ sender, EventArgs^ e)
        {
            // Call FindItemWithText with the contents of the textbox.
            ListViewItem^ foundItem =
                textListView->FindItemWithText(searchBox->Text, false, 0, true);
            if (foundItem != nullptr)
            {
                textListView->TopItem = foundItem;
            }
        }
        //</snippet11>
        //</snippet1>

        //<snippet2>
        ListView^ iconListView;
        TextBox^ previousItemBox;

    private:
        void InitializeLocationSearchListView()
        {
            previousItemBox = gcnew TextBox();
            iconListView = gcnew ListView();
            previousItemBox->Location = Point(150, 20);

            // Create an image list for the icon ListView.
            iconListView->SmallImageList = gcnew ImageList();

            // Add an image to the ListView small icon list.
            iconListView->SmallImageList->Images->Add(
                gcnew Bitmap(Control::typeid, "Edit.bmp"));

            // Set the view to small icon and add some items with the image
            // in the image list.
            iconListView->View = View::SmallIcon;
            iconListView->Items->AddRange(gcnew array<ListViewItem^>{
                gcnew ListViewItem("Amy Alberts", 0),
                gcnew ListViewItem("Amy Recker", 0),
                gcnew ListViewItem("Erin Hagens", 0),
                gcnew ListViewItem("Barry Johnson", 0),
                gcnew ListViewItem("Jay Hamlin", 0),
                gcnew ListViewItem("Brian Valentine", 0),
                gcnew ListViewItem("Brian Welker", 0),
                gcnew ListViewItem("Daniel Weisman", 0) });
             this->Controls->Add(iconListView);
             this->Controls->Add(previousItemBox);

             // Handle the MouseDown event to capture user input.
             iconListView->MouseDown += gcnew MouseEventHandler(
                 this, &Form1::iconListView_MouseDown);
        }

        //<snippet21>
        void iconListView_MouseDown(Object^ sender, MouseEventArgs^ e)
        {
            // Find the next item up from where the user clicked.
            ListViewItem^ foundItem = iconListView->FindNearestItem(
                SearchDirectionHint::Up, e->X, e->Y);

            // Display the results in a textbox..
            if (foundItem != nullptr)
            {
                previousItemBox->Text = foundItem->Text;
            }
            else
            {
                previousItemBox->Text = "No item found";
            }
        }
        //</snippet21>
        //</snippet2>
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew ListViewFindItemWithTextHowTo::Form1());
}

