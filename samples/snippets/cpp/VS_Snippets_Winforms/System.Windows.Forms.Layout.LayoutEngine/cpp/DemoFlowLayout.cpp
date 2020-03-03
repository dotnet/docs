// <snippet1>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Layout;

// <snippet3>
// This class demonstrates a simple custom layout engine.
public ref class DemoFlowLayout : public LayoutEngine
{
    // <snippet4>
public:
    virtual bool Layout(Object^ container,
		LayoutEventArgs^ layoutEventArgs) override
    {
        Control^ parent = nullptr;
        try
        {
            parent = (Control ^) container;
        }
        catch (InvalidCastException^ ex)
        {
            throw gcnew ArgumentException(
                "The parameter 'container' must be a control", "container", ex);
        }
        // Use DisplayRectangle so that parent.Padding is honored.
        Rectangle parentDisplayRectangle = parent->DisplayRectangle;
        Point nextControlLocation = parentDisplayRectangle.Location;

        for each (Control^ currentControl in parent->Controls)
        {
            // Only apply layout to visible controls.
            if (!currentControl->Visible)
            {
                continue;
            }

            // Respect the margin of the control:
            // shift over the left and the top.
            nextControlLocation.Offset(currentControl->Margin.Left,
                currentControl->Margin.Top);

            // Set the location of the control.
            currentControl->Location = nextControlLocation;

            // Set the autosized controls to their
            // autosized heights.
            if (currentControl->AutoSize)
            {
                currentControl->Size = currentControl->GetPreferredSize(
                    parentDisplayRectangle.Size);
            }

            // Move X back to the display rectangle origin.
            nextControlLocation.X = parentDisplayRectangle.X;

            // Increment Y by the height of the control
            // and the bottom margin.
            nextControlLocation.Y += currentControl->Height +
                currentControl->Margin.Bottom;
        }

        // Optional: Return whether or not the container's
        // parent should perform layout as a result of this
        // layout. Some layout engines return the value of
        // the container's AutoSize property.

        return false;
    }
    // </snippet4>
};
// </snippet3>

// <snippet2>
// This class demonstrates a simple custom layout panel.
// It overrides the LayoutEngine property of the Panel
// control to provide a custom layout engine.
public ref class DemoFlowPanel : public Panel
{
private:
    DemoFlowLayout^ layoutEngine;

public:
    DemoFlowPanel()
    {
        layoutEngine = gcnew DemoFlowLayout();
    }

public:
    virtual property System::Windows::Forms::Layout::LayoutEngine^ LayoutEngine
    {
        System::Windows::Forms::Layout::LayoutEngine^ get() override
        {
            if (layoutEngine == nullptr)
            {
                layoutEngine = gcnew DemoFlowLayout();
            }

            return layoutEngine;
        }
    }
};
// </snippet2>

// </snippet1>

public ref class TestForm : public Form
{
public:
    TestForm()
    {
        Panel^ testPanel = gcnew DemoFlowPanel();
        for (int i = 0; i < 10; i ++)
        {
            Button^ b = gcnew Button();
            testPanel->Controls->Add(b);
            b->Text = i.ToString(
                System::Globalization::CultureInfo::CurrentCulture);
        }
        this->Controls->Add(testPanel);
    }
};

[STAThread]
int main()
{
    Application::Run(gcnew TestForm());
}
