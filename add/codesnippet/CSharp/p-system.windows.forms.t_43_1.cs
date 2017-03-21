	private void SelectNode(TreeNode node)
	{
		if(node.IsSelected)
		{
			// Determine which TreeNode to select.
			switch(myComboBox.Text)
			{
				case "Previous":
					node.TreeView.SelectedNode = node.PrevNode;
					break;
				case "PreviousVisible":
					node.TreeView.SelectedNode = node.PrevVisibleNode;
					break;
				case "Next":
					node.TreeView.SelectedNode = node.NextNode;
					break;
				case "NextVisible":
					node.TreeView.SelectedNode = node.NextVisibleNode;
					break;
				case "First":
					node.TreeView.SelectedNode = node.FirstNode;
					break;
				case "Last":
					node.TreeView.SelectedNode = node.LastNode;
					break;
			}
		}
		node.TreeView.Focus();
	}