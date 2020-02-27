#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections;

//Create a Class that inherits from System.Windows.Forms.Form.
public ref class TreeViewWhidbeyMembersExample : 
    public System::Windows::Forms::Form
{
public:
    TreeViewWhidbeyMembersExample()
    {
        InitializeComponent();
        //InitializeStatefulTreeView();
        //InitializeTreeViewWithToolTips();
        InitializeInitialTreeView();
        initialTreeView->MouseDown += gcnew MouseEventHandler(this, 
            &TreeViewWhidbeyMembersExample::InitialTreeView_MouseDown);
        initialTreeView->NodeMouseClick += 
            gcnew TreeNodeMouseClickEventHandler(this, 
            &TreeViewWhidbeyMembersExample::InitialTreeView_NodeMouseClick);
        initialTreeView->NodeMouseDoubleClick +=
            gcnew TreeNodeMouseClickEventHandler(this,
            &TreeViewWhidbeyMembersExample::InitialTreeView_NodeMouseDoubleClick);
        initialTreeView->NodeMouseHover +=
            gcnew TreeNodeMouseHoverEventHandler(this, 
            &TreeViewWhidbeyMembersExample::InitialTreeView_NodeMouseHover);
        //InitializeLineTreeView();
    }

    // <snippet1>
    // Create a node sorter that implements the IComparer interface.
private:
    ref class NodeSorter : public IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
    public:
        virtual int Compare(Object^ x, Object^ y)
        {
            TreeNode^ tx = (TreeNode^)x;
            TreeNode^ ty = (TreeNode^)y;

            // Compare the length of the strings, returning the difference.
            if (tx->Text->Length != ty->Text->Length)
            {
                return (tx->Text->Length - ty->Text->Length);
            }

            // If they are the same length, call Compare.
            return String::Compare(tx->Text, ty->Text);
        }
    };

    // Declare the TreeView.
private:
    TreeView^ initialTreeView;
private:
    TextBox^ displayNodes;
private:
    Button^ setSorter;

private:
    void InitializeInitialTreeView()
    {
        // Create the TreeView
        initialTreeView = gcnew TreeView();
        initialTreeView->Size = System::Drawing::Size(200, 200);

        // Create the button and set some basic properties.
        setSorter = gcnew Button();
        setSorter->Location = Point(205, 138);
        setSorter->Text = "Set Sorter";

        // Handle the click event for the button.
        setSorter->Click += gcnew EventHandler(this, 
            &TreeViewWhidbeyMembersExample::SetSorter_Click);

        // Create the root nodes.
        TreeNode^ docNode = gcnew TreeNode("Documents");
        TreeNode^ spreadSheetNode = gcnew TreeNode("Spreadsheets");

        // Add some additional nodes.
        spreadSheetNode->Nodes->Add("payroll.xls");
        spreadSheetNode->Nodes->Add("checking.xls");
        spreadSheetNode->Nodes->Add("tracking.xls");
        docNode->Nodes->Add("phoneList.doc");
        docNode->Nodes->Add("resume.doc");

        // Add the root nodes to the TreeView.
        initialTreeView->Nodes->Add(spreadSheetNode);
        initialTreeView->Nodes->Add(docNode);

        // Add the TreeView to the form.
        this->Controls->Add(initialTreeView);
        this->Controls->Add(setSorter);
    }

    // Set the TreeViewNodeSorter property to a new instance
    // of the custom sorter.
private:
    void SetSorter_Click(Object^ sender, EventArgs^ e)
    {
        initialTreeView->TreeViewNodeSorter = gcnew NodeSorter();
    }
    // </snippet1>

    // The following code example demonstrates setting the TreeNode line color.
    // To run this example, paste the code into a Windows Form. Call
    // InitializeLineTreeView from the form's constructor or Load
    // event handling method.
    // <snippet2>
private:
    TreeView^ lineTreeView;

public:
    void InitializeLineTreeView()
    {
        lineTreeView = gcnew TreeView();
        lineTreeView->Size = System::Drawing::Size(200, 200);

        lineTreeView->LineColor = Color::Red;

        // Create the root nodes.
        TreeNode^ docNode = gcnew TreeNode("Documents");

        // Add some additional nodes.
        docNode->Nodes->Add("phoneList.doc");
        docNode->Nodes->Add("resume.doc");

        lineTreeView->Nodes->Add(docNode);
        this->Controls->Add(lineTreeView);
    }
    // </snippet2>

