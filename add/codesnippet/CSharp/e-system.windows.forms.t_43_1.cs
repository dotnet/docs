		internal ToolStripButton changeDirectionButton;

		private void InitializeMovingToolStrip()
		{
            movingToolStrip = new ToolStrip();

			changeDirectionButton = new ToolStripButton();

			movingToolStrip.AutoSize = true;
			movingToolStrip.RenderMode = ToolStripRenderMode.System;

			changeDirectionButton.TextDirection = ToolStripTextDirection.Vertical270;
			changeDirectionButton.Overflow = ToolStripItemOverflow.Never;
			changeDirectionButton.Text = "Change Alignment";
				movingToolStrip.Items.Add(changeDirectionButton);
		}


		private void changeDirectionButton_Click(object sender, EventArgs e)
		{

			ToolStripItem item = (ToolStripItem)sender;

			if (item.TextDirection == ToolStripTextDirection.Vertical270 || item.TextDirection == ToolStripTextDirection.Vertical90)
			{
				item.TextDirection = ToolStripTextDirection.Horizontal;
				movingToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
			}
			else
			{
				item.TextDirection = ToolStripTextDirection.Vertical270;
				movingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
			}

		}