        void HandleMouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
            if (info != null)
                MessageBox.Show("Hit the " + info.Location.ToString());
        }