private:
    void InitializeComponent()
    {
        this->displayNodes = gcnew System::Windows::Forms::TextBox();
        this->SuspendLayout();
        //
        // textBox1
        //
        this->displayNodes->Location = System::Drawing::Point(180, 93);
        this->displayNodes->Name = "textBox1";
        this->displayNodes->TabIndex = 0;
        //
        // Form1
        //
        this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
        this->ClientSize = System::Drawing::Size(292, 266);
        this->Controls->Add(this->displayNodes);
        this->Name = "Form1";
        this->ResumeLayout(false);
        this->PerformLayout();
    }

    // The following example code demonstrates how to use the TreeNode.Level,
    // TreeViewHitTestInfo.Node and TreeView.HitTest members.
    // To run this example create a Windows Form that contains a TreeView
    // named treeView1 and populate it with several levels of nodes.
    // Paste the following code into the form and associate the MouseDown
    // event of treeView1 with the treeView1_MouseDown method in this example.
    //<snippet3>
private:
    void InitialTreeView_MouseDown(Object^ sender, MouseEventArgs^ e)
    {
        TreeViewHitTestInfo^ info = initialTreeView->HitTest(e->X, e->Y);
        TreeNode^ hitNode;

        if (info->Node != nullptr)
        {
            hitNode = info->Node;
            MessageBox::Show(hitNode->Level.ToString());
        }
    }
    //</snippet3>

    // The following example demonstrates how to handle the NodeMouseClick
    // event.
    //<snippet4>
private:
    void InitialTreeView_NodeMouseClick(Object^ sender,
        TreeNodeMouseClickEventArgs^ e)
    {
        displayNodes->Text = e->Node->Text;
    }
    //</snippet4>

    // The following example demonstrates how to handle the
    // NodeMouseDoubleClick event and how to use the TreeNodeMouse-
    // ClickEventArgs.To run this example, paste the code into a Windows Form
    // that contains a TreeView named treeView1. Populate the treeView1 with
    // the names of files located in the c:\ directly of the system the sample
    // is running on, and associate the NodeMouseDoubleClick event of treeView1
    // with the treeView1_NodeMouseDoubleClick method in this example.
    //<snippet5>
    // If a node is double-clicked, open the file indicated by the TreeNode.
private:
    void InitialTreeView_NodeMouseDoubleClick(Object^ sender,
        TreeNodeMouseClickEventArgs^ e)
    {
        try
        {
            // Look for a file extension.
            if (e->Node->Text->Contains("."))
            {
                System::Diagnostics::Process::Start("c:\\" + e->Node->Text);
            }
        }
        // If the file is not found, handle the exception and inform the user.
        catch (System::ComponentModel::Win32Exception^)
        {
            MessageBox::Show("File not found.");
        }
    }
    //</snippet5>

    // The following example demonstrates how to handle the
    // NodeMouseHover event.
    // <snippet6>
private:
    void InitialTreeView_NodeMouseHover(Object^ sender,
        TreeNodeMouseHoverEventArgs^ e)
    {
        e->Node->Toggle();
    }
    // </snippet6>

    // The following code example demonstrates the StateImageList
    // property. To run this example, paste the code into a Windows
    // Form and call InitializeCheckTreeView from the form's
    // constructor or Load event-handling method.
    // <snippet8>
    TreeView^ checkTreeView;
private:
    void InitializeCheckTreeView()
    {
        checkTreeView = gcnew TreeView();

        // Show check boxes for the TreeView. This
        // will cause the StateImageList to be used.
        checkTreeView->CheckBoxes = true;

        // Create the StateImageList and add two images.
        checkTreeView->StateImageList = gcnew ImageList();
        checkTreeView->StateImageList->Images->Add(SystemIcons::Question);
        checkTreeView->StateImageList->Images->Add(SystemIcons::Exclamation);

        // Add some nodes to the TreeView and the TreeView to the form.
        checkTreeView->Nodes->Add("Node1");
        checkTreeView->Nodes->Add("Node2");
        this->Controls->Add(checkTreeView);
    }
    //</snippet8>
};

[STAThreadAttribute]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew TreeViewWhidbeyMembersExample());
}
