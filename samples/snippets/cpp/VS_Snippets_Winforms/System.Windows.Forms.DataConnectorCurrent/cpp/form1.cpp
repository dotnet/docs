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
using namespace System::Drawing::Drawing2D;
using namespace System::Windows::Forms;

#pragma endregion

namespace DataConnectors
{
    ref class Form1 : public Form
    {
    private:
        BindingSource^ bindingSource1;
        Button^ moveNextButton;

    public:
        Form1()
        {
            this->Load += gcnew EventHandler(this, &Form1::Form1_Load);
            this->Paint += gcnew PaintEventHandler(this, &Form1::Form1_Paint);
            this->bindingSource1 = gcnew BindingSource();
            this->moveNextButton = gcnew Button();
            moveNextButton->Text = "Move Next";
            this->moveNextButton->Location = System::Drawing::Point(147, 129);
            this->moveNextButton->Click += gcnew System::EventHandler(
                this,&Form1::moveNextButton_Click);

            this->ClientSize = System::Drawing::Size(292, 266);
            this->Controls->Add(this->moveNextButton);

        }
        // The following snippet demonstrates the BindingSource.MoveNext,
        // BindingSource.Current,BindingSource.CurrentItem, 
        // BindingSource.Position and the BindingSourceItem.Value members.

        // To run this example paste the code into a form that contains a
        // BindingSource named bindingSource1; and a button named moveNextButton.
        // Associate the Form1_Load and the Form1_Paint method with the
        // load and paint events for the form, and the moveNextButton_click
        // method with the click event for moveNextButton.

        //<snippet1>
        void Form1_Load(Object^ sender, EventArgs^ e)
        {
            // Set the data source to the Brush type and populate
            // bindingSource1; with some brushes.
            bindingSource1->DataSource = System::Drawing::Brush::typeid;
            bindingSource1->Add(
                gcnew TextureBrush(gcnew Bitmap(Button::typeid, "Button.bmp")));
            bindingSource1->Add(gcnew HatchBrush(HatchStyle::Cross, Color::Red));
            bindingSource1->Add(gcnew SolidBrush(Color::Blue));
        }


    private:
        void moveNextButton_Click(Object^ sender, EventArgs^ e)
        {
            // If you are not at the end of the list, move to the next item
            // in the BindingSource.
            if (bindingSource1->Position + 1 < bindingSource1->Count)
            {
                bindingSource1->MoveNext();
            }
            // Otherwise, move back to the first item.
            else
            {
                bindingSource1->MoveFirst();
            }
            // Force the form to repaint.
            this->Invalidate();
        }

        void Form1_Paint(Object^ sender, PaintEventArgs^ e)
        {
            // Get the current item in the BindingSource.
            Brush^ item = (Brush^) bindingSource1->Current;

            // If the current type is a TextureBrush, fill an ellipse.
            if (item->GetType() == TextureBrush::typeid)
            {
                e->Graphics->FillEllipse(item,e->ClipRectangle);
            }
            // If the current type is a HatchBrush, fill a triangle.
            else if (item->GetType() == HatchBrush::typeid)
            {

                e->Graphics->FillPolygon(item, 
                    gcnew array<Point> {*gcnew Point(0, 0),
                    *gcnew Point(0, 200),
                    *gcnew Point(200, 0)});
            }
            // Otherwise, fill a rectangle.
            else
            {
                e->Graphics->FillRectangle(
                    (Brush^)bindingSource1->Current, e->ClipRectangle);
            }
        }

        //</snippet1>
    };
}


int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew DataConnectors::Form1());
}


