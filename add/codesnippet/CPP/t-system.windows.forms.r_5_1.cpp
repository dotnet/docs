#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace RadioButtonRendererSample
{
    public ref class CustomRadioButton : public Control
    {
    private:
        Rectangle textRectangleValue;
    private:
        bool clicked;
    private:
        RadioButtonState state;

    public:
        CustomRadioButton() : Control()
        {
            textRectangleValue = Rectangle();
            state = RadioButtonState::UncheckedNormal;
            this->Location = Point(50, 50);
            this->Size = System::Drawing::Size(100, 20);
            this->Text = "Click here";
            this->Font = SystemFonts::IconTitleFont;
        }

        // Define the text bounds so that the text rectangle
        // does not include the radio button.
    public:
        property Rectangle TextRectangle
        {
            Rectangle get()
            {
                Graphics^ g = this->CreateGraphics();

                textRectangleValue.X = ClientRectangle.X +
                    RadioButtonRenderer::GetGlyphSize(g,
                    RadioButtonState::UncheckedNormal).Width;
                textRectangleValue.Y = ClientRectangle.Y;
                textRectangleValue.Width = ClientRectangle.Width -
                    RadioButtonRenderer::GetGlyphSize(g,
                    RadioButtonState::UncheckedNormal).Width;
                textRectangleValue.Height = ClientRectangle.Height;
             
                delete g;                

                return textRectangleValue;
            }
        }

        // Draw the radio button in the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            RadioButtonRenderer::DrawRadioButton(e->Graphics,
                ClientRectangle.Location, TextRectangle, this->Text,
                this->Font, clicked, state);
        }

        // Draw the radio button in the checked or unchecked state.
    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override
        {
            __super::OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this->Text = "Clicked!";
                state = RadioButtonState::CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this->Text = "Click here";
                state = RadioButtonState::UncheckedNormal;
                Invalidate();
            }
        }

        // Draw the radio button in the hot state.
    protected:
        virtual void OnMouseHover(EventArgs^ e) override
        {
            __super::OnMouseHover(e);
            state = clicked ? RadioButtonState::CheckedHot :
                RadioButtonState::UncheckedHot;
            Invalidate();
        }

        // Draw the radio button in the hot state.
    protected:
        virtual void OnMouseUp(MouseEventArgs^ e) override
        {
            __super::OnMouseUp(e);
            this->OnMouseHover(e);
        }

        // Draw the radio button in the normal (i.e. not hot) state
    protected:
        virtual void OnMouseLeave(EventArgs^ e) override
        {
            __super::OnMouseLeave(e);
            state = clicked ? RadioButtonState::CheckedNormal :
                RadioButtonState::UncheckedNormal;
            Invalidate();
        }
    };

    public ref class Form1 : public Form
    {
    public:
        Form1() : Form()
        {
            Controls->Add(gcnew CustomRadioButton());

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
    // RadioButtonRenderer.DrawRadioButton automatically detects
    // this and draws the radio button without visual styles.
    Application::EnableVisualStyles();
    Application::Run(gcnew RadioButtonRendererSample::Form1());
}