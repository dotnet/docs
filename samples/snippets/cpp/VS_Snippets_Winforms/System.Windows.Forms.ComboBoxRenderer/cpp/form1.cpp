// This sample can go in ComboBoxRenderer class overview.
// - Snippet2 can go in IsSupported
// - Snippet4 can go in DrawTextBox and DrawDropDownButton

// It renders the pieces of a combo box with visual styles, provided
// that visual styles are enabled in the Display Panel.
// For simplicity, this sample does not handle run-time visual style switching.

//<Snippet0>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace ComboBoxRendererSample
{
    ref class CustomComboBox: public Control
    {
    private:
        System::Drawing::Size arrowSize;
        Rectangle arrowRectangle;
        Rectangle topTextBoxRectangle;
        Rectangle bottomTextBoxRectangle;
        ComboBoxState textBoxState;
        ComboBoxState arrowState;
        String^ bottomText;
        bool isActivated;
        int minHeight;
        int minWidth;

    public:
        CustomComboBox() : Control()

          {
              minHeight = 38;
              minWidth = 40; 
              this->Location = Point(10, 10);
              this->Size = System::Drawing::Size(140, 38);
              this->Font = SystemFonts::IconTitleFont;
              this->Text = "Click the button";
              textBoxState = ComboBoxState::Normal;
              bottomText = "Using ComboBoxRenderer";
              arrowState = ComboBoxState::Normal;

              // Initialize the rectangles to look like the standard combo
              // box control.
              arrowSize = System::Drawing::Size(18, 20);
              arrowRectangle = Rectangle(ClientRectangle.X +
                  ClientRectangle.Width - arrowSize.Width - 1,
                  ClientRectangle.Y + 1,
                  arrowSize.Width,
                  arrowSize.Height);
              topTextBoxRectangle = Rectangle(ClientRectangle.X,
                  ClientRectangle.Y,
                  ClientRectangle.Width,
                  arrowSize.Height + 2);
              bottomTextBoxRectangle = Rectangle(ClientRectangle.X,
                  ClientRectangle.Y + topTextBoxRectangle.Height,
                  ClientRectangle.Width,
                  topTextBoxRectangle.Height - 6);
          }

          //<Snippet4>
          //<Snippet2>
          // Draw the combo box in the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override 
        {
            Control::OnPaint(e);

            if (!ComboBoxRenderer::IsSupported)
            {
                this->Parent->Text = "Visual Styles Disabled";
                return;
            }

            this->Parent->Text = "CustomComboBox Enabled";

            // Always draw the main text box and drop down arrow in their
            // current states
            ComboBoxRenderer::DrawTextBox(e->Graphics, topTextBoxRectangle,
                this->Text, this->Font, textBoxState);
            ComboBoxRenderer::DrawDropDownButton(e->Graphics, arrowRectangle,
                arrowState);

            // Only draw the bottom text box if the arrow has been clicked
            if (isActivated)
            {
                ComboBoxRenderer::DrawTextBox(e->Graphics,
                    bottomTextBoxRectangle, bottomText, this->Font,
                    textBoxState);
            }
        }
        //</Snippet2>

    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override 
        {
            Control::OnMouseDown(e);

            // Check whether the user clicked the arrow.
            if (arrowRectangle.Contains(e->Location) &&
                ComboBoxRenderer::IsSupported)
            {
                // Draw the arrow in the pressed state.
                arrowState = ComboBoxState::Pressed;

                // The user has activated the combo box.
                if (!isActivated)
                {
                    this->Text = "Clicked!";
                    textBoxState = ComboBoxState::Pressed;
                    isActivated = true;
                }

                // The user has deactivated the combo box.
                else
                {
                    this->Text = "Click here";
                    textBoxState = ComboBoxState::Normal;
                    isActivated = false;
                }

                // Redraw the control.
                Invalidate();
            }
        }
        //</Snippet4>

    protected:
        virtual void OnMouseUp(MouseEventArgs^ e) override 
        {
            Control::OnMouseUp(e);

            if (arrowRectangle.Contains(e->Location) &&
                ComboBoxRenderer::IsSupported)
            {
                arrowState = ComboBoxState::Normal;
                Invalidate();
            }
        }
    };

    ref class Form1 : public Form
    {
    public:
        Form1() : Form()
        {
            this->Size = System::Drawing::Size(300, 300);
            CustomComboBox^ ComboBox1 = gcnew CustomComboBox();
            Controls->Add(ComboBox1);
        }

    };

}

[STAThread]
int main()
{
    // The call to EnableVisualStyles below does not affect
    // whether ComboBoxRenderer.IsSupported is true; as long as visual
    // styles are enabled by the operating system, IsSupported is true.
    Application::EnableVisualStyles();
    Application::Run(gcnew ComboBoxRendererSample::Form1());

}
//</Snippet0>
