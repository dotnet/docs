// This entire sample can go in the TabRenderer overview. 
//  - Snippet2 can be excerpted in DrawTabPage, DrawTabItem, and IsSupported.
//  - Snippet2 could also be excerpted in the VisualStyles.TabItemState enum,
//    if necessary.

// The sample defines a simple custom Control that uses TabRenderer to
// simulate a basic (and essentially useless) TabControl. Might want
// to add a bit more unique functionality, although the basic painting 
// functionality of the class is demonstrated.

// For simplicity, this sample doesn't handle runtime switching of visual styles.

//<Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace TabRendererSample
{
    public ref class CustomTabControl : public Control
    {
    private:
        Rectangle tabPageRectangle;
        Rectangle tabItemRectangle1;
        Rectangle tabItemRectangle2;
        int tabHeight;
        int tabWidth;
        TabItemState tab1State;
        TabItemState tab2State;
        String^ tab1Text;
        String^ tab2Text;
        bool tab1Focused;
        bool tab2Focused;

    public:
        CustomTabControl()
        {
            this->tabHeight = 30;
            this->tabWidth = 100;
            this->tab1State = TabItemState::Selected;
            this->tab2State = TabItemState::Normal;
            this->tab1Text = "Tab 1";
            this->tab2Text = "Tab 2";
            this->tab1Focused = true;
            this->tab2Focused = false;
            this->Size = System::Drawing::Size(300, 300);
            this->Location = Point(10, 10);
            this->Font = SystemFonts::IconTitleFont;
            this->Text = "TabRenderer";
            this->DoubleBuffered = true;

            tabPageRectangle = Rectangle(ClientRectangle.X,
                ClientRectangle.Y + tabHeight,
                ClientRectangle.Width,
                ClientRectangle.Height - tabHeight);

            // Extend the first tab rectangle down by 2 pixels, 
            // because it is selected by default.
            tabItemRectangle1 = Rectangle(ClientRectangle.X,
                ClientRectangle.Y, tabWidth, tabHeight + 2);

            tabItemRectangle2 = Rectangle(ClientRectangle.Location.X +
                tabWidth, ClientRectangle.Location.Y, tabWidth, tabHeight);
        }

        //<Snippet2>
        // Draw the tab page and the tab items.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (!TabRenderer::IsSupported)
            {
                this->Parent->Text = "CustomTabControl Disabled";
                return;
            }

            TabRenderer::DrawTabPage(e->Graphics, tabPageRectangle);
            TabRenderer::DrawTabItem(e->Graphics, tabItemRectangle1,
                tab1Text, this->Font, tab1Focused, tab1State);
            TabRenderer::DrawTabItem(e->Graphics, tabItemRectangle2,
                tab2Text, this->Font, tab2Focused, tab2State);

            this->Parent->Text = "CustomTabControl Enabled";
        }
        //</Snippet2>

        // Draw the selected tab item.
    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override
        {
            __super::OnMouseDown(e);

            if (!TabRenderer::IsSupported)
            {
                return;
            }

            // The first tab is clicked. Note that the height of the 
            // selected tab rectangle is raised by 2, so that it draws 
            // over the border of the tab page.
            if (tabItemRectangle1.Contains(e->Location))
            {
                tab1State = TabItemState::Selected;
                tab2State = TabItemState::Normal;
                tabItemRectangle1.Height += 2;
                tabItemRectangle2.Height -= 2;
                tab1Focused = true;
                tab2Focused = false;
            }

            // The second tab is clicked.
            if (tabItemRectangle2.Contains(e->Location))
            {
                tab2State = TabItemState::Selected;
                tab1State = TabItemState::Normal;
                tabItemRectangle2.Height += 2;
                tabItemRectangle1.Height -= 2;
                tab2Focused = true;
                tab1Focused = false;
            }

            Invalidate();
        }
    };
    public ref class Form1 : public Form
    {
    public:
        Form1()

        {
            CustomTabControl^ Tab1 = gcnew CustomTabControl();
            Controls->Add(Tab1);
            this->Size = System::Drawing::Size(500, 500);
        }

    };
}

[STAThread]
int main()
{
    // The call to EnableVisualStyles below does not affect whether 
    // TabRenderer.IsSupported is true; as long as visual styles 
    // are enabled by the operating system, IsSupported is true.
    Application::EnableVisualStyles();
    Application::Run(gcnew TabRendererSample::Form1());
}

//</Snippet0>
