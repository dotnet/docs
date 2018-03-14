#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace ToolStripExamples
{
    //<snippet1>
    // Extend the ToolStripRenderer class.
    //</snippet1>

    // Override the desired methods to render items as desired.
    public ref class RedTextRenderer: public 
        System::Windows::Forms::ToolStripRenderer
    {
    protected:
        void OnRenderItemText(ToolStripItemTextRenderEventArgs^ e)
        {
            e->TextColor = Color::Red;
            e->TextFont = 
                gcnew Font("Helvetica", 7, FontStyle::Bold);
            __super::OnRenderItemText(e);
        } //OnRenderItemText
    };


    /// <summary>
    /// Summary description for form.
    /// </summary>
    public ref class Form1: public System::Windows::Forms::Form
    {
    private:

        /// <summary>
        /// Required designer variable.
        /// </summary>
        System::ComponentModel::IContainer^ components;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            this->statusStrip1 = 
                gcnew System::Windows::Forms::StatusStrip;
            this->raftingContainer1 = 
                gcnew System::Windows::Forms::RaftingContainer;
            this->movingToolStrip = 
                gcnew System::Windows::Forms::ToolStrip;
            this->toolStrip1 = 
                gcnew System::Windows::Forms::ToolStrip;
            this->raftingContainer2 = 
                gcnew System::Windows::Forms::RaftingContainer;
            this->raftingContainer3 = 
                gcnew System::Windows::Forms::RaftingContainer;
            this->raftingContainer4 = 
                gcnew System::Windows::Forms::RaftingContainer;
            this->components = 
                gcnew System::ComponentModel::Container;
            this->SuspendLayout();

            // 
            // statusStrip1
            // 
            this->statusStrip1->CanOverflow = false;
            this->statusStrip1->GripStyle = 
                System::Windows::Forms::ToolStripGripStyle::Hidden;
            this->statusStrip1->Location = 
                System::Drawing::Point(9, 233);
            this->statusStrip1->Name = "statusStrip1";
            this->statusStrip1->Size = System::Drawing::Size(274, 24);
            this->statusStrip1->TabIndex = 4;
            this->statusStrip1->Text = "statusStrip1";
            this->statusStrip1->Visible = true;

            // 
            // raftingContainer1
            // 
            this->raftingContainer1->AutoSize = true;
            this->raftingContainer1->Dock = 
                System::Windows::Forms::DockStyle::Top;
            this->raftingContainer1->Location = 
                System::Drawing::Point(9, 9);
            this->raftingContainer1->Name = "raftingContainer1";
            this->raftingContainer1->Orientation = 
                System::Windows::Forms::Orientation::Horizontal;
            this->raftingContainer1->RowMargin = 
                System::Windows::Forms::Padding(0);
            this->raftingContainer1->Size = 
                System::Drawing::Size(274, 25);
            this->raftingContainer1->TabIndex = 0;
            this->raftingContainer1->Text = 
                "RaftingContainerRaftingContainerTop";
            this->raftingContainer1->Join(this->toolStrip1);
            this->raftingContainer1->Join(this->movingToolStrip);

            // 
            // movingToolStrip
            // 
            this->movingToolStrip->Anchor = 
                System::Windows::Forms::AnchorStyles::Right;
            this->movingToolStrip->Dock = 
                System::Windows::Forms::DockStyle::None;
            this->movingToolStrip->Location = 
                System::Drawing::Point(0, 0);
            this->movingToolStrip->Name = "movingToolStrip";
            this->movingToolStrip->Raft = 
                System::Windows::Forms::RaftingSides::Top;
            this->movingToolStrip->TabIndex = 2;
            this->movingToolStrip->Text = "toolStrip2";
            this->movingToolStrip->Visible = true;

            // 
            // toolStrip1
            // 
            this->toolStrip1->Anchor = 
                System::Windows::Forms::AnchorStyles::Right;
            this->toolStrip1->Dock = 
                System::Windows::Forms::DockStyle::None;
            this->toolStrip1->Location = 
                System::Drawing::Point(0, 0);
            this->toolStrip1->Name = "toolStrip1";
            this->toolStrip1->Raft = 
                System::Windows::Forms::RaftingSides::Top;
            this->toolStrip1->Size = System::Drawing::Size(0, 25);
            this->toolStrip1->TabIndex = 1;
            this->toolStrip1->Text = "toolStrip1";
            this->toolStrip1->Visible = true;

            // 
            // raftingContainer2
            // 
            this->raftingContainer2->AutoSize = true;
            this->raftingContainer2->Dock = 
                System::Windows::Forms::DockStyle::Bottom;
            this->raftingContainer2->Location = 
                System::Drawing::Point(9, 257);
            this->raftingContainer2->Name = "raftingContainer2";
            this->raftingContainer2->Orientation = 
                System::Windows::Forms::Orientation::Horizontal;
            this->raftingContainer2->RowMargin = 
                System::Windows::Forms::Padding(0);
            this->raftingContainer2->Size = 
                System::Drawing::Size(274, 0);
            this->raftingContainer2->TabIndex = 1;
            this->raftingContainer2->Text = 
                "RaftingContainerRaftingContainerBottom";

            // 
            // raftingContainer3
            // 
            this->raftingContainer3->AutoSize = true;
            this->raftingContainer3->Dock = 
                System::Windows::Forms::DockStyle::Left;
            this->raftingContainer3->Location = 
                System::Drawing::Point(9, 9);
            this->raftingContainer3->Name = "raftingContainer3";
            this->raftingContainer3->Orientation = 
                System::Windows::Forms::Orientation::Vertical;
            this->raftingContainer3->RowMargin = 
                System::Windows::Forms::Padding(0);
            this->raftingContainer3->Size = 
                System::Drawing::Size(0, 248);
            this->raftingContainer3->TabIndex = 2;
            this->raftingContainer3->Text = 
                "RaftingContainerRaftingContainerLeft";

            // 
            // raftingContainer4
            // 
            this->raftingContainer4->AutoSize = true;
            this->raftingContainer4->Dock = 
                System::Windows::Forms::DockStyle::Right;
            this->raftingContainer4->Location = 
                System::Drawing::Point(283, 9);
            this->raftingContainer4->Name = "raftingContainer4";
            this->raftingContainer4->Orientation = 
                System::Windows::Forms::Orientation::Vertical;
            this->raftingContainer4->RowMargin = 
                System::Windows::Forms::Padding(0);
            this->raftingContainer4->Size = System::Drawing::Size(0, 248);
            this->raftingContainer4->TabIndex = 3;
            this->raftingContainer4->Text = 
                "RaftingContainerRaftingContainerRight";

            // 
            // 
            // Form1
            // 
            this->AutoSize = true;
            this->ClientSize = System::Drawing::Size(292, 266);
            this->Controls->Add(this->statusStrip1);
            this->Controls->Add(this->raftingContainer1);
            this->Controls->Add(this->raftingContainer2);
            this->Controls->Add(this->raftingContainer3);
            this->Controls->Add(this->raftingContainer4);
            this->Name = "Form1";
            this->Padding = System::Windows::Forms::Padding(9);
            this->Text = "Form1";
            this->ResumeLayout(false);
            this->PerformLayout();
        }

    protected:

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        void Dispose(bool disposing)
        {
            delete components;
            __super::Dispose(disposing);
        }

    private:

        System::Windows::Forms::StatusStrip^ statusStrip1;
        System::Windows::Forms::RaftingContainer^ raftingContainer1;
        System::Windows::Forms::RaftingContainer^ raftingContainer2;
        System::Windows::Forms::RaftingContainer^ raftingContainer3;
        System::Windows::Forms::RaftingContainer^ raftingContainer4;
        System::Windows::Forms::ToolStrip^ toolStrip1;
        System::Windows::Forms::ToolStrip^ movingToolStrip;

    public:

        Form1()
        {
            InitializeComponent();
            InitializeMovingToolStrip();
            InitializeBoldButton();
            InitializeStatusStripPanels();
            InitializeDropDownButton();
            InitializeImageButtonWithToolTip();
        }

    private:

        // The following example demonstrates setting the 
        // drop-down property for a DropDownItem.
        //<snippet5>
        // Declare the drop-down button and the items it will contain.
        ToolStripDropDownButton^ dropDownButton1;
        ToolStripDropDown^ dropDown;
        ToolStripButton^ buttonRed;
        ToolStripButton^ buttonBlue;
        ToolStripButton^ buttonYellow;

        void InitializeDropDownButton()
        {
            dropDownButton1 = gcnew ToolStripDropDownButton;
            dropDown = gcnew ToolStripDropDown;
            dropDownButton1->Text = "A";

            // Set the drop-down on the DropDownButton.
            dropDownButton1->DropDown = dropDown;

            // Declare three buttons, set their forecolor and text, 
            // and add the buttons to the drop-down.
            buttonRed = gcnew ToolStripButton;
            buttonRed->ForeColor = Color::Red;
            buttonRed->Text = "A";
            buttonBlue = gcnew ToolStripButton;
            buttonBlue->ForeColor = Color::Blue;
            buttonBlue->Text = "A";
            buttonYellow = gcnew ToolStripButton;
            buttonYellow->ForeColor = Color::Yellow;
            buttonYellow->Text = "A";
            buttonBlue->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            buttonRed->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            buttonYellow->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            array<ToolStripItem^>^ ToolStrips = 
                {buttonRed,buttonBlue,buttonYellow};
            dropDown->Items->AddRange(ToolStrips);
            toolStrip1->Items->Add(dropDownButton1);
        }


        // Handle the buttons' click event by setting the forecolor 
        // of the form to the forecolor of the button that is clicked.
        void colorButtonsClick(Object^ sender, EventArgs^ e)
        {
            ToolStripButton^ senderButton = (ToolStripButton^) sender;
            this->ForeColor = senderButton->ForeColor;
        }


        //  internal:

        //</snippet5>
        //Sample for ToolStripButton, ToolStripButton.CheckOnClick, 
        //ToolStripButton.CheckedChanged, ToolStripButton.Checked
        //<snippet50>
        ToolStripButton^ boldButton;

        void InitializeBoldButton()
        {
            boldButton = gcnew ToolStripButton;
            boldButton->Text = "B";
            boldButton->CheckOnClick = true;
            boldButton->CheckedChanged  += gcnew EventHandler(this, 
                &Form1::boldButtonCheckedChanged);
            toolStrip1->Items->Add(boldButton);
        }

        void boldButtonCheckedChanged(Object^ sender, EventArgs^ e)
        {
            if (boldButton->Checked)
            { 
                this->Font= gcnew System::Drawing::Font(this->Font, 
                    FontStyle::Bold);
            }
            else
            { 
                this->Font = gcnew System::Drawing::Font(this->Font, 
                    FontStyle::Regular);
            }
        }


        //   internal:

        //</snippet50>
        // The following snippet demonstrates ToolStripItem.Image, 
        // ToolStripItem.ImageAlign, ToolStripItem.ImageScaling, 
        // ToolStripItem.ImageTransparentColor, ToolStripItem.ToolTipText,
        // ToolStripItem.AutoToolTip, ToolStrip.ShowItemToolTips.
        //<snippet20>
        ToolStripButton^ imageButton;

        void InitializeImageButtonWithToolTip()
        {

            // Construct the button and set the image-related properties.
            imageButton = gcnew ToolStripButton;
            imageButton->Image = 
                gcnew Bitmap(Timer::typeid,"Timer.bmp");
            imageButton->ImageScaling = 
				ToolStripItemImageScaling::SizeToFit;

            // Set the background color of the image to be transparent.
            imageButton->ImageTransparentColor = 
                Color::FromArgb(0, 255, 0);

            // Show ToolTip text, set custom ToolTip text, and turn
            // off the automatic ToolTips.
            toolStrip1->ShowItemToolTips = true;
            imageButton->ToolTipText = "Click for the current time";
            imageButton->AutoToolTip = false;

            // Add the button to the ToolStrip.
            toolStrip1->Items->Add(imageButton);
        }


        //   internal:

        //</snippet20>
        // The following snippet demonstrates the ToolStrip.AutoSize,
        // ToolStrip.RenderMode, ToolStripItem.TextDirection, 
        // ToolStripItem.TextAlign, ToolStrip.Raft properties
        //<snippet4>
        ToolStripButton^ changeDirectionButton;

        void InitializeMovingToolStrip()
        {
            changeDirectionButton = gcnew ToolStripButton;
            movingToolStrip->AutoSize = true;
            movingToolStrip->RenderMode = ToolStripRenderMode::System;
            changeDirectionButton->TextDirection = 
                ToolStripTextDirection::Vertical270;
            changeDirectionButton->Overflow = 
                ToolStripItemOverflow::Never;
            changeDirectionButton->Text = "Change Alignment";
            movingToolStrip->Items->Add(changeDirectionButton);
            changeDirectionButton->Click += gcnew EventHandler(this, 
                &Form1::changeDirectionButtonClick);
        }

        void changeDirectionButtonClick(Object^ sender, EventArgs^ e)
        {
            ToolStripItem^ item = (ToolStripItem^) sender;
            if ((item->TextDirection == ToolStripTextDirection::Vertical270) 
                || (item->TextDirection == ToolStripTextDirection::Vertical90))
            {
                item->TextDirection = ToolStripTextDirection::Horizontal;
                movingToolStrip->Raft = RaftingSides::Top;
            }
            else
            {
                item->TextDirection = 
                    ToolStripTextDirection::Vertical270;
                movingToolStrip->Raft = RaftingSides::Left;
            }
        }


        //</snippet4>
        // The following snippet can go in the StatusStripPanel and
        // StatusStrip overview.
        // It also demonstrates StatusStripPanel.BorderSides, 
        // and StatusStripPanel.BorderStyle.
        //<snippet40>
        void InitializeStatusStripPanels()
        {

            // Create two StatusStripPanel objects to display in the
            // StatusBar.
            StatusStripPanel^ panel1 = gcnew StatusStripPanel;
            StatusStripPanel^ panel2 = gcnew StatusStripPanel;

            // Display the first panel with a sunken border style on all
            // sides.
			panel1->BorderSides = StatusStripPanelBorderSide::All;
            panel1->BorderStyle = Border3DStyle::Sunken;

            // Display the second panel with a raised border style on the
            // left side only.
			panel2->BorderSides = StatusStripPanelBorderSide::Left;
            panel2->BorderStyle = Border3DStyle::Bump;

            // Initialize the text of the panel.
            panel1->Text = "Ready...";

            // Set the text of the panel to the current date.
            panel2->Text = DateTime::Today::get().ToLongDateString();


            // Add both panels to the StatusBarPanelCollection of the
            // StatusBar.
            array<ToolStripItem^>^ toolStrips = {panel1, panel2};
            statusStrip1->Items->AddRange(toolStrips);
        }

        //</snippet40>
        void SetCustomRenderer()
        {
            //<snippet7>
            toolStrip1->Renderer = gcnew RedTextRenderer;
            //</snippet7>
        }

        void SetCustomerRenderInManagerMode()
        {
            //<snippet8>
            toolStrip1->RenderMode = 
                ToolStripRenderMode::ManagerRenderMode;
            ToolStripManager::Renderer = gcnew RedTextRenderer;
            //</snippet8>
        }
    };
}

int main()
{
    Application::Run(gcnew ToolStripExamples::Form1());
}

