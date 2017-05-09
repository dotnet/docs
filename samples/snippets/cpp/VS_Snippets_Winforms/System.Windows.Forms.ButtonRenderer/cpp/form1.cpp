// This entire sample can go in the ButtonRenderer overview.
//  - Snippet2 can be excerpted in ButtonRenderer.DrawBackground overload
//    and specific ButtonRenderer.DrawBackground that it uses.
//  - Snippet4 can be linked to in ButtonRenderer.DrawParentBackground
//  - Snippet2 could be excerpted in the VisualStyles.PushButtonState enum,
//    if necessary.

// The sample defines a simple custom Control that uses ButtonRenderer to
// simulate a real Button control. When clicked, it draws a smaller button
// and uses DrawParentBackground to erase the remainder of the unpressed
// button.

// Issue: to show using DrawParentBackground, I'm currently setting the
// BackColor of the custom control to something other than the parent form.
// There might be a better way of demonstrating this that makes more sense
// from a usability standpoint...


//<Snippet0>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace ButtonRendererSample
{
    public ref class CustomButton : public Control
    {
    private:
        Rectangle clickRectangleValue;

    private:
        PushButtonState state;

    public:
        CustomButton()
        {
            __super::Control();
            this->Size = System::Drawing::Size(100, 40);
            this->Location = Point(50, 50);
            this->Font = SystemFonts::IconTitleFont;
            this->Text = "Click here";
            clickRectangleValue = Rectangle();
            state = PushButtonState::Normal;
        }

        // Define the bounds of the smaller pressed button.
    public:
        property Rectangle ClickRectangle
        {
            Rectangle get()
            {
                clickRectangleValue.X = ClientRectangle.X +
                    (int)(.2 * ClientRectangle.Width);
                clickRectangleValue.Y = ClientRectangle.Y +
                    (int)(.2 * ClientRectangle.Height);
                clickRectangleValue.Width = ClientRectangle.Width -
                    (int)(.4 * ClientRectangle.Width);
                clickRectangleValue.Height = ClientRectangle.Height -
                    (int)(.4 * ClientRectangle.Height);

                return clickRectangleValue;
            }
        }

        //<Snippet2>
        //<Snippet4>
        // Draw the large or small button, depending on the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            // Draw the smaller pressed button image
            if (state == PushButtonState::Pressed)
            {
                // Set the background color to the parent if visual styles
                // are disabled, because DrawParentBackground will only paint
                // over the control background if visual styles are enabled.
                if (Application::RenderWithVisualStyles)
                {
                    this->BackColor = Color::Azure;
                }
                else
                {
                    this->BackColor = this->Parent->BackColor;
                }


                // If you comment out the call to DrawParentBackground,
                // the background of the control will still be visible
                // outside the pressed button, if visual styles are enabled.
                ButtonRenderer::DrawParentBackground(e->Graphics,
                    ClientRectangle, this);
                ButtonRenderer::DrawButton(e->Graphics, ClickRectangle,
                    this->Text, this->Font, true, state);
            }

            // Draw the bigger unpressed button image.
            else
            {
                ButtonRenderer::DrawButton(e->Graphics, ClientRectangle,
                    this->Text, this->Font, false, state);
            }
        }
        //</Snippet4>

        // Draw the smaller pressed button image.
    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override
        {
            __super::OnMouseDown(e);
            this->Text = "Clicked!";
            state = PushButtonState::Pressed;
            Invalidate();
        }

        // Draw the button in the hot state.
    protected:
        virtual void OnMouseEnter(EventArgs^ e) override
        {
            __super::OnMouseEnter(e);
            this->Text = "Click here";
            state = PushButtonState::Hot;
            Invalidate();
        }

        // Draw the button in the unpressed state.
    protected:
        virtual void OnMouseLeave(EventArgs^ e) override
        {
            __super::OnMouseLeave(e);
            this->Text = "Click here";
            state = PushButtonState::Normal;
            Invalidate();
        }
        //</Snippet2>

        // Draw the button hot if the mouse is released on the button.
    protected:
        virtual void OnMouseUp(MouseEventArgs^ e) override
        {
            __super::OnMouseUp(e);
            OnMouseEnter(e);
        }

        // Detect when the cursor leaves the button area while
        // it is pressed.
    protected:
        virtual void OnMouseMove(MouseEventArgs^ e) override
        {
            __super::OnMouseMove(e);

            // Detect when the left mouse button is down and
            // the cursor has left the pressed button area.
            if ((e->Button & ::MouseButtons::Left) == ::MouseButtons::Left &&
                !ClientRectangle.Contains(e->Location) &&
                state == PushButtonState::Pressed)
            {
                OnMouseLeave(e);
            }
        }
    };

    ref class Form1 : public Form
    {
    public:
        Form1()
        {
            __super::Form();
            CustomButton^ Button1 = gcnew CustomButton();
            Controls->Add(Button1);

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

using namespace ButtonRendererSample;

[STAThread]
int main()
{ 
    // If you do not call EnableVisualStyles below, then
    // ButtonRenderer automatically detects this and draws
    // the button without visual styles.
    Application::EnableVisualStyles();
    Application::Run(gcnew Form1());
}
//</Snippet0>
