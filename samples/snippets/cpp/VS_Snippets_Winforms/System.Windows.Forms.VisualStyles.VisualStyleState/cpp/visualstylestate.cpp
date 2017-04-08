
// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace VisualStyleStateSample
{
    public ref class VisualStyleStateForm : public Form
    {
        Button^ updateButton;
        RadioButton^ applyToClient;
        RadioButton^ applyToNonClient;
        RadioButton^ applyToAll;
        RadioButton^ disableStyles;

    public:
        VisualStyleStateForm()
        {
            updateButton = gcnew Button();
            applyToClient = gcnew RadioButton();
            applyToNonClient = gcnew RadioButton();
            applyToAll = gcnew RadioButton();
            disableStyles = gcnew RadioButton();

            updateButton->AutoSize = true;
            updateButton->Location = Point(10, 10);
            updateButton->Text = "Update VisualStyleState";
            updateButton->Click += gcnew EventHandler(this, 
                &VisualStyleStateForm::UpdateButton_Click);

            applyToClient->Location = Point(10, 50);
            applyToClient->AutoSize = true;
            applyToClient->Text = "Apply styles to client area only";

            applyToNonClient->Location = Point(10, 70);
            applyToNonClient->AutoSize = true;
            applyToNonClient->Text = "Apply styles to nonclient area only";

            applyToAll->Location = Point(10, 90);
            applyToAll->AutoSize = true;
            applyToAll->Text = "Apply styles to client and nonclient areas";

            disableStyles->Location = Point(10, 110);
            disableStyles->AutoSize = true;
            disableStyles->Text = "Disable styles in all areas";

            this->Text = "VisualStyleState Test";
            this->Controls->AddRange(gcnew array<Control^>{updateButton,
                applyToClient, applyToNonClient, applyToAll, disableStyles});
        }

        // <Snippet10>
    private:
        void UpdateButton_Click(Object^ sender, EventArgs^ e)
        {
            if (applyToClient->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::ClientAreaEnabled;
            }
            else if (applyToNonClient->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::NonClientAreaEnabled;
            }
            else if (applyToAll->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::ClientAndNonClientAreasEnabled;
            }
            else if (disableStyles->Checked)
            {
                Application::VisualStyleState =
                    VisualStyleState::NoneEnabled;
            }

            // Repaint the form and all child controls.
            this->Invalidate(true);
        }
        // </Snippet10>
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew VisualStyleStateSample::VisualStyleStateForm());
}
// </Snippet0>
