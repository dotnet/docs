private:
    void InitialTreeView_NodeMouseClick(Object^ sender,
        TreeNodeMouseClickEventArgs^ e)
    {
        displayNodes->Text = e->Node->Text;
    }