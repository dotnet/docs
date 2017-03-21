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