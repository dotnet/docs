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