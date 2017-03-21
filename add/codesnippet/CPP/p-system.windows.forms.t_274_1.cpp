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