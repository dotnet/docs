        void findListView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = findListView.HitTest(e.X, e.Y);
            ListViewItem foundItem = null;
            if (info.Item != null)
                foundItem = info.Item.FindNearestItem(SearchDirectionHint.Up);
            if (foundItem != null)
                label1.Text = "Previous Item: " + foundItem.Text;

            else
                label1.Text = "No item found";
        }