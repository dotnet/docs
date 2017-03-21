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