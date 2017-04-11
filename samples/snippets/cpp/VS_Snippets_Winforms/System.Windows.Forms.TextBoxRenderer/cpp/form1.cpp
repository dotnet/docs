// This sample can go in TextBoxRenderer class overview.
// - Snippet2 can go in IsSupported and DrawTextBox
// - Snippet4 could go in TextFormatFlags

// This sample is a custom control that displays a static string and allows
// the user to select the TextFormatFlag to apply to the text.
// For simplicity, this sample does not handle run-time switching of visual styles.

//<Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace TextBoxRendererSample
{
    public ref class CustomTextBox : public Control
    {
    private:
        TextFormatFlags textFlags;
        ComboBox^ textFormatFlagsComboBox;
        Rectangle textBorder;
        Rectangle textRectangle;
        StringBuilder^ textMeasurements;

    public:
        CustomTextBox():Control()
        {
            textFlags = TextFormatFlags::Default;
            textFormatFlagsComboBox = gcnew ComboBox();

            textMeasurements = gcnew StringBuilder();

            this->Location = Point(10, 10);
            this->Size = System::Drawing::Size(300, 200);
            this->Font = SystemFonts::IconTitleFont;
            this->Text = "This is a long sentence that will exceed " +
                "the text box bounds";

            textBorder.Location = Point(10, 10);
            textBorder.Size = System::Drawing::Size(200, 50);
            textRectangle.Location = Point(textBorder.X + 2,
                textBorder.Y + 2);
            textRectangle.Size =  System::Drawing::Size(textBorder.Size.Width - 4,
                textBorder.Height - 4);

            textFormatFlagsComboBox->Location = Point(10, 100);
            textFormatFlagsComboBox->Size = System::Drawing::Size(150, 20);
            textFormatFlagsComboBox->SelectedIndexChanged +=
                gcnew EventHandler(this, 
                &CustomTextBox::textFormatFlagsComboBox_SelectedIndexChanged);

            // Populate the combo box with the TextFormatFlags value names.
            for each (String^ name in Enum::GetNames(TextFormatFlags::typeid))
            {
                textFormatFlagsComboBox->Items->Add(name);
            }

            textFormatFlagsComboBox->SelectedIndex = 0;
            this->Controls->Add(textFormatFlagsComboBox);
        }

        //<Snippet2>
        //<Snippet4>
        // Use DrawText with the current TextFormatFlags.

    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (TextBoxRenderer::IsSupported)
            {
                TextBoxRenderer::DrawTextBox(e->Graphics, textBorder, this->Text,
                    this->Font, textRectangle, textFlags, TextBoxState::Normal);

                this->Parent->Text = "CustomTextBox Enabled";
            }
            else
            {
                this->Parent->Text = "CustomTextBox Disabled";
            }
        }
        //</Snippet2>

        // Assign the combo box selection to the display text.
    private:
        void textFormatFlagsComboBox_SelectedIndexChanged(
            Object^ sender, EventArgs^ e)
        {
            this->textFlags = (TextFormatFlags)Enum::Parse(
                TextFormatFlags::typeid,
                (String^)textFormatFlagsComboBox->Items[
                    textFormatFlagsComboBox->SelectedIndex]);

                    Invalidate();
        }
        //</Snippet4>
    };

    public ref class Form1 : public Form
    {
    public:
        Form1()
        {
            __super::Form();
            this->Size = System::Drawing::Size(350, 200);
            CustomTextBox^ textBox1 = gcnew CustomTextBox();
            Controls->Add(textBox1);
        }
    };
}

using namespace TextBoxRendererSample;

[STAThread]
int main()
{     
    // The call to EnableVisualStyles below does not affect whether 
    // TextBoxRenderer draws the text box; as long as visual styles 
    // are enabled by the operating system, TextBoxRenderer will 
    // draw the text box.
    Application::EnableVisualStyles();
    Application::Run(gcnew Form1());
}

//</Snippet0>
