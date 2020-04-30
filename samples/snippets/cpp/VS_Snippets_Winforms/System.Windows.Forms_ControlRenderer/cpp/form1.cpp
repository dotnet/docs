//<Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace SimpleControlRenderingSample
{
    public ref class CustomComboBoxArrow : Control
    {
    public:
        CustomComboBoxArrow() : Control()
        {
            this->Location = Point(50, 50);
            this->Size = System::Drawing::Size(40, 40);
        }

        //<Snippet10>
        // Render the drop-down arrow with or without visual styles.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (!ComboBoxRenderer::IsSupported)
            {
                ControlPaint::DrawComboButton(e->Graphics,
                    this->ClientRectangle, ButtonState::Normal);
            }
            else
            {
                ComboBoxRenderer::DrawDropDownButton(e->Graphics,
                    this->ClientRectangle, ComboBoxState::Normal);
            }
        }
        //</Snippet10>
    };

    public ref class SimpleControlRenderingForm : public Form
    {
    public:
        SimpleControlRenderingForm() : Form()
        {
            this->Size = System::Drawing::Size(300, 300);
            CustomComboBoxArrow^ testComboBox = gcnew CustomComboBoxArrow();
            Controls->Add(testComboBox);
        }
    };  
}

using namespace SimpleControlRenderingSample;

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew SimpleControlRenderingForm());
}
//</Snippet0>
