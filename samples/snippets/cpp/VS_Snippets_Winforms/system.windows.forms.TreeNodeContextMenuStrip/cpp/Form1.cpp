#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections;

//Create a Class that inherits from System.Windows.Forms.Form.
ref class myForm : public Form
{
public:
    myForm()
    {
        InitializeComponent();
        InitializeMenuTreeView();
    }

    //<snippet1>
    // Declare the TreeView and ContextMenuStrip
private:
    TreeView^ menuTreeView;
private:
    System::Windows::Forms::ContextMenuStrip^ docMenu;

public:
    void InitializeMenuTreeView()
    {
        // Create the TreeView.
        menuTreeView = gcnew TreeView();
        menuTreeView->Size = System::Drawing::Size(200, 200);

        // Create the root node.
        TreeNode^ docNode = gcnew TreeNode("Documents");

        // Add some additional nodes.
        docNode->Nodes->Add("phoneList.doc");
        docNode->Nodes->Add("resume.doc");

        // Add the root nodes to the TreeView.
        menuTreeView->Nodes->Add(docNode);

        // Create the ContextMenuStrip.
        docMenu = gcnew System::Windows::Forms::ContextMenuStrip();

        //Create some menu items.
        ToolStripMenuItem^ openLabel = gcnew ToolStripMenuItem();
        openLabel->Text = "Open";
        ToolStripMenuItem^ deleteLabel = gcnew ToolStripMenuItem();
        deleteLabel->Text = "Delete";
        ToolStripMenuItem^ renameLabel = gcnew ToolStripMenuItem();
        renameLabel->Text = "Rename";

        //Add the menu items to the menu.
        docMenu->Items->AddRange(gcnew array<ToolStripMenuItem^>{openLabel,
            deleteLabel, renameLabel});

        // Set the ContextMenuStrip property to the ContextMenuStrip.
        docNode->ContextMenuStrip = docMenu;

        // Add the TreeView to the form.
        this->Controls->Add(menuTreeView);
    }
    //</snippet1>
private:
    void InitializeComponent()
    {
        this->SuspendLayout();

        //
        // myForm
        //
        this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
        this->ClientSize = System::Drawing::Size(292, 266);
        this->Name = "myForm";
        this->ResumeLayout(false);
    }
};

[STAThreadAttribute]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew myForm());
}
