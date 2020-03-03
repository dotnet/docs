// This sample can go in CheckBoxRenderer class overview. 
// - Snippet2 can go in GetGlyphSize
// - Snippet4 can go in DrawCheckBox
// - Snippet4 can also go in the VisualStyles.CheckBoxState enum, if necessary.

// The sample defines a simple custom Control that uses CheckBoxRenderer to
// simulate a CheckBox control. 

// Might want to think of a better, more realistic/solution-oriented example. 

//<Snippet0>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace CheckBoxRendererSample
{
    ref class CustomCheckBox : Control
    {
        private:
        Rectangle textRectangleValue;
        Point clickedLocationValue;
        bool clicked;
        CheckBoxState state;

        public :
        CustomCheckBox() : Control()
        {
            this->textRectangleValue = Rectangle();
            this->clickedLocationValue = Point();
            this->clicked = false;
            this->state = CheckBoxState::UncheckedNormal;
            this->Location = Point(50, 50);
            this->Size = System::Drawing::Size(100, 20);
            this->Text = "Click here";
            this->Font = SystemFonts::IconTitleFont;
        }

        //<Snippet2>
        // Calculate the text bounds, exluding the check box.
        Rectangle getTextRectangle()
        {
            Graphics ^g = this->CreateGraphics();
            textRectangleValue.X = ClientRectangle.X +
                        CheckBoxRenderer::GetGlyphSize(g,
                        CheckBoxState::UncheckedNormal).Width;
            textRectangleValue.Y = ClientRectangle.Y;
            textRectangleValue.Width = ClientRectangle.Width -
                        CheckBoxRenderer::GetGlyphSize(g,
                        CheckBoxState::UncheckedNormal).Width;
            textRectangleValue.Height = ClientRectangle.Height;

            delete g;
            return textRectangleValue;
        }
        //</Snippet2>

protected:
        //<Snippet4>
        // Draw the check box in the current state.
        virtual void OnPaint(PaintEventArgs ^e) override
        {
            Control::OnPaint(e);

            CheckBoxRenderer::DrawCheckBox(e->Graphics,
                ClientRectangle.Location, this->getTextRectangle(), this->Text,
                this->Font, TextFormatFlags::HorizontalCenter,
                clicked, state);
        }


        // Draw the check box in the checked or unchecked state, alternately.
        virtual void OnMouseDown(MouseEventArgs ^e) override
        {
            Control::OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this->Text = "Clicked!";
                state = CheckBoxState::CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this->Text = "Click here";
                state = CheckBoxState::UncheckedNormal;
                Invalidate();
            }
        }
        //</Snippet4>

        // Draw the check box in the hot state. 
        virtual void OnMouseHover(EventArgs ^e) override
        {
            Control::OnMouseHover(e);
            state = clicked ? CheckBoxState::CheckedHot :
                CheckBoxState::UncheckedHot;
            Invalidate();
        }

        // Draw the check box in the hot state. 
        virtual void OnMouseUp(MouseEventArgs ^e) override
        {
            Control::OnMouseUp(e);
            this->OnMouseHover(e);
        }

        // Draw the check box in the unpressed state.
        virtual void OnMouseLeave(EventArgs ^e) override
        {
            Control::OnMouseLeave(e);
            state = clicked ? CheckBoxState::CheckedNormal :
                CheckBoxState::UncheckedNormal;
            Invalidate();
        } 
    }; 

    ref class Form1: public Form
    {
    public:
        Form1() : Form() 
        {
            CustomCheckBox ^CheckBox1 = gcnew CustomCheckBox();
            Controls->Add(CheckBox1);

            if (Application::RenderWithVisualStyles) 
            {
                this->Text = "Visual Styles Enabled";
            }
            else 
            {
                this->Text = "Visual Styles Disabled";
            }
        }
    };
}


[STAThread]
int main()
{
    // If you do not call EnableVisualStyles below, then 
    // CheckBoxRenderer.DrawCheckBox automatically detects 
    // this and draws the check box without visual styles.
    Application::EnableVisualStyles();
    Application::Run(gcnew CheckBoxRendererSample::Form1());
}
//</Snippet0>
