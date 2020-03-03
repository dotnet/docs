// This sample can go in GroupBoxRenderer class overview.
// - Snippet2 can go in DrawGroupBox

// This is a custom GroupBox-like control that has a double border
// and uses an internal FlowLayoutPanel to contain added controls.

// TODO: see if you can work DrawParentBackground into here somehow.

//<Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace GroupBoxRendererSample
{
    public ref class CustomGroupBox : public Control
    {
    private:
        Rectangle innerRectangle;
    private:
        GroupBoxState state;
    private:
        FlowLayoutPanel^ panel;

    public:
        CustomGroupBox() : Control()
        {
            innerRectangle = Rectangle();
            state = GroupBoxState::Normal;
            panel = gcnew FlowLayoutPanel();

            this->Size = System::Drawing::Size(200, 200);
            this->Location = Point(10, 10);
            this->Controls->Add(panel);
            this->Text = "CustomGroupBox";
            this->Font = SystemFonts::IconTitleFont;

            innerRectangle.X = ClientRectangle.X + 5;
            innerRectangle.Y = ClientRectangle.Y + 15;
            innerRectangle.Width = ClientRectangle.Width - 10;
            innerRectangle.Height = ClientRectangle.Height - 20;

            panel->FlowDirection = FlowDirection::TopDown;
            panel->Location = Point(innerRectangle.X + 5,
                innerRectangle.Y + 5);
            panel->Size = System::Drawing::Size(innerRectangle.Width - 10,
                innerRectangle.Height - 10);
        }

        //<Snippet2>
        // Draw the group box in the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override 
        {
            __super::OnPaint(e);

            GroupBoxRenderer::DrawGroupBox(e->Graphics, ClientRectangle,
                this->Text, this->Font, state);

            // Draw an additional inner border if visual styles are enabled.
            if (Application::RenderWithVisualStyles)
            {
                GroupBoxRenderer::DrawGroupBox(e->Graphics, innerRectangle,
                    state);
            }
        }
        //</Snippet2>

        // Pass added controls to the internal FlowLayoutPanel.
    protected:
        virtual void OnControlAdded(ControlEventArgs^ e) override
        {
            __super::OnControlAdded(e);

            // Ensure that you do not add the panel itself.
            if (e->Control != this->panel)
            {
                this->Controls->Remove(e->Control);
                panel->Controls->Add(e->Control);
            }
        }
    };

    ref class Form1 : public Form
    {
    public:
        Form1() : Form()
        {
            CustomGroupBox^ groupBox1 = gcnew CustomGroupBox();
            groupBox1->Text = "Radio Button Display";
            Controls->Add(groupBox1);

            // Add some radio buttons to test the CustomGroupBox.
            int count = 8;
            array<RadioButton^>^ buttonArray = 
                gcnew array<RadioButton^>(count);
            for (int i = 0; i < count; i++)
            {
                buttonArray[i] = gcnew RadioButton();
                buttonArray[i]->Text = "Button " + (i + 1).ToString();
                groupBox1->Controls->Add(buttonArray[i]);
            }

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
    // GroupBoxRenderer automatically detects this and draws
    // the group box without visual styles.
    Application::EnableVisualStyles();
    Application::Run(gcnew GroupBoxRendererSample::Form1());
}
//</Snippet0>
