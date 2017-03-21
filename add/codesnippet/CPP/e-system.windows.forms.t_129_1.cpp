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