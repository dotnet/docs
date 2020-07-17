// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace DetermineModifierKey
{
    public ref class Form1 : public Form
    {
    private:
        TextBox^ textBox1;

    public:
        Form1()
        {
            textBox1 = gcnew TextBox();
            textBox1->KeyPress +=
                gcnew KeyPressEventHandler(this, &Form1::textBox1_KeyPress);
            this->Controls->Add(textBox1);
        }

        // <Snippet5>
    private:
        void textBox1_KeyPress(Object^ sender, KeyPressEventArgs^ e)
        {
            if ((Control::ModifierKeys & Keys::Shift) == Keys::Shift)
            {
                MessageBox::Show("Pressed " + Keys::Shift.ToString());
            }
        }
        // </Snippet5>
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew DetermineModifierKey::Form1());
}
// </Snippet0>
