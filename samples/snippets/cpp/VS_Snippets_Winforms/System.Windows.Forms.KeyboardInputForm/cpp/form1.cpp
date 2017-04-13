// This sample compiles a set of miscellaneous code snippets that demonstrate
// different levels of user input control.

// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

namespace KeyboardInputForm
{
    public ref class Form1 sealed: public Form, public IMessageFilter
    {
        // The following Windows message value is defined in Winuser.h.
    private:
        static const int WM_KEYDOWN = 0x100;
    private:
        TextBox^ inputTextBox;
    public:
        Form1()
        {
            inputTextBox = gcnew TextBox();
            this->AutoSize = true;
            Application::AddMessageFilter(this);
            FlowLayoutPanel^ panel = gcnew FlowLayoutPanel();
            panel->AutoSize = true;
            panel->FlowDirection = FlowDirection::TopDown;
            panel->Controls->Add(gcnew Button());
            panel->Controls->Add(gcnew RadioButton());
            panel->Controls->Add(inputTextBox);
            this->Controls->Add(panel);
            this->KeyPreview = true;
            this->KeyPress +=
                gcnew KeyPressEventHandler(this, &Form1::Form1_KeyPress);
            inputTextBox->KeyPress +=
                gcnew KeyPressEventHandler(this,
                &Form1::inputTextBox_KeyPress);
        }

        // <Snippet5>
        // Detect all numeric characters at the
        // application level and consume 0.
        [SecurityPermission(SecurityAction::LinkDemand,
            Flags=SecurityPermissionFlag::UnmanagedCode)]
        virtual bool PreFilterMessage(Message% m)
        {
            // Detect key down messages.
            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode =  (Keys)((int)m.WParam) & Keys::KeyCode;
                // Determine whether the keystroke is a number from the top of
                // the keyboard, or a number from the keypad.
                if (((keyCode >= Keys::D0) && (keyCode <= Keys::D9))
                    ||((keyCode >= Keys::NumPad0)
                    && (keyCode <= Keys::NumPad9)))
                {
                    MessageBox::Show(
                        "IMessageFilter.PreFilterMessage: '" +
                        keyCode.ToString() + "' pressed.");

                    if ((keyCode == Keys::D0) || (keyCode == Keys::NumPad0))
                    {
                        MessageBox::Show(
                            "IMessageFilter.PreFilterMessage: '" +
                            keyCode.ToString() + "' consumed.");
                        return true;
                    }
                }
            }

            // Forward all other messages.
            return false;
        }
        // </Snippet5>

        // <Snippet10>
        // Detect all numeric characters at the form level and consume 1,
        // 4, and 7. Note that Form.KeyPreview must be set to true for this
        // event handler to be called.
    private:
        void Form1_KeyPress(Object^ sender, KeyPressEventArgs^ e)
        {
            if ((e->KeyChar >= '0') && (e->KeyChar <= '9'))
            {
                MessageBox::Show("Form.KeyPress: '" +
                    e->KeyChar.ToString() + "' pressed.");

                switch (e->KeyChar)
                {
                case '1':
                case '4':
                case '7':
                    MessageBox::Show("Form.KeyPress: '" +
                        e->KeyChar.ToString() + "' consumed.");
                    e->Handled = true;
                    break;
                }
            }
        }
        // </Snippet10>

        // <Snippet15>
        // Detect all numeric characters at the TextBox level and consume
        // 2, 5, and 8.
    private:
        void inputTextBox_KeyPress(Object^ sender, KeyPressEventArgs^ e)
        {
            if ((e->KeyChar >= '0') && (e->KeyChar <= '9'))
            {
                MessageBox::Show("Control.KeyPress: '" +
                    e->KeyChar.ToString() + "' pressed.");

                switch (e->KeyChar)
                {
                case '2':
                case '5':
                case '8':
                    MessageBox::Show("Control.KeyPress: '" +
                        e->KeyChar.ToString() + "' consumed.");
                    e->Handled = true;
                    break;
                }
            }
        }
        // </Snippet15>
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew KeyboardInputForm::Form1());
}
// </Snippet0>